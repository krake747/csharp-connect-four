using ConnectFour;

var player1 = new ConsolePlayer() { Name = "Player 1", Color = PlayerColor.Red };
var player2 = new ConsolePlayer() { Name = "Player 2", Color = PlayerColor.Blue };

var game = new Game(player1, player2);
game.Run();

Console.WriteLine("END");
