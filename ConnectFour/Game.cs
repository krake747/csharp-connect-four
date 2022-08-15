namespace ConnectFour;

public class Game
{
    private readonly Renderer _renderer = new Renderer();
    private readonly WinChecker _winChecker;
    public IPlayer Player1 { get; }
    public IPlayer Player2 { get; }
    public ConnectFourBoard Board { get; } = new ConnectFourBoard();
    public bool IsOver => _winChecker.IsOver;
    public Game(IPlayer player1, IPlayer player2)
    {
        Player1 = player1;
        Player2 = player2;
        _winChecker = new WinChecker(this);
    }
    
    public void Run()
    {
        Greeting();
        _renderer.Render(this);

        var group = new List<IPlayer> { Player1, Player2 };
        while (!IsOver)
        {
            foreach (var player in group)
            {
                player.ChooseAction(this, player).Run(this, player);
                _renderer.Render(this);
            }

            break;
        }
    }

    private void Greeting() => Console.WriteLine($"Welcome {Player1.Name}, {Player2.Name} to Connect Four!");
}