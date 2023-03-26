namespace ConnectFour.Models.Boards;

public record GridCell
{
    public Cell Cell { get; init; } = Cell.Empty;
    public ConsoleColor Color { get; init; } = ConsoleColor.White;

    public override string ToString()
    {
        return $$"""GridCell { Cell = {{Cell}}, Color = {{Color}} }""";
    }
}