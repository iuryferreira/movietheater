namespace MovieTheater.Cli;

public static class ConsoleExtensions
{
    public static void WriteWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
}