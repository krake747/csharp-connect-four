using ConnectFour;

var player1 = new ConsolePlayer() { Name = "Player 1", Color = PlayerColor.Blue };
var player2 = new ConsolePlayer() { Name = "Player 2", Color = PlayerColor.Red };

bool exit;
do
{
    Console.Clear();

    var game = new Game(player1, player2);
    game.Run();

    ColoredConsole.WriteInfo("Go again? (y/n)");
    exit = Console.ReadKey(true).Key == ConsoleKey.Y ? true : false;

} while (exit);
Environment.Exit(0);
