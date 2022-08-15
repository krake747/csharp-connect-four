using ConnectFour;

var player1 = new ConsolePlayer() { Name = "Player 1", Color = PlayerColor.Blue };
var player2 = new ConsolePlayer() { Name = "Player 2", Color = PlayerColor.Red };

var game = new Game(player1, player2);
game.Run();

Console.WriteLine("END");
