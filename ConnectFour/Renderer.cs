using System.Text;

namespace ConnectFour;

public class Renderer
{
    private const string RowSeperator = "||---+---+---+---+---+---||";
    public void Render(ConnectFourBoard board)
    {
        var grid = board.Grid;
        Console.WriteLine($"{RowSeperator}");
        for (var row = 0; row < board.Rows; row++)
        {
            var sb = new StringBuilder();
            for (var col = 0; col < board.Columns; col++)
            {
                sb.Append($"| {RenderCell(grid[row, col].Cell)} ");
            }
            Console.WriteLine($"|{sb}||");
            Console.WriteLine($"{RowSeperator}");
        }
        Console.WriteLine($"||=======================||");
        Console.WriteLine();
    }

    private static char RenderCell(Cell cell) => cell == Cell.Empty ? ' ' : 'O';
}
