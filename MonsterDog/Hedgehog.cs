using System.Drawing;

namespace MonsterDog;

public class Hedgehog : Monster
{
    public ConsoleColor mColor = ConsoleColor.Gray;
    public char mFace = '*';

    public override void BeBorn(int x, int y, int weight)
    {
        (X, Y, _weight) = (x, y, weight);
        Utils.DrawSymbol(mFace, x, y, mColor);
    }

    public override Task Move(int dx = 1, int dy = 0)
    {
        (X, Y) = (X + dx, Y + dy);
        if (X > Console.WindowWidth - 1)
            X = 0 + dx;
        if (Y > Console.WindowHeight)
            Y = 0 + dy;
        if (X < 0)
            X = Console.BufferWidth + dx;
        if (Y < 0)
            Y = Console.BufferHeight + dy;
        Utils.DrawSymbol(mFace, X, Y, mColor);
        return Task.CompletedTask;
    }
}