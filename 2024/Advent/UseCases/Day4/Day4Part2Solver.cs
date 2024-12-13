using System.Buffers;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day4;

public class Day4Part2Solver : IDay4Solver
{
    private readonly char[] _word;
    private readonly int _wordLength;
    private readonly int _halfWordLength;
    private readonly char[] _reversedWord;

    public Day4Part2Solver(string word)
    {
        if (word.Length % 2 == 0)
        {
            throw new ArgumentException("Word must have an odd length");
        }
        _word = [.. word];
        _wordLength = _word.Length;
        _halfWordLength = (_wordLength + 1) / 2;
        _reversedWord = _word.Reverse().ToArray();
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
                    _wordLength,
                    cols
                );
                int[] x2 = Day4Helpers.ComputeDiagIncIndexes(
                    i - (cols * (_halfWordLength - 1)) + (_halfWordLength - 1),
                    _wordLength,
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
        Span<char> chars = stackalloc char[_wordLength];
        for (int x = 0; x < _wordLength; x++)
        {
            chars[x] = data[letterIndexes[x]];
        }

        // Compare spans directly
        return chars.SequenceEqual(_word) || chars.SequenceEqual(_reversedWord);
    }
}
