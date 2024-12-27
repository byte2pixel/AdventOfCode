using System.Diagnostics;
using Advent.UseCases.Day21;
using Spectre.Console;

namespace Advent.UseCases.Day22;

internal class Day22Part1Solver(int simulations) : IDay21Solver
{
    private readonly int _simulations = simulations;

    public string Solve(string[] input)
    {
        Stopwatch sw = new();
        sw.Start();
        var result = 0L;
        foreach (var line in input)
        {
            int number = int.Parse(line);
            result += ProcessNumber(number, _simulations);
        }
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return result.ToString();
    }

    private static long ProcessNumber(int number, int simulations)
    {
        long result = number;
        for (int i = 0; i < simulations; i++)
        {
            result = Day22SecrectNumber.GenerateSecretNumber(result);
        }
        return result;
    }
}
