using ConnectFour.App;

namespace ConnectFour.Models.Players;

public class ConsolePlayer : IPlayer
{
    public required string Name { get; init; }
    public required PlayerColor Color { get; init; }

    public IAction ChooseAction(Game game, IPlayer player)
    {
        return new PlayAction();
    }
}