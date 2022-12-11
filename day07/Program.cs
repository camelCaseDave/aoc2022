var fileSystem = new Stack<string>();
var directories = new Dictionary<string, int>();

foreach (var line in await File.ReadAllLinesAsync("input.txt"))
{
    if (line == "$ cd ..")
        fileSystem.Pop();
    else if (line.StartsWith("$ cd "))
        fileSystem.Push(string.Join("", fileSystem) + line[5..]);
    else if (char.IsDigit(line[0]))
    {
        var size = int.Parse(line.Split(' ')[0]);
        foreach (var directory in fileSystem)
            directories[directory] = directories.GetValueOrDefault(directory) + size;
    }
}

var freeSpace = 70_000_000 - directories.Values.ToList().Max();
var result = directories.Values.ToList().Where(size => size + freeSpace >= 30_000_000).Min();
Console.WriteLine(result);