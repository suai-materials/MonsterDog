namespace MonsterDog;

public class Dog : Monster
{
    public ConsoleColor Color;
    public const char Face = '@';

    public Dog()
    {
        byte r = (byte) new Random().Next(10);
        Color = r > 5 ? ConsoleColor.Yellow : ConsoleColor.Green;
    }

    public override async void BeBorn(int x, int y, int weight)
    {
        (X, Y, _weight) = (x, y, weight);
        if (weight > 55)
            Color = ConsoleColor.Gray;
        
        Utils.DrawSymbol(Face, x, y, Color);
    }

    public override Task Move(int dx = 0, int dy = 1)
    {
        (X, Y) = (X + dx, Y + dy);
        if (X > Console.WindowWidth - 1)
            X = 0 + dx;
        if (Y > Console.WindowHeight)
            Y = 0 + dy;
        if (X < 0)
            X = Console.BufferWidth + dx;
        if (Y < 0)
            Y = Console.WindowHeight + dy;
        Utils.DrawSymbol(Face, X, Y, Color);
        return Task.CompletedTask;
    }
}