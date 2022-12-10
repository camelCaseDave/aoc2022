var moves = File.ReadAllLines("input.txt");
var rope = new Rope();

foreach (var move in moves)
{
    var heading = move[0];
    var steps = int.Parse(move[2..]);

    for (int i = 0; i < steps; i++)
    {
        rope.Move(heading);
    }
}

Console.WriteLine(rope.Tail.Positions.Count);

class Rope
{
    public Head Head { get; set; }
    public Tail Tail { get; set; }

    public Rope()
    {
        Head = new Head();
        Tail = new Tail();
    }

    public void Move(char heading)
    {
        Head.Move(heading);
        Tail.Move(Head);
    }
}

class Head
{
    public int X { get; set; }
    public int Y { get; set; }

    public Head()
    {
        X = 0;
        Y = 0;
    }

    public void Move(char heading)
    {
        switch (heading)
        {
            case 'U':
                Y += 1;
                break;
            case 'D':
                Y -= 1;
                break;
            case 'L':
                X -= 1;
                break;
            case 'R':
                X += 1;
                break;
        }
    }
}

class Tail
{
    public int X { get; set; }
    public int Y { get; set; }
    public HashSet<(int, int)> Positions { get; set; }

    public Tail()
    {
        X = 0;
        Y = 0;
        Positions = new HashSet<(int, int)>() { (X, Y) };
    }

    public void Move(Head head)
    {
        var headIsAdjacent = Math.Abs(head.X - X) + Math.Abs(head.Y - Y) == 1;
        if (headIsAdjacent)
        {
            return;
        }

        var xDiff = Math.Abs(head.X - X);
        var yDiff = Math.Abs(head.Y - Y);

        if (xDiff > 1 && yDiff > 1)
        {
            throw new Exception("Head is too far away");
        }

        if (xDiff > 1)
        {
            X += head.X > X ? 1 : -1;
            Y = head.Y;
        }

        if (yDiff > 1)
        {
            Y += head.Y > Y ? 1 : -1;
            X = head.X;
        }

        Positions.Add((X, Y));
    }
}
