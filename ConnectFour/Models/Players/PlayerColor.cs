namespace ConnectFour.Models.Players;

public enum PlayerColor
{
    Red,
    Blue
}

public static class PlayerColorExtension
{
    public static ConsoleColor ToConsoleColor(this PlayerColor playerColor)
    {
        return playerColor switch
        {
            PlayerColor.Blue => ConsoleColor.Blue,
            PlayerColor.Red => ConsoleColor.Red,
            _ => ConsoleColor.White
        };
    }
}