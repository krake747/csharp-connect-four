using ConnectFour.App;
using ConnectFour.Gui;
using ConnectFour.Models.Boards;

namespace ConnectFour.Models.Players;

public class PlayAction : IAction
{
    public void Run(Game game, IPlayer player)
    {
        var board = game.Board;
        var columnNumber = PromptChoice(board, player);

        DroppingCoin(board, player, columnNumber);
    }

    private static int PromptChoice(IBoard board, IPlayer player)
    {
        bool isColumnFull;
        int columnNumber;
        do
        {
            ColoredConsole.Write($"{player.Name} ", player.Color.ToConsoleColor());
            Console.WriteLine("- Select a column to drop your coin in: (Keyboard Keys: 1, 2, 3, 4, 5, 6, 7)");

            columnNumber = SelectColumn();
            isColumnFull = IsColumnFull(board, columnNumber);
        } while (columnNumber is -1 || isColumnFull);

        return columnNumber;
    }

    private static void DroppingCoin(IBoard board, IPlayer player, int columnNumber)
    {
        for (var row = board.Rows - 1; row >= 0; row--)
        {
            if (board.Grid[row, columnNumber].Cell != Cell.Empty) continue;

            board.Grid[row, columnNumber] = new GridCell { Cell = Cell.Filled, Color = player.Color.ToConsoleColor() };
            break;
        }
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
            _ => -1
        };
    }

    private static bool IsColumnFull(IBoard board, int columnNumber)
    {
        if (columnNumber is -1) return true;

        var isColumnFull = board.GetColumn(columnNumber)
            .All(cell => cell.Cell == Cell.Filled);

        if (!isColumnFull) return false;

        ColoredConsole.WriteWarning($"Column #{columnNumber} is full. Please choose another column...");
        return isColumnFull;
    }
}