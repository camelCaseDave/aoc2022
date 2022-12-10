const int NumStacks = 9;
const int LineLength = 36;
var input = File.ReadAllText("input.txt").ToCharArray(0, LineLength * 8);
var stacks = new List<List<char>>(NumStacks);
for (var i = 0; i < NumStacks; i++)
{
    stacks.Add(new List<char>());
}
var stackIndex = 0;
for (int i = 1; i <= 36 * 8; i += 4)
{
    stacks[stackIndex].Add(input[i]);
    stackIndex = stackIndex == NumStacks - 1 ? 0 : stackIndex + 1;
}
stacks.ForEach(s => s.RemoveAll(c => c == ' '));
stacks.ForEach(s => s.Reverse());

var instructions = File.ReadAllLines("input.txt").Take(10..);
var moves = instructions
    .Select(m => m.Split(' '))
    .Select(m => (int.Parse(m[1]), int.Parse(m[3]), int.Parse(m[5])))
    .ToList();

foreach (var (n, from, to) in moves)
{
    stacks[to - 1].AddRange(stacks[from - 1].Take((stacks[from - 1].Count - n)..).Reverse());
    stacks[from - 1].RemoveRange(stacks[from - 1].Count - n, n);
}

var result = new string(stacks.Select(s => s.Last()).ToArray());
Console.WriteLine(result);