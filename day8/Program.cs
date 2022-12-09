var input = File.ReadAllLines("input.txt");
var gridWidth = input[0].Length;
var gridHeight = input.Length;
var trees = new List<(int, int, int)>();
var visibilities = new List<int>();

for (var y = 0; y < gridHeight; y++)
{
    for (var x = 0; x < gridWidth; x++)
    {
        trees.Add((x, y, int.Parse(input[y].Skip(x).First().ToString())));
    }
}

foreach (var tree in trees.Where(t =>
    t.Item1 != 0 &&
    t.Item2 != 0 &&
    t.Item1 != gridWidth - 1 &&
    t.Item2 != gridHeight - 1))
{
    var (x, y, h) = tree;
    var (u, d, l, r) = (0, 0, 0, 0);
    // visibility to the right
    for (var i = x + 1; i < gridWidth; i++)
    {
        var neighbour = trees.Find(t => t.Item1 == i && t.Item2 == y);
        r++;
        if (neighbour.Item3 >= h)
        {
            break;
        }
    }
    // visibility to the left
    for (var i = x - 1; i >= 0; i--)
    {
        var neighbour = trees.Find(t => t.Item1 == i && t.Item2 == y);
        l++;
        if (neighbour.Item3 >= h)
        {
            break;
        }
    }
    // visibility above
    for (var i = y - 1; i >= 0; i--)
    {
        var neighbour = trees.Find(t => t.Item1 == x && t.Item2 == i);
        u++;
        if (neighbour.Item3 >= h)
        {
            break;
        }
    }
    // visibility below
    for (var i = y + 1; i < gridHeight; i++)
    {
        var neighbour = trees.Find(t => t.Item1 == x && t.Item2 == i);
        d++;
        if (neighbour.Item3 >= h)
        {
            break;
        }
    }
    visibilities.Add(u * d * l * r);
}

Console.WriteLine(visibilities.Max());