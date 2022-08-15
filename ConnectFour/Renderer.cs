namespace ConnectFour;

public class Renderer
{
    private const string RowSeperator = "||---+---+---+---+---+---||";
    public void Render(Game game)
    {
        var grid = game.Board.Grid;
        var rows = game.Board.Rows;
        var cols = game.Board.Columns;
        Console.WriteLine();
        for (var row = 0; row < rows; row++)
        {
            Console.WriteLine($"{RowSeperator}");
            Console.Write($"|");
            for (var col = 0; col < cols; col++)
            {
                var cell = grid[row, col];
                Console.Write($"| ");
                ColoredConsole.Write($"{RenderCell(cell.Cell)}", cell.Color);
                Console.Write($" ");
            }
            Console.WriteLine($"||");
        }
        Console.WriteLine($"||=======================||");
        Console.WriteLine($"||(1)+(2)+(3)+(4)+(5)+(6)||");
        Console.WriteLine();
    }

    private static char RenderCell(Cell cell) => cell == Cell.Empty ? ' ' : 'O';
}
