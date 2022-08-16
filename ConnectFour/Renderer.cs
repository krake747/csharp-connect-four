namespace ConnectFour;

public class Renderer
{
    private const string RowSeperator = "||---+---+---+---+---+---+---||";

    public void Render(Game game)
    {
        var grid = game.Board.Grid;
        var rows = game.Board.Rows;
        var cols = game.Board.Columns;
        var coords = game.GetWinningCoordinates();
        RenderBoard(grid, rows, cols, coords);
    }

    private static void RenderBoard(GridCell[,] grid, int rows, int cols, List<Coordinate> coords)
    {
        Console.WriteLine();
        for (var row = 0; row < rows; row++)
        {
            Console.WriteLine($"{RowSeperator}");
            RenderRow(grid, cols, row, coords);
        }
        Console.WriteLine($"||===========================||");
        ColoredConsole.WriteWarning($"  (1) (2) (3) (4) (5) (6) (7)  ");
        Console.WriteLine();
    }

    private static void RenderRow(GridCell[,] grid, int cols, int row, List<Coordinate> coords)
    {
        Console.Write($"|");
        for (var col = 0; col < cols; col++)
        {
            var cell = grid[row, col];
            var idx = new Coordinate(row, col);
            Console.Write($"| ");
            if (coords.Contains(idx))
                ColoredConsole.Write($"{RenderCell(cell.Cell)}", cell.Color, ConsoleColor.White);
            else
                ColoredConsole.Write($"{RenderCell(cell.Cell)}", cell.Color);
            Console.Write($" ");
        }
        Console.WriteLine($"||");
    }

    private static char RenderCell(Cell cell) => cell == Cell.Empty ? ' ' : 'O';
}
