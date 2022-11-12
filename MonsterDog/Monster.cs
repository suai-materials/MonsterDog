namespace MonsterDog;

public abstract class Monster
{
    protected int _weight;
    public int X, Y;

    public abstract void BeBorn(int x, int y, int weight);
    public abstract Task Move(int dx, int dy);
}