using System.Buffers;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day4;

public class Day4Part1Solver : IDay4Solver
{
    private readonly char[] _word;
    private readonly int _wordLength;
    private readonly char[] _reversedWord;

    public Day4Part1Solver(string word)
    {
        _word = [.. word];
        _wordLength = _word.Length;
        _reversedWord = _word.Reverse().ToArray();
    }

    public int Solve(Day4Data data)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        int verticalCount = FindVertical(data.FlatCrossword, data.Rows, data.Columns);
        int horizontalCount = FindHorizontal(data.FlatCrossword, data.Rows, data.Columns);
        int diagonalDecCount = FindDiagonalDec(data.FlatCrossword, data.Rows, data.Columns);
        int diagonalIncCount = FindDiagonalInc(data.FlatCrossword, data.Rows, data.Columns);

        stopwatch.Stop(); // Average time is 5.8 - 6.2ms, Parallel slows it down for this data size
        AnsiConsole.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        return verticalCount + horizontalCount + diagonalDecCount + diagonalIncCount;
    }

    private int FindDiagonalInc(Span<char> data, int rows, int cols)
    {
        int count = 0;
        IEnumerable<Range> diagonalRangeInc = Enumerable
            .Range(0, rows - _wordLength + 1)
            .Select(x => new Range(
                (cols * x) + _wordLength - 1,
                (cols * x) + _wordLength - 1 + (cols - _wordLength)
            ))
            .ToArray();
        foreach (var range in diagonalRangeInc)
        {
            for (int i = range.Start.Value; i <= range.End.Value; i++)
            {
                int[] letterIndexes = Day4Helpers.ComputeDiagIncIndexes(i, _wordLength, cols);
                count += LookForWord(data, letterIndexes);
            }
        }
        return count;
    }

    private int FindDiagonalDec(Span<char> data, int rows, int cols)
    {
        int count = 0;
        IEnumerable<Range> diagonalRangeDec = Enumerable
            .Range(0, rows - _wordLength + 1)
            .Select(x => new Range(
                x + ((cols - 1) * x),
                x + ((cols - 1) * x) + (cols - _wordLength)
            ))
            .ToArray();
        foreach (var range in diagonalRangeDec)
        {
            for (int i = range.Start.Value; i <= range.End.Value; i++)
            {
                int[] letterIndexes = Day4Helpers.ComputeDiagDecIndexes(i, _wordLength, cols);
                count += LookForWord(data, letterIndexes);
            }
        }
        return count;
    }

    private int FindHorizontal(Span<char> data, int rows, int cols)
    {
        int count = 0;

        IEnumerable<Range> horizontalRange = Enumerable
            .Range(0, rows)
            .Select(x => new Range(
                x + ((cols - 1) * x),
                x + ((cols - 1) * x) + (cols - _wordLength)
            ))
            .ToArray();
        foreach (var range in horizontalRange)
        {
            for (int i = range.Start.Value; i <= range.End.Value; i++)
            {
                int[] letterIndexes = Day4Helpers.ComputeHorizontalIndexes(i, _wordLength);
                count += LookForWord(data, letterIndexes);
            }
        }
        return count;
    }

    private int FindVertical(Span<char> data, int rows, int cols)
    {
        int count = 0;
        IEnumerable<Range> verticalRange = Enumerable
            .Range(0, rows - _wordLength + 1)
            .Select(x => new Range(x + ((cols - 1) * x), x + ((cols - 1) * x) + cols - 1))
            .ToArray();
        foreach (var range in verticalRange)
        {
            for (int i = range.Start.Value; i <= range.End.Value; i++)
            {
                int[] letterIndexes = Day4Helpers.ComputeVerticalIndexes(i, _wordLength, cols);
                count += LookForWord(data, letterIndexes);
            }
        }
        return count;
    }

    private int LookForWord(Span<char> data, int[] letterIndexes)
    {
        // Early exit check
        if (data[letterIndexes[0]] != _word[0] && data[letterIndexes[0]] != _reversedWord[0])
            return 0;

        // Use stackalloc for small arrays
        Span<char> chars = stackalloc char[_wordLength];
        for (int x = 0; x < _wordLength; x++)
        {
            chars[x] = data[letterIndexes[x]];
        }

        // Compare spans directly
        return chars.SequenceEqual(_word) || chars.SequenceEqual(_reversedWord) ? 1 : 0;
    }
}
