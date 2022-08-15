namespace ConnectFour;

public class WinChecker
{
    private const int ConnectFour = 4;
    private ConsoleColor _playerColor;
    private ConnectFourBoard _board;
    public bool IsOver;
    public IPlayer? Winner;
    public WinChecker(ConnectFourBoard board)
    {
        _board = board;
    }

    public void Check(IPlayer player)
    {
        _playerColor = player.Color.ToConsoleColor();
        CheckColumns(player);
        CheckRows(player);
    }

    private void CheckColumns(IPlayer player)
    {
        for (var col = 0; col < _board.Columns; col++)
        {
            CheckColumn(player, col);
        }
    }

    private void CheckColumn(IPlayer player, int columNumber)
    {
        int countConsecutiveCoins = 0;
        var column = _board.GetColumn(columNumber);
        for (int r = _board.Rows - 1; r >= 0; r--)
        {
            var cell = column[r];

            if (cell.Cell == Cell.Empty) break;
            
            if (cell.Color != _playerColor)
            {
                countConsecutiveCoins = 0;
                continue;
            }

            countConsecutiveCoins++;
            DetermineWinner(player, countConsecutiveCoins);
        }
    }

    private void CheckRows(IPlayer player)
    {
        for (var row = _board.Rows - 1; row >= 0; row--)
        {
            CheckRow(player, row);
        }
    }

    private void CheckRow(IPlayer player, int rowNumber)
    {
        int countConsecutiveCoins = 0;
        var row = _board.GetRow(rowNumber);
        for (int c = 0; c < _board.Columns; c++)
        {
            var cell = row[c];

            if (cell.Cell == Cell.Empty) break;

            if (cell.Color != _playerColor)
            {
                countConsecutiveCoins = 0;
                continue;
            }

            countConsecutiveCoins++;
            DetermineWinner(player, countConsecutiveCoins);
        }
    }

    private void DetermineWinner(IPlayer player, int countConsecutiveCoins)
    {
        if (countConsecutiveCoins == ConnectFour)
        {
            Winner = player;
            IsOver = true;
        }
    }
}
