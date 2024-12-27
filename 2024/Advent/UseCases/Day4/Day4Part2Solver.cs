using System.Buffers;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day4;

internal class Day4Part2Solver : IDay4Solver
{
    private readonly char[] _word = ['M', 'A', 'S'];
    private readonly char[] _reversedWord = ['S', 'A', 'M'];
    private readonly int _halfWordLength;

    internal Day4Part2Solver()
    {
        _halfWordLength = (_word.Length + 1) / 2;
    }

    public int Solve(Day4Data data)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        int count = FindWordInXShape(data.FlatCrossword, data.Rows, data.Columns);

        stopwatch.Stop(); // Average time is 5.8 - 6.2ms, Parallel slows it down for this data size
        AnsiConsole.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        return count;
    }

    private int FindWordInXShape(Span<char> data, int rows, int cols)
    {
        int count = 0;
        IEnumerable<Range> xRange = Enumerable
            .Range(0 + _halfWordLength - 1, rows - _halfWordLength)
            .Select(x => new Range(
                (cols * x) + _halfWordLength - 1,
                (cols * x) + cols - _halfWordLength
            ))
            .ToArray();
        foreach (var range in xRange)
        {
            for (int i = range.Start.Value; i <= range.End.Value; i++)
            {
                int[] x1 = Day4Helpers.ComputeDiagDecIndexes(
                    i - (cols * (_halfWordLength - 1)) - (_halfWordLength - 1),
                    _word.Length,
                    cols
                );
                int[] x2 = Day4Helpers.ComputeDiagIncIndexes(
                    i - (cols * (_halfWordLength - 1)) + (_halfWordLength - 1),
                    _word.Length,
                    cols
                );
                count += (LookForWord(data, x1) && LookForWord(data, x2)) ? 1 : 0;
            }
        }
        return count;
    }

    private bool LookForWord(Span<char> data, int[] letterIndexes)
    {
        // Early exit check
        if (data[letterIndexes[0]] != _word[0] && data[letterIndexes[0]] != _reversedWord[0])
            return false;

        // Use stackalloc for small arrays
        Span<char> chars = stackalloc char[_word.Length];
        for (int x = 0; x < _word.Length; x++)
        {
            chars[x] = data[letterIndexes[x]];
        }

        // Compare spans directly
        return chars.SequenceEqual(_word) || chars.SequenceEqual(_reversedWord);
    }
}
