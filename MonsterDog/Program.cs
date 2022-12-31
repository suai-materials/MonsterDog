using System.Reflection.Metadata.Ecma335;
using MonsterDog;



Random random = new Random();
Console.Clear();

(int, int) WindowsSize = (Console.WindowWidth, Console.WindowHeight);




var task = Task.Run(async delegate
{
    HashSet<Dog> dogs = new();
    HashSet<Hedgehog> hdogs = new();
    restart:
    Console.Clear();
    hdogs.Clear();
    dogs.Clear();
    for (int i = 0; i < (WindowsSize.Item1 * WindowsSize.Item2) / 100; i++)
    {
        dogs.Add(new Dog());
        regen1:
        (int rx, int ry) = (random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight));
        if (dogs.Count(dog => dog.X == rx && dog.Y == ry) == 1) goto regen1;
        dogs.Last().BeBorn(random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight), random.Next(10, 100));
    }

    for (int i = 0; i < (WindowsSize.Item1 * WindowsSize.Item2) / 150; i++)
    {
        hdogs.Add(new Hedgehog());
        regen2:
        (int rx, int ry) = (random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight));
        if (dogs.Count(dog => dog.X == rx && dog.Y == ry) == 1 || hdogs.Count(dog => dog.X == rx && dog.Y == ry) == 1) goto regen2;
        hdogs.Last().BeBorn(random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight), random.Next(10, 100));
    }
    while (true)
    {
        if (WindowsSize.Item1 != Console.WindowWidth || WindowsSize.Item2 != Console.WindowHeight)
        {
            WindowsSize = (Console.WindowWidth, Console.WindowHeight);
            goto restart;
        }
        Console.Clear();
        var task = Task.Run(async delegate
        {
            foreach (var dog in dogs)
            {
                await dog.Move(random.Next(-5, 5), random.Next(-5, 5));
            }
        });
        var task2 = Task.Run(async delegate
        {
            foreach (var hdog in hdogs)
            {
                await hdog.Move(random.Next(-1, 3), random.Next(-1, 3));
            }
        });
        await Task.WhenAll(task, task2);
        await Task.Delay(1);
    }
});

task.Wait();