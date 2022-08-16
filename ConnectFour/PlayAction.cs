namespace ConnectFour;

public class PlayAction : IAction
{
    public void Run(Game game, IPlayer player)
    {
        var board = game.Board;
        var columnNumber = PromptChoice(board, player);

        board.DroppingCoin(player, columnNumber);
    }

    private static int PromptChoice(ConnectFourBoard board, IPlayer player)
    {
        bool isColumnFull;
        int columnNumber;
        do
        {
            ColoredConsole.Write($"{player.Name} ", player.Color.ToConsoleColor());
            Console.WriteLine($"- Select a column to drop your coin in: (Keyboard Keys: 1, 2, 3, 4, 5, 6, 7)");

            columnNumber = SelectColumn();
            isColumnFull = IsColumnFull(board, columnNumber);

        } while (columnNumber is -1 || isColumnFull);

        Console.WriteLine("Dropping coin...");
        ColoredConsole.WriteSuccess($"Coin was dropped into column {columnNumber}.\n");

        return columnNumber;
    }

    private static int SelectColumn()
    {
        return Console.ReadKey(true).Key switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => 0,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => 1,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => 2,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => 3,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => 4,
            ConsoleKey.D6 or ConsoleKey.NumPad6 => 5,
            ConsoleKey.D7 or ConsoleKey.NumPad7 => 6,
            _ => -1,
        };
    }

    private static bool IsColumnFull(ConnectFourBoard board, int columnNumber)
    {
        if (columnNumber is -1) return true;

        var column = board.GetColumn(columnNumber);
        bool isColumnFull = column.All(cell => cell.Cell == Cell.O);

        if (isColumnFull)
        {
            ColoredConsole.WriteWarning($"Column {columnNumber} is full. Please choose another...");
        }

        return isColumnFull;
    }
}
