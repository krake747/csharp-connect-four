namespace ConnectFour;

public class ConnectFourBoard : IBoard
{
    public GridCell[,] Grid { get; } = new GridCell[6, 7];
    public int Rows => Grid.GetLength(0);
    public int Columns => Grid.GetLength(1);

    public ConnectFourBoard()
    {
        for (var row = 0; row < Rows; row++)
            for (var col = 0; col < Columns; col++)
                Grid[row, col] = new GridCell();
    }

    public void DroppingCoin(IPlayer player, int columnNumber)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (Grid[row, columnNumber].Cell != Cell.Empty) continue;
            
            Grid[row, columnNumber] = new GridCell() { Cell = Cell.O, Color = player.Color.ToConsoleColor() };
            break;
        }
    }

    public GridCell[] GetColumn(int columnNumber) => Enumerable.Range(0, Rows)
                                                               .Select(cell => Grid[cell, columnNumber])
                                                               .ToArray();

    public GridCell[] GetRow(int rowNumber) => Enumerable.Range(0, Columns)
                                                         .Select(cell => Grid[rowNumber, cell])
                                                         .ToArray();
}
