using System.Diagnostics;
using System.Text.RegularExpressions;

var watcher = new Stopwatch();
watcher.Start();
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay3.txt");
var fileContent = File.ReadAllText(filePath);
var regex = @"(mul\([0-9]+\,[0-9]+\))";
var matches = Regex.Matches(fileContent, regex);
var total = 0;

foreach (Match match in matches)
{
    var mulOperators = Regex.Replace(match.Value, @"(mul\(|\))", "");
    var operators = Array.ConvertAll(mulOperators.Split(","), int.Parse);
    total += operators[0] * operators[1];
}

Console.WriteLine($"Total: {total}");
watcher.Stop();
Console.WriteLine($"Execution Time: {watcher.ElapsedMilliseconds} ms");