using System.Diagnostics;

var watcher = new Stopwatch();
watcher.Start();
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay2.txt");

var reports = File.ReadLines(filePath)
        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray()).ToList();

var safeReports = reports.Count(report => IsReportSafe(report));

Console.WriteLine($"Safe Reports: {safeReports}");
watcher.Stop();
Console.WriteLine($"Execution Time: {watcher.ElapsedMilliseconds} ms");

Console.ReadKey();
return;

static bool IsReportSafe(int[] report, bool shouldCheckFurther = true)
{
    var lastDirection = ReportDirection.Unknown;
    
    for (var i = 0; i < report.Length - 1; i++)
    {
        var differFactor = report[i] - report[i + 1];
        var currentDirection = differFactor < 0 ? ReportDirection.Increasing : ReportDirection.Decreasing;
        if (lastDirection == ReportDirection.Unknown) lastDirection = currentDirection;
        if (currentDirection != lastDirection || Math.Abs(differFactor) > 3 || differFactor == 0)
        {
            if (!shouldCheckFurther) return false;
            if (i == 1 && IsReportSafe(report.Where((_, index) => index != 0).ToArray(), false)) return true;
            return IsReportSafe(report.Where((_, index) => index != i).ToArray(), false) || IsReportSafe(report.Where((n, index) => index != i + 1).ToArray(), false);
        }
    }
    
    return true;
}

internal enum ReportDirection
{
    Increasing,
    Decreasing,
    Unknown
}

