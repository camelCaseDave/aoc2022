using Microsoft.VisualBasic;

var inputs = File.ReadAllLines("input.txt");
var score = 0;
for (var i = 0; i < inputs.Length; i += 3)
{
    var lineOne = new HashSet<char>(inputs[i]);
    var lineTwo = new HashSet<char>(inputs[i + 1]);
    var lineThree = new HashSet<char>(inputs[i + 2]);
    lineOne.IntersectWith(lineTwo);
    lineOne.IntersectWith(lineThree);
    var overlap = lineOne.FirstOrDefault();

    score += char.IsUpper(overlap) ? overlap % 32 + 26 : overlap % 32;
}

Console.WriteLine(score);