var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay2.txt");
var safeReports = 0;

var reports = File.ReadLines(filePath)
        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray()).ToList();

foreach (var report in reports)
{
    var lastDirection = ReportDirection.Unknown;
    var isSafe = true;
    
    for (var i = 0; i < report.Length - 1; i++)
    {
        var differFactor = report[i] - report[i + 1];
        var currentDirection = differFactor < 0 ? ReportDirection.Decreasing : ReportDirection.Increasing;
        if (lastDirection == ReportDirection.Unknown) lastDirection = currentDirection;
        if (currentDirection != lastDirection || Math.Abs(differFactor) > 3 || differFactor == 0)
        {
            isSafe = false;
            break;
        }
    }

    if (isSafe)
    {
        safeReports++;
    }
}

Console.WriteLine($"Safe Reports: {safeReports}");

Console.ReadKey();

internal enum ReportDirection
{
    Increasing,
    Decreasing,
    Unknown
}

