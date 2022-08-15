﻿namespace ConnectFour;

public class PlayAction : IAction
{
    public void Run(Game game, IPlayer player)
    {
        var column = PromptChoice();
        DropCoin(game, player, column);
    }

    private static int PromptChoice()
    {
        int result;
        do
        {
            Console.WriteLine("Select a column to drop your coin in: (Keyboard Keys: 1, 2, 3, 4, 5, 6)");
            result = Console.ReadKey(true).Key switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 0,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 1,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 2,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 3,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 4,
                ConsoleKey.D6 or ConsoleKey.NumPad6 => 5,
                _ => -1,
            };
        } while (result is -1);
        Console.WriteLine("Dropping coin...");
        Console.WriteLine($"Coin was dropped into {result}.\n");
        return result;
    }

    private static void DropCoin(Game game, IPlayer player, int column)
    {
        var board = game.Board;
        board.DropCoin(column);
    }
}
