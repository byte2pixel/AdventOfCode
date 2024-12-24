using System.Diagnostics;
using Advent.UseCases.Day21;
using Spectre.Console;
using PriceSequence = (int, int, int, int);

namespace Advent.UseCases.Day22;

public class Day22Part2Solver(int simulations) : IDay21Solver
{
    private readonly Dictionary<PriceSequence, int> _priceMap = [];
    private readonly HashSet<PriceSequence> _visited = [];

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
    private void ProcessNumber(long number)
    {
        int[] prices = new int[simulations + 1];
        int[] priceDiffs = new int[simulations];
        FillPrices(simulations, number, prices, priceDiffs);
        FillPriceMap(simulations, prices, priceDiffs);
    }

    /// <summary>
    /// Fills the prices and price differences arrays with the generated prices and price differences.
    /// </summary>
    /// <param name="simulations"></param>
    /// <param name="number"></param>
    /// <param name="prices"></param>
    /// <param name="priceDiffs"></param>
    private static void FillPrices(int simulations, long number, int[] prices, int[] priceDiffs)
    {
        prices[0] = (int)number % 10;
        for (int i = 1; i < simulations; i++)
        {
            number = Day22SecrectNumber.GenerateSecretNumber(number);
            prices[i] = (int)number % 10;
            priceDiffs[i - 1] = prices[i] - prices[i - 1];
        }
    }

    /// <summary>
    /// Fills the price map with the price sequance and adds the price at that sequence.
    /// </summary>
    /// <param name="simulations"></param>
    /// <param name="prices"></param>
    /// <param name="priceDiffs"></param>
    private void FillPriceMap(int simulations, int[] prices, int[] priceDiffs)
    {
        for (int i = 0; i < simulations - 4; i++)
        {
            PriceSequence sequence = (
                priceDiffs[i],
                priceDiffs[i + 1],
                priceDiffs[i + 2],
                priceDiffs[i + 3]
            );

            if (_visited.Add(sequence))
            {
                if (!_priceMap.TryGetValue(sequence, out _))
                {
                    _priceMap[sequence] = prices[i + 4];
                }
                else
                {
                    _priceMap[sequence] += prices[i + 4];
                }
            }
        }
    }
}
