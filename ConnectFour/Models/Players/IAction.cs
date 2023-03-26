using ConnectFour.App;

namespace ConnectFour.Models.Players;

public interface IAction
{
    void Run(Game game, IPlayer player);
}