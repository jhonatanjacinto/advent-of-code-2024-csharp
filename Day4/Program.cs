using System.Diagnostics;
using System.Text.RegularExpressions;

var watcher = new Stopwatch();
watcher.Start();
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "inputTestDay4.txt");
var lines = File.ReadLines(filePath).ToArray();
var totalOccurrencies = 0;
var matrix = new char[lines[0].Length, lines.Length];

for (var i = 0; i < lines.Length; i++)
{
    var letters = lines[i].ToCharArray();
    FindOccurencies(letters);
    for (var j = 0; j < letters.Length; j++)
    {
        matrix[i, j] = letters[j];
    }
}

TraverseMatrixDiagonally(matrix);
TraverseMatrixVertically(matrix);

Console.WriteLine($"Total: {totalOccurrencies}");
watcher.Stop();
Console.WriteLine($"Execution Time: {watcher.ElapsedMilliseconds} ms");

Console.ReadKey();
return;

void FindOccurencies(char[] letters)
{
    var lineText = new string(letters);
    var count = Regex.Matches(lineText, @"(XMAS|SAMX)").Count;
    totalOccurrencies += count;
}

void TraverseMatrixVertically(char[,] matrixChars)
{
    for (var i = 0; i < matrixChars.GetLength(1); i++)
    {
        var letters = new char[matrixChars.GetLength(0)];
        
        for (var j = 0; j < matrixChars.GetLength(0); j++)
        {
            letters[j] = matrixChars[j, i];
        }
        
        FindOccurencies(letters);
    }
}

void TraverseMatrixDiagonally(char[,] matrixChars)
{
    List<char> letters = [];
    var lastColumnIndex = matrix.GetLength(0) - 1;
    var lastRowIndex = matrix.GetLength(1) - 1;
    var startColumnIndex = 0;
    var startRowIndex = 0;
    var j = startColumnIndex;
    var i = startRowIndex;
    
    while (startRowIndex != lastRowIndex)
    {
        letters.Add(matrix[i, j]);
        j++;
        i++;
        
        if (j > lastColumnIndex)
        {
            i = startRowIndex;
            j = ++startColumnIndex;
            FindOccurencies(letters.ToArray());
            Console.Write(new string(letters.ToArray()));
            Console.WriteLine();
            letters.Clear();
        }

        if (startColumnIndex > lastColumnIndex)
        {
            j = startColumnIndex = 0;
            i = ++startRowIndex;
            lastRowIndex--;
        }
    }
}
