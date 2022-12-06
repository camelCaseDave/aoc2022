var input = File.ReadAllText("input.txt").ToCharArray();
var marker = input.Take(14).ToList();
for (var i = 0; i < input.Length; i++)
{
    if (marker.Distinct().Count() == 14)
    {
        Console.WriteLine(i);
        break;
    }
    marker.RemoveAt(0);
    marker.Add(input[i]);
}