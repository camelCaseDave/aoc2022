var monkeys = new List<Monkey>();
var input = await File.ReadAllLinesAsync("input.txt");
for (var i = 1; i < input.Length; i += 7)
{
    var monkey = new Monkey(input[i..(i + 5)]);
    monkeys.Add(monkey);
}
var superModulo = monkeys.Aggregate((uint)1, (current, monkey) => current * monkey.TestDivisibleBy);
for (var i = 0; i < 10000; i++)
    foreach (var monkey in monkeys)
        while (monkey.Items.Any())
        {
            var (receiverIndex, worry) = monkey.Process(superModulo);
            monkeys[(int)receiverIndex].Items.Enqueue(worry);
        }
var monkeyBusiness = monkeys
    .OrderByDescending(m => m.Inspections)
    .Take(2)
    .Aggregate(1UL, (current, monkey) => current * monkey.Inspections);
Console.WriteLine(monkeyBusiness);

class Monkey
{
    public Queue<ulong> Items { get; set; } = new();
    public Func<ulong, ulong> Operation { get; set; }
    public Func<ulong, uint> Test { get; set; }
    public uint TestDivisibleBy { get; set; }
    public ulong Inspections { get; set; }

    public Monkey(string[] lines)
    {
        lines[0][18..].Split(',').Select(ulong.Parse).ToList().ForEach(Items.Enqueue);
        Operation = lines[1][23] switch
        {
            '+' => (x) => x += uint.Parse(lines[1][25..]),
            '*' => (x) => x *= uint.TryParse(lines[1][25..], out var value) ? value : x,
            _ => (x) => throw new Exception("Invalid operation")
        };
        Test = x => x % TestDivisibleBy == 0 ? uint.Parse(lines[3][29..]) : uint.Parse(lines[4][30..]);
        TestDivisibleBy = uint.Parse(lines[2][21..]);
    }

    public (uint, ulong) Process(uint superModulo)
    {
        Inspections++;
        var worry = Operation(Items.Dequeue()) % superModulo;
        var receiverIndex = Test(worry);
        return (receiverIndex, worry);
    }
}
