using ConnectFour.App;
using ConnectFour.Models.Boards;

namespace ConnectFour.Gui;

public static class GameRenderer
{
    private const string RowSeparator = "||---+---+---+---+---+---+---||";

    public static void Render(Game game)
    {
        var grid = game.Board.Grid;
        var rows = game.Board.Rows;
        var cols = game.Board.Columns;
        var coords = game.GetWinningCoordinates().ToList();
        RenderBoard(grid, rows, cols, coords);
    }

    private static void RenderBoard(GridCell[,] grid, int rows, int cols, List<Coordinate> coords)
    {
        Console.WriteLine();
        for (var row = 0; row < rows; row++)
        {
            Console.WriteLine($"{RowSeparator}");
            RenderRow(grid, cols, row, coords);
        }

        Console.WriteLine("||===========================||");
        ColoredConsole.WriteWarning("  (1) (2) (3) (4) (5) (6) (7)  ");
        Console.WriteLine();
    }

    private static void RenderRow(GridCell[,] grid, int cols, int row, List<Coordinate> coords)
    {
        Console.Write("|");
        for (var col = 0; col < cols; col++)
        {
            var cell = grid[row, col];
            var idx = new Coordinate(row, col);
            Console.Write("| ");
            if (coords.Contains(idx) && coords.Count == 4)
                ColoredConsole.Write($"{RenderCell(cell.Cell)}", cell.Color, ConsoleColor.White);
            else
                ColoredConsole.Write($"{RenderCell(cell.Cell)}", cell.Color);
            Console.Write(" ");
        }

        Console.Write("|| ");
        ColoredConsole.WriteWarning($"R: {row}");
    }

    private static char RenderCell(Cell cell)
    {
        return cell == Cell.Empty ? ' ' : 'O';
    }
}