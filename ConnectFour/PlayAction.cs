namespace ConnectFour;

public class PlayAction : IAction
{
    public void Run(Game game, IPlayer player)
    {
        var column = PromptChoice(player);
        var board = game.Board;
        board.DropCoin(player, column);
    }

    private static int PromptChoice(IPlayer player)
    {
        int result;
        do
        {
            ColoredConsole.Write($"{player.Name} ", player.Color.ToConsoleColor());
            Console.WriteLine($"- Select a column to drop your coin in: (Keyboard Keys: 1, 2, 3, 4, 5, 6)");
            result = Console.ReadKey(true).Key switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 0,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 1,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 2,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 3,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 4,
                ConsoleKey.D6 or ConsoleKey.NumPad6 => 5,
                _ => -1,
            };
        } while (result is -1);
        Console.WriteLine("Dropping coin...");
        ColoredConsole.WriteSuccess($"Coin was dropped into {result}.\n");
        return result;
    }
}
