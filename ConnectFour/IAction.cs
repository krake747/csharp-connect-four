namespace ConnectFour;

public interface IAction
{
    void Run(Game game, IPlayer player);
}