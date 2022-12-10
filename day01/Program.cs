await File.ReadAllLinesAsync("input.txt").ContinueWith(t =>
{
    int current = 0;
    var max = new[] { 0, 0, 0 };
    foreach (var line in t.Result)
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            current += int.Parse(line);
            continue;
        }
        max[0] = current > max[0] ? current : max[0];
        max = max.OrderBy(i => i).ToArray();
        current = 0;
    }
    Console.WriteLine(max.Sum()); ;
});