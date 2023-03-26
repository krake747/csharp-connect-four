namespace ConnectFour.Models.Boards;

public class GridCell
{
    public Cell Cell { get; set; } = Cell.Empty;
    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public override string ToString()
    {
        return $$"""GridCell { Cell = {{Cell}}, Color = {{Color}} }""";
    }
}