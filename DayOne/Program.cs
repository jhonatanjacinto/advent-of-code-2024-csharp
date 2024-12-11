using System.Text.RegularExpressions;

var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay1.txt");
var leftNumbers = new List<int>();
var rightNumbers = new List<int>();

foreach (var line in File.ReadLines(filePath))
{
    var numbers = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
    leftNumbers.Add(int.Parse(numbers[0]));
    rightNumbers.Add(int.Parse(numbers[1]));
}

leftNumbers.Sort();
rightNumbers.Sort();

var distanceBetweenNumbers = new List<int>();

for (var i = 0; i < leftNumbers.Count; i++)
{
    var distance = rightNumbers[i] - leftNumbers[i];
    
    if (leftNumbers[i] > rightNumbers[i])
    {
        distance = leftNumbers[i] - rightNumbers[i];
    }
    
    distanceBetweenNumbers.Add(distance);
}

var totalDistance = distanceBetweenNumbers.Sum();

Console.WriteLine($"Total Distance: {totalDistance}");

Console.ReadKey();