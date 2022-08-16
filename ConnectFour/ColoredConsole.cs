namespace ConnectFour;

/// <summary>
/// A class that provides some convenience methods over the top of the console window for displaying text
/// with color.
/// </summary>
public static class ColoredConsole
{
    /// <summary>
    /// Writes a line of text in a specific color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes some text (no new line) in a specific color.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes some text (no new line) in a specific color and in a specific background color
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void Write(string text, ConsoleColor color, ConsoleColor backgroundColor)
    {
        Console.ForegroundColor = color;
        Console.BackgroundColor = backgroundColor;
        Console.Write(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Write a Success Line in Green.
    /// </summary>
    /// <param name="text"></param>
    public static void WriteSuccess(string text) => WriteLine(text, ConsoleColor.Green);


    /// <summary>
    /// Write an Error Line in Red.
    /// </summary>
    /// <param name="text"></param>
    public static void WriteError(string text) => WriteLine(text, ConsoleColor.Red);


    /// <summary>
    /// Write a Warning Line in Dark Yellow
    /// </summary>
    /// <param name="text"></param>
    public static void WriteWarning(string text) => WriteLine(text, ConsoleColor.DarkYellow);



    /// <summary>
    /// Write a Info Line in Dark Cyan.
    /// </summary>
    /// <param name="text"></param>
    public static void WriteInfo(string text) => WriteLine(text, ConsoleColor.DarkCyan);



    /// <summary>
    /// Asks the user a question and on the same line, gets a reply back, switching the user's response
    /// to a cyan color so it stands out.
    /// </summary>
    /// <param name="questionToAsk"></param>
    /// <returns></returns>
    public static string Prompt(string questionToAsk)
    {
        Write($"{questionToAsk} ", ConsoleColor.Gray);
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? ""; // If we got null, use empty string instead.
        Console.ResetColor();
        return input;
    }
}
