using System.Diagnostics;
var watch = Stopwatch.StartNew();
var score = 0;
var possibilities = new Dictionary<string, int>()
{
    { "A X", 3 },
    { "A Y", 4 },
    { "A Z", 8 },
    { "B X", 1 },
    { "B Y", 5 },
    { "B Z", 9 },
    { "C X", 2 },
    { "C Y", 6 },
    { "C Z", 7 },
};
new List<string>(await File.ReadAllLinesAsync("input.txt")).ForEach(l =>
{
    score += possibilities.First(p => p.Key == l).Value;
});
watch.Stop();
Console.WriteLine($"{score} in {watch.ElapsedMilliseconds}ms");