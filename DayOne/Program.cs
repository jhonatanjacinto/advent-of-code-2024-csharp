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
var similarityScoreList = new List<int>();

for (var i = 0; i < leftNumbers.Count; i++)
{
    var leftNumber = leftNumbers[i];
    var rightNumber = rightNumbers[i];
    var distance = rightNumber - leftNumber;
    
    if (leftNumber > rightNumber)
    {
        distance = leftNumber - rightNumber;
    }
    
    distanceBetweenNumbers.Add(distance);
    var repeatitions = rightNumbers.Count(n => n == leftNumber);
    similarityScoreList.Add(leftNumber * repeatitions);
}

var totalDistance = distanceBetweenNumbers.Sum();
var totalSimilarityScore = similarityScoreList.Sum();

Console.WriteLine($"Total Distance: {totalDistance}");
Console.WriteLine($"Similarity Score: {totalSimilarityScore}");

Console.ReadKey();