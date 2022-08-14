namespace ConnectFour;

public class ConsolePlayer : IPlayer
{
    public string? Name { get; init; }
    public PlayerColor Color { get; init; }
    public IAction ChooseAction() => new PlayAction();
}
