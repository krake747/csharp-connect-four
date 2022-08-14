namespace ConnectFour;

public class ConnectFourBoard : IBoard
{
    public GridCell[,] Grid { get; } = new GridCell[7, 6];
    public int Rows => Grid.GetLength(0);
    public int Columns => Grid.GetLength(1);

    public ConnectFourBoard()
    {
        for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                Grid[row, col] = new GridCell();
    }
}
