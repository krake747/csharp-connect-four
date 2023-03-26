using ConnectFour.App;

namespace ConnectFour.Models.Players;

public interface IPlayer
{
    string Name { get; init; }
    PlayerColor Color { get; init; }
    IAction ChooseAction(Game game, IPlayer player);
}