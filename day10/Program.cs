var (c, r, s) = (0, 1, 0);
foreach (var l in File.ReadAllLines("input.txt"))
{
    cycle(0);
    if (l != "noop")
        cycle(int.Parse(l[5..]));
}
void cycle(int d)
{
    c++;
    if (new[] { 20, 60, 100, 140, 180, 220 }.Contains(c))
        s += c * r;
    r += d;
}
Console.WriteLine(s);