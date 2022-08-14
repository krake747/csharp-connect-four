namespace ConnectFour;

public class Renderer
{
    private const string RowSeperator = "||---+---+---+---+---+---||";
    public void Render(ConnectFourBoard board)
    {
        var grid = board.Grid;
        for (var row = 0; row < board.Rows; row++)
        {
            Console.WriteLine($"{RowSeperator}");
            Console.Write($"|");
            for (var col = 0; col < board.Columns; col++)
            {
                var cell = grid[row, col];
                
                Console.Write($"| {RenderCell(cell.Cell)} ", cell.Color);
            }
            Console.WriteLine($"||");
        }
        Console.WriteLine($"||=======================||");
        Console.WriteLine();
    }

    private static char RenderCell(Cell cell) => cell == Cell.Empty ? ' ' : 'O';
}
