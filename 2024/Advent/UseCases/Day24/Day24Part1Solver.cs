using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day24;

internal class Day24Part1Solver : IDay24Solver
{
    public string Solve(Day24Circuit input)
    {
        Stopwatch sw = new();
        sw.Start();
        var result = input.GetOutputNumber();
        sw.Stop();
        AnsiConsole.WriteLine($"Execution time: {sw.Elapsed.TotalMilliseconds} ms");
        return result.ToString();
    }
}
