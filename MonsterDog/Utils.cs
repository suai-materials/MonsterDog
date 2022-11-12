using System.Drawing;

namespace MonsterDog;

public static class Utils
{
    public static void DrawSymbol(char sym, int x, int y, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        var defaultColor = Console.BackgroundColor;
        Console.ForegroundColor = color;
        Console.Write(sym);
        Console.ForegroundColor = defaultColor;
        Console.SetCursorPosition(0, 0);
    }
}