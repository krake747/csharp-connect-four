namespace ConnectFour;

public interface IPlayer
{
    string? Name { get; init; }
    PlayerColor Color { get; init; }
    IAction ChooseAction(Game game, IPlayer player);
}
