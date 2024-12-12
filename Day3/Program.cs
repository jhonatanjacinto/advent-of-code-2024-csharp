using System.Diagnostics;
using System.Text.RegularExpressions;

var watcher = new Stopwatch();
watcher.Start();
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay3.txt");
var fileContent = File.ReadAllText(filePath);
// \Z ensures that the search will go all the way to the end of the string ignoring even newline characters in the
// middle of the input string
var regex = new Regex(@"(don't\(\)).*?(?=do|don't\(\)|\Z)", RegexOptions.Singleline);
var regexMul = @"(mul\([0-9]+\,[0-9]+\))";
fileContent = regex.Replace(fileContent, "");
var matches = Regex.Matches(fileContent, regexMul);
var total = 0;

foreach (Match match in matches)
{
    var mulOperators = Regex.Replace(match.Value, @"(mul\(|\))", "");
    var operators = Array.ConvertAll(mulOperators.Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse);
    total += operators[0] * operators[1];
}

Console.WriteLine($"Total: {total}");
watcher.Stop();
Console.WriteLine($"Execution Time: {watcher.ElapsedMilliseconds} ms");

Console.ReadKey();