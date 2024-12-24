using System.Diagnostics;
using Advent.UseCases.Day21;
using Spectre.Console;
using PriceSequence = (int, int, int, int);

namespace Advent.UseCases.Day22;

public class Day22Part2Solver : IDay21Solver
{
    private const int SEQUENCE_LENGTH = 4;
    private const int MOD_VALUE = 10;

    private readonly int _simulations;
    private readonly Dictionary<PriceSequence, int> _priceMap = [];
    private readonly HashSet<PriceSequence> _visited = [];

    public Day22Part2Solver(int simulations)
    {
        if (simulations <= SEQUENCE_LENGTH)
            throw new ArgumentException(
                "Simulations must be greater than sequence length",
                nameof(simulations)
            );
        _simulations = simulations;
    }

    public string Solve(string[] input)
    {
        Stopwatch sw = new();
        sw.Start();
        foreach (var line in input)
        {
            _visited.Clear();
            int number = int.Parse(line);
            ProcessNumber(number);
        }
        // Get the maximum value from the price map, that is the answer.
        var max = _priceMap.Values.Max();
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return max.ToString();
    }

    /// <summary>
    /// Processes the number by generating the prices and price differences and filling the price map.
    /// <param name="number"></param>
    /// </summary>
    private void ProcessNumber(long seed)
    {
        var prices = GeneratePrices(seed).ToArray();
        var diffs = prices.Skip(1).Zip(prices, (curr, prev) => curr - prev).ToArray();
        for (int i = 0; i <= diffs.Length - SEQUENCE_LENGTH; i++)
        {
            var sequence = new PriceSequence(diffs[i], diffs[i + 1], diffs[i + 2], diffs[i + 3]);

            if (_visited.Add(sequence))
            {
                _priceMap[sequence] =
                    _priceMap.GetValueOrDefault(sequence) + prices[i + SEQUENCE_LENGTH];
            }
        }
    }

    private IEnumerable<int> GeneratePrices(long seed)
    {
        yield return (int)(seed % MOD_VALUE);

        for (int i = 1; i < _simulations; i++)
        {
            seed = Day22SecrectNumber.GenerateSecretNumber(seed);
            yield return (int)(seed % MOD_VALUE);
        }
    }
}
