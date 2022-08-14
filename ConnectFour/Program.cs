using ConnectFour;

var board = new ConnectFourBoard();
var renderer = new Renderer();

var player1 = new ConsolePlayer() { Name = "Player 1", Color = PlayerColor.Red };
var player2 = new ConsolePlayer() { Name = "Player 2", Color = PlayerColor.Blue };

renderer.Render(board);

Console.WriteLine("END");
