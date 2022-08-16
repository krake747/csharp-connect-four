namespace ConnectFour;

public class WinChecker
{
    private const int ConnectFour = 4;
    private readonly ConnectFourBoard _board;
    private ConsoleColor _playerColor;
    public bool IsOver;
    public List<Coordinate> GridCoordinates = new List<Coordinate>(4);
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
            if (IsOver) return;
            CheckColumn(player, col);
        }
    }

    private void CheckColumn(IPlayer player, int columNumber)
    {
        int countConsecutiveCoins = 0;
        var column = _board.GetColumn(columNumber);
        for (int row = _board.Rows - 1; row >= 0; row--)
        {
            if (IsOver) return;
            var cell = column[row];

            if (cell.Cell == Cell.Empty) break;

            if (cell.Color != _playerColor)
            {
                countConsecutiveCoins = 0;
                GridCoordinates.Clear();
                continue;
            }

            SetWinner(player, ++countConsecutiveCoins);
            var coordinate = new Coordinate(row, columNumber);
            AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
        }
    }

    private void ConnectFourInRows(IPlayer player)
    {
        for (var row = _board.Rows - 1; row >= 0; row--)
        {
            if (IsOver) return;
            CheckRow(player, row);
        }
    }

    private void CheckRow(IPlayer player, int rowNumber)
    {
        int countConsecutiveCoins = 0;
        var row = _board.GetRow(rowNumber);
        for (int col = 0; col < _board.Columns; col++)
        {
            if (IsOver) return;
            var cell = row[col];

            if (cell.Cell == Cell.Empty)
            {
                countConsecutiveCoins = 0;
                GridCoordinates.Clear();
                break;
            }

            if (cell.Color != _playerColor)
            {
                countConsecutiveCoins = 0;
                GridCoordinates.Clear();
                continue;
            }

            SetWinner(player, ++countConsecutiveCoins);
            var coordinate = new Coordinate(rowNumber, col);
            AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
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
            if (IsOver) return;
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
                if (IsOver) return;
                if (row != col) continue;

                int selectedRow = diagonal + row;
                if (selectedRow > _board.Rows - 1) break;

                var cell = _board.Grid[selectedRow, col];

                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
                var coordinate = new Coordinate(selectedRow, col);
                AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
            }
        }
    }

    private void CheckUpperTriangular(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Columns / 2; diagonal++)
        {
            if (IsOver) return;
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
                if (IsOver) return;
                if (row != col) continue;

                int selectedCol = diagonal + col + 1;
                if (selectedCol > _board.Columns - 1) break;

                var cell = _board.Grid[row, selectedCol];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
                var coordinate = new Coordinate(row, selectedCol);
                AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
            }
        }
    }

    private void CheckUpperAntiDiagonal(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Rows / 2; diagonal++)
        {
            if (IsOver) return;
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
                if (IsOver) return;
                if (row + col != _board.Rows - 1) continue;

                int selectedRow = row - diagonal;
                if (selectedRow < 0) break;

                var cell = _board.Grid[selectedRow, col];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
                var coordinate = new Coordinate(selectedRow, col);
                AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
            }
        }
    }

    private void CheckLowerAntiDiagonal(IPlayer player)
    {
        for (int diagonal = 0; diagonal < _board.Columns / 2; diagonal++)
        {
            if (IsOver) return;
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
                if (IsOver) return;
                if (row + col != _board.Rows) continue;

                int selectedCol = diagonal + col;
                if (selectedCol > 6) break;

                var cell = _board.Grid[row, selectedCol];
                if (cell.Cell == Cell.Empty)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    break;
                }

                if (cell.Color != _playerColor)
                {
                    countConsecutiveCoins = 0;
                    GridCoordinates.Clear();
                    continue;
                }

                SetWinner(player, ++countConsecutiveCoins);
                var coordinate = new Coordinate(row, selectedCol);
                AddWinningGridCoordinates(coordinate, countConsecutiveCoins);
            }
        }
    }

    private void SetWinner(IPlayer player, int countConsecutiveCoins)
    {
        if (countConsecutiveCoins != ConnectFour) return;
        
        Winner = player;
        IsOver = true;
    }

    private void AddWinningGridCoordinates(Coordinate coordinate, int countConsecutiveCoins)
    {
        if (countConsecutiveCoins > 0)
        {
            GridCoordinates.Add(coordinate);
            GridCoordinates = GridCoordinates.Select(gc => gc).Distinct().ToList();
        }
    }
}

