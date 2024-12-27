using System.Diagnostics;
using Advent.Common;
using Spectre.Console;
using Cache = System.Collections.Generic.Dictionary<
    (char currentKey, char nextKey, int depth),
    long
>;
using Keypad = System.Collections.Generic.Dictionary<Advent.Common.GridCell, char>;

namespace Advent.UseCases.Day21;

internal class Day21Solver(int depth) : IDay21Solver
{
    private readonly int _depth = depth;

    public string Solve(string[] input)
    {
        Stopwatch sw = new();
        sw.Start();
        var numPad = CreateKeypads(["789", "456", "123", " 0A"]);
        var dirPad = CreateKeypads([" ^A", "<v>"]);
        var keypads = Enumerable.Repeat(dirPad, _depth).Prepend(numPad).ToArray();
        var cache = new Cache();
        long result = 0L;

        foreach (var line in input)
        {
            var mutiplier = int.Parse(line[..^1]);
            var cost = ProcessKeys(line, keypads, cache);
            result += mutiplier * cost;
        }
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return result.ToString();
    }

    private long ProcessKeys(string line, Keypad[] keypads, Cache cache)
    {
        if (keypads.Length == 0)
        {
            return line.Length;
        }
        else
        {
            var currentKey = 'A';
            var cost = 0L;

            foreach (var key in line)
            {
                cost += GetCost(currentKey, key, keypads, cache);
                currentKey = key;
            }
            return cost;
        }
    }

    private long GetCost(char currentKey, char nextKey, Keypad[] keypads, Cache cache)
    {
        if (cache.TryGetValue((currentKey, nextKey, keypads.Length), out var cacheCost))
        {
            return cacheCost;
        }
        var keypad = keypads[0];

        var currentKeyPosition = keypad.Single(kvp => kvp.Value == currentKey).Key;
        var nextKeyPosition = keypad.Single(kvp => kvp.Value == nextKey).Key;

        var dRow = nextKeyPosition.Row - currentKeyPosition.Row;
        var vert = new string(dRow < 0 ? 'v' : '^', Math.Abs(dRow));
        var dCol = nextKeyPosition.Column - currentKeyPosition.Column;
        var horiz = new string(dCol < 0 ? '<' : '>', Math.Abs(dCol));

        var cost = long.MaxValue;

        if (keypad[new GridCell(currentKeyPosition.Row, nextKeyPosition.Column)] != ' ')
        {
            cost = Math.Min(cost, ProcessKeys($"{horiz}{vert}A", keypads[1..], cache));
        }
        if (keypad[new GridCell(nextKeyPosition.Row, currentKeyPosition.Column)] != ' ')
        {
            cost = Math.Min(cost, ProcessKeys($"{vert}{horiz}A", keypads[1..], cache));
        }
        cache[(currentKey, nextKey, keypads.Length)] = cost;
        return cost;
    }

    private static Keypad CreateKeypads(string[] keys)
    {
        List<KeyValuePair<GridCell, char>> keyValues = [];
        foreach (var row in Enumerable.Range(0, keys.Length))
        {
            foreach (var col in Enumerable.Range(0, keys[0].Length))
            {
                keyValues.Add(
                    new KeyValuePair<GridCell, char>(new GridCell(-row, col), keys[row][col])
                );
            }
        }
        return keyValues.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}
