using System.Diagnostics;
using System.Numerics;
using Spectre.Console;

namespace Advent.UseCases.Day13;

/// <summary>
/// Finds the cheapest path for the given data.
/// </summary>
/// <param name="maxIterations">Part 1 requires less than or equal to 100 button presses</param>
/// <param name="offset">Part 2 requires that all X,Y have 10000000000000 added to them</param>
/// <returns>The total cost of all the valid solutions of the cheapest path</returns>
/// <remarks>A lot of help from this link:
/// https://www.reddit.com/r/adventofcode/comments/1hd7irq/2024_day_13_an_explanation_of_the_mathematics/
/// </remarks>
internal class Day13Part1Solver(int? maxIterations = 100, long? offset = null) : IDay13Solver
{
    private readonly int? _maxIterations = maxIterations;
    private readonly long _offset = offset ?? 0;

    public BigInteger Solve(Day13Data[] data)
    {
        Stopwatch sw = new();
        sw.Start();
        BigInteger result = 0;

        if (_offset != 0)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i].Destination = RecomputeDestinations(data[i], _offset);
            }
        }

        foreach (var item in data)
        {
            result += FindCheapestPath(item.Points, item.Destination, _maxIterations);
        }
        sw.Stop(); // Averages 0.6 ms for part 1, 1.1 ms for part 2
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private static Point RecomputeDestinations(Day13Data day13Data, long offset)
    {
        return new Point()
        {
            X = day13Data.Destination.X + offset,
            Y = day13Data.Destination.Y + offset
        };
    }

    public static BigInteger FindCheapestPath(
        WeightedPoint[] points,
        IPoint destination,
        int? maxIterations
    )
    {
        BigInteger targetX = destination.X;
        BigInteger targetY = destination.Y;
        long buttonAx = points[0].X;
        long buttonAy = points[0].Y;
        long buttonACost = points[0].Weight;
        long buttonBx = points[1].X;
        long buttonBy = points[1].Y;
        long buttonBCost = points[1].Weight;
        // Solve the system of linear equations:
        // ax * a + bx * b = targetX
        // ay * a + by * b = targetY

        // Using Cramer's rule for solving 2x2 linear equations
        BigInteger determinant = buttonAx * buttonBy - buttonAy * buttonBx;

        BigInteger a = (targetX * buttonBy - targetY * buttonBx) / determinant;
        BigInteger b = (buttonAx * targetY - buttonAy * targetX) / determinant;

        if (maxIterations.HasValue && (a > maxIterations || b > maxIterations))
        {
            return 0;
        }

        if (buttonAx * a + buttonBx * b != targetX || buttonAy * a + buttonBy * b != targetY)
        {
            return 0;
        }

        // Calculate total cost
        BigInteger totalCost = a * buttonACost + b * buttonBCost;

        return totalCost;
    }
}
