using ConnectFour.Gui;
using ConnectFour.Models.Boards;
using ConnectFour.Models.Players;

namespace ConnectFour.App;

public class Game
{
    private readonly Action<Game> _renderer;
    private readonly WinChecker _winChecker;
    private int _turnCount;

    public Game(GameSetup setup, Action<Game> renderer)
    {
        Player1 = setup.Player1;
        Player2 = setup.Player2;
        Board = setup.Board;
        _renderer = renderer;
        _winChecker = new WinChecker(this);
        DisplayBoard += RenderBoard;
    }

    public IPlayer Player1 { get; }
    public IPlayer Player2 { get; }
    public ConnectFourBoard Board { get; }
    public bool IsOver => _winChecker.IsOver;
    public event Action DisplayBoard;

    public void Run()
    {
        GreetingMessage();
        _renderer(this);

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
        _renderer(this);
    }

    private void GreetingMessage()
    {
        ColoredConsole.WriteInfo($"Welcome {Player1.Name}, {Player2.Name} to Connect Four!");
    }

    private void WinningMessage()
    {
        ColoredConsole.WriteSuccess($"Congrats {_winChecker.Winner?.Name} for winning Connect Four!");
    }
}