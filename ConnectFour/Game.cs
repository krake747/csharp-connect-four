namespace ConnectFour;

public class Game
{
    private readonly Renderer _renderer = new();
    private readonly WinChecker _winChecker;
    private int _turnCount;

    public Game(IPlayer player1, IPlayer player2)
    {
        Player1 = player1;
        Player2 = player2;
        _winChecker = new WinChecker(this);
        DisplayBoard += RenderBoard;
    }

    public IPlayer Player1 { get; }
    public IPlayer Player2 { get; }
    public ConnectFourBoard Board { get; } = new();
    public bool IsOver => _winChecker.IsOver;
    public event Action DisplayBoard;

    public void Run()
    {
        GreetingMessage();
        _renderer.Render(this);

        var group = new List<IPlayer> { Player1, Player2 };
        while (!IsOver)
        {
            RunPlayerAction(group);
        }

        WinningMessage();
    }

    internal List<Coordinate> GetWinningCoordinates()
    {
        return _winChecker.GridCoordinates;
    }

    private void RunPlayerAction(List<IPlayer> group)
    {
        foreach (var player in group)
        {
            player.ChooseAction(this, player).Run(this, player);
            _winChecker.IsConnectFour(player);
            DisplayBoard.Invoke();

            if (IsOver) break;
        }
    }

    private void RenderBoard()
    {
        Console.Clear();
        ColoredConsole.WriteInfo($"Turn #{++_turnCount}");
        _renderer.Render(this);
    }

    private void GreetingMessage()
    {
        ColoredConsole.WriteInfo($"Welcome {Player1.Name}, {Player2.Name} to Connect Four!");
    }

    private void WinningMessage()
    {
        ColoredConsole.WriteSuccess($"Grats {_winChecker.Winner?.Name} for winning Connect Four!");
    }
}