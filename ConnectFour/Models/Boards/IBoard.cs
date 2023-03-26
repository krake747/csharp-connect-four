namespace ConnectFour.Models.Boards;

public interface IBoard
{
    int Columns { get; }
    GridCell[,] Grid { get; }
    int Rows { get; }
    GridCell[] GetColumn(int columnNumber);
    GridCell[] GetRow(int rowNumber);
}