namespace ConnectFour;

public class WinChecker
{
    private const int ConnectFour = 4;
    private ConnectFourBoard _board;
    public bool IsOver;
    public IPlayer? Winner;
    public WinChecker(ConnectFourBoard board)
    {
        _board = board;
    }

    public void Check(IPlayer player)
    {
        for (var col = 0; col < _board.Columns; col++)
        {
            int countConsecutiveCoins = 0;
            var column = _board.GetColumn(col);
            foreach (var cell in column)
            {
                if (cell.Cell == Cell.Empty) continue;
                
                if (cell.Cell == Cell.O && cell.Color != player.Color.ToConsoleColor())
                {
                    countConsecutiveCoins = 0;
                }
                
                if (cell.Cell == Cell.O && cell.Color == player.Color.ToConsoleColor())
                {
                    countConsecutiveCoins++;
                }

                if (countConsecutiveCoins == ConnectFour)
                {
                    Winner = player;
                    IsOver = true;
                }
            }
        }
    }
}
