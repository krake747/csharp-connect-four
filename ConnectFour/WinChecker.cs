namespace ConnectFour;

public class WinChecker
{
    private const int ConnectFour = 4;
    private ConsoleColor _playerColor;
    private ConnectFourBoard _board;
    public bool IsOver;
    public IPlayer? Winner;
    public WinChecker(Game game)
    {
        _board = game.Board;
    }

    public void IsConnectFour(IPlayer player)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        _playerColor = player.Color.ToConsoleColor();
        ConnectFourInColumns(player);
        ConnectFourInRows(player);
        ConnectFourInDiagonals(player);
        _playerColor = previousColor;
    }

    private void ConnectFourInColumns(IPlayer player)
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

            SetWinner(player, ++countConsecutiveCoins);
        }
    }

    private void ConnectFourInRows(IPlayer player)
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

            if (cell.Cell == Cell.Empty)
            {
                countConsecutiveCoins = 0;
                break;
            }

            if (cell.Color != _playerColor)
            {
                countConsecutiveCoins = 0;
                continue;
            }

            SetWinner(player, ++countConsecutiveCoins);
        }
    }

    private void ConnectFourInDiagonals(IPlayer player)
    {
        _playerColor = player.Color.ToConsoleColor();

        CheckLowerTriangular(player);
        CheckUpperTriangular(player);

        CheckUpperAntiDiagonal(player);
        CheckLowerAntiDiagonal(player);
    }

    private void CheckLowerTriangular(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Rows / 2; diagonal++)
        {
            CheckBelowDiagonal(player, diagonal);
        }
    }

    private void CheckBelowDiagonal(IPlayer player, int diagonal)
    {
        int countConsecutiveCoins = 0;
        for (int row = 0; row < _board.Rows; row++)
        {
            for (int col = 0; col < _board.Columns - 1; col++)
            {
                if (row != col) continue;

                int selectedRow = diagonal + row;
                if (selectedRow > _board.Rows - 1) break;

                var cell = _board.Grid[selectedRow, col];

                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
            }
        }
    }

    private void CheckUpperTriangular(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Columns / 2; diagonal++)
        {
            CheckAboveDiagonal(player, diagonal);
        }
    }

    private void CheckAboveDiagonal(IPlayer player, int diagonal)
    {
        int countConsecutiveCoins = 0;
        for (int row = 0; row < _board.Rows; row++)
        {
            for (int col = 0; col <= _board.Columns; col++)
            {
                if (row != col) continue;

                int selectedCol = diagonal + col + 1;
                if (selectedCol > _board.Columns - 1) break;

                var cell = _board.Grid[row, selectedCol];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
            }
        }
    }

    private void CheckUpperAntiDiagonal(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Rows / 2; diagonal++)
        {
            CheckAboveAntiDiagonal(player, diagonal);
        }
    }

    private void CheckAboveAntiDiagonal(IPlayer player, int diagonal)
    {
        int countConsecutiveCoins = 0;
        for (int row = _board.Rows - 1; row >= 0; row--)
        {
            for (int col = 0; col < _board.Columns; col++)
            {
                if (row + col != _board.Rows - 1) continue;

                int selectedRow = row - diagonal;
                if (selectedRow < 0) break;

                var cell = _board.Grid[selectedRow, col];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
            }
        }
    }

    private void CheckLowerAntiDiagonal(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Columns / 2; diagonal++)
        {
            CheckBelowAntiDiagonal(player, diagonal);
        }
    }

    private void CheckBelowAntiDiagonal(IPlayer player, int diagonal)
    {
        int countConsecutiveCoins = 0;
        for (int row = _board.Rows - 1; row >= 0; row--)
        {
            for (int col = 1; col <= _board.Columns; col++)
            {
                if (row + col != _board.Rows) continue;

                int selectedCol = diagonal + col;
                if (selectedCol > 6) break;

                var cell = _board.Grid[row, selectedCol];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
            }
        }
    }

    private void SetWinner(IPlayer player, int countConsecutiveCoins)
    {
        if (countConsecutiveCoins != ConnectFour) return;
        
        Winner = player;
        IsOver = true;
    }
}

