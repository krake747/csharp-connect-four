public interface IBoard
{
    int Columns { get; }
    GridCell[,] Grid { get; }
    int Rows { get; }
}