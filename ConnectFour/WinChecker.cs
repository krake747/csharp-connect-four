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

    public void Check(IPlayer player)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        _playerColor = player.Color.ToConsoleColor();
        CheckColumns(player);
        CheckRows(player);
        CheckDiagonals(player);
        _playerColor = previousColor;
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

    private void CheckDiagonals(IPlayer player)
    {
        _playerColor = player.Color.ToConsoleColor();

        CheckLowerTriangular(player);
        CheckUpperTriangular(player);
        
        //CheckAboveAntiDiagonal(player);
        //CheckBelowAntiDiagonal(player);
    }

    private void CheckLowerTriangular(IPlayer player)
    {
        int midRows = _board.Rows / 2;
        for (int diagonal = 0; diagonal < midRows; diagonal++)
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
                    if (cell.Cell == Cell.Empty) break;

                    if (cell.Color != _playerColor)
                    {
                        countConsecutiveCoins = 0;
                        continue;
                    }

                    countConsecutiveCoins++;
                    Console.WriteLine($"CheckLowerTriangular Diagonal #{diagonal} | Grid[row: {selectedRow}, col: {col}], Count: {countConsecutiveCoins}");
                    DetermineWinner(player, countConsecutiveCoins);
                }
            } 
        }
    }

    private void CheckUpperTriangular(IPlayer player)
    {
        int midCols = _board.Columns / 2;
        for (int diagonal = 1; diagonal <= midCols; diagonal++)
        {
            int countConsecutiveCoins = 0;
            for (int row = 0; row < _board.Rows; row++)
            {
                for (int col = 0; col < _board.Columns; col++)
                {
                    if (row != col) continue;
                    
                    int selectedCol = diagonal + col;
                    if (selectedCol > _board.Columns - 1) break;

                    var cell = _board.Grid[row, selectedCol];
                    if (cell.Cell == Cell.Empty) break;

                    if (cell.Color != _playerColor)
                    {
                        countConsecutiveCoins = 0;
                        continue;
                    }

                    countConsecutiveCoins++;
                    Console.WriteLine($"CheckUpperTriangular Diagonal #{diagonal} | Grid[row: {row}, col: {selectedCol}], Count: {countConsecutiveCoins}");
                    DetermineWinner(player, countConsecutiveCoins);
                }
            }
        }
    }

    private void CheckAboveAntiDiagonal(IPlayer player)
    {
        throw new NotImplementedException();
    }

    private void CheckBelowAntiDiagonal(IPlayer player)
    {
        throw new NotImplementedException();
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

