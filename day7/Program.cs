var input = System.IO.File.ReadAllLines("input.txt");
var root = new Dir("/", new List<File>(), new List<Dir>());
var currentDir = root;
var prevDir = default(Dir);
foreach (var line in input.Take(1..))
{
    if (line.StartsWith("$ ls")) continue;
    if (line.Equals("$ cd .."))
    {
        currentDir = prevDir;
        continue;
    }
    if (line.StartsWith("$ cd"))
    {
        if (!currentDir.SubDirs.Any(d => d.Name == line[5..]))
        {
            var newDir = new Dir(line[5..], new List<File>(), new List<Dir>());
            currentDir?.SubDirs.Add(newDir);
            currentDir = newDir;
        }
        else
        {
            currentDir = currentDir.SubDirs.First(d => d.Name == line[5..]);
        }

        prevDir = currentDir;
        continue;
    }
    if (int.TryParse(line.Split(' ').First(), out var size))
    {
        var fileName = line.Split(' ').Last();
        currentDir?.Files.Add(new File(fileName, size));
    }
}

var result = root.SubDirs
    .SelectMany(d => d.SubDirs)
    .Where(d => d.Files.Sum(f => f.Size) <= 100000)
    .Sum(d => d.Files.Sum(f => f.Size));

Console.WriteLine(result);

record Dir(string Name, List<File> Files, List<Dir> SubDirs);
record File(string Name, int Size);