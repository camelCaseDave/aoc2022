var fileSystem = new Stack<string>();
var directories = new Dictionary<string, int>();

foreach (var line in await File.ReadAllLinesAsync("input.txt"))
{
    if (line == "$ cd ..")
        fileSystem.Pop();
    else if (line.StartsWith("$ cd "))
        fileSystem.Push(string.Join("", fileSystem) + line[5..]);
    else if (char.IsDigit(line[0]))
        foreach (var path in fileSystem)
            directories[path] = directories.GetValueOrDefault(path) + int.Parse(line.Split(' ')[0]);
}

var result = directories.Values.ToList()
    .Where(size => size + 
        (70_000_000 - directories.Values.ToList().Max()) >= 30_000_000)
    .Min();
Console.WriteLine(result);