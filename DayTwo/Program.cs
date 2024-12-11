var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputDay2.txt");

var reports = File.ReadLines(filePath)
        .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse).ToArray()).ToList();

var safeReports = reports.Count(report => IsReportSafe(report));

Console.WriteLine($"Safe Reports: {safeReports}");

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

            var report0 = report.Where((n, index) => index != 0).ToArray();
            var report1 = report.Where((n, index) => index != i).ToArray();
            var report2 = report.Where((n, index) => index != i + 1).ToArray();
            var isSafe = IsReportSafe(report0, false) || IsReportSafe(report1, false) || IsReportSafe(report2, false);
            
            return isSafe;
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

