using ConnectFour.App;
using ConnectFour.Gui;
using ConnectFour.Models.Players;

bool exit;
do
{
    Console.Clear();
    var player1 = new ConsolePlayer { Name = "Player 1", Color = PlayerColor.Blue };
    var player2 = new ConsolePlayer { Name = "Player 2", Color = PlayerColor.Red };
    var board = new ConnectFourBoard();
    var gameSetup = new GameSetup(player1, player2, board);
    var game = new Game(gameSetup, GameRenderer.Render);
    game.Run();

    ColoredConsole.WriteInfo("Go again? (y/n)");
    exit = Console.ReadKey(true).Key == ConsoleKey.Y;
} while (exit);

Environment.Exit(0);