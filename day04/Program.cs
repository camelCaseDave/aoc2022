var score = 0;
foreach (var line in File.ReadAllLines("input.txt"))
{
    var split = line.Split(',');
    var (a, b) = (int.Parse(split[0].Split('-')[0]), int.Parse(split[0].Split('-')[1]));
    var (x, y) = (int.Parse(split[1].Split('-')[0]), int.Parse(split[1].Split('-')[1]));
    var left = new HashSet<int>(Enumerable.Range(a, b - a + 1));
    var right = new HashSet<int>(Enumerable.Range(x, y - x + 1));
    var intersection = left.Intersect(right);
    score += intersection.Any() ? 1 : 0;
}
Console.WriteLine(score);