namespace Advent.UseCases.Day13;

internal static class Day13Parser
{
    internal static Day13Data[] Parse(string input)
    {
        var groups = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Day13Data[] result = new Day13Data[groups.Length];
        for (int i = 0; i < groups.Length; i++)
        {
            var lines = groups[i].Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var destination = ParsePoint(lines[2]);
            var points = GetWeightedPoints(lines.Take(2).ToArray());
            result[i] = new Day13Data { Destination = destination, Points = points };
        }
        return result;
    }

    private static WeightedPoint[] GetWeightedPoints(string[] strings)
    {
        /*
        Button A: X+15, Y+29
        Button B: X+56, Y+23
        */
        var points = new WeightedPoint[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            var parts = strings[i].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            var point = ParseWeightedPoint(parts[1]);
            points[i] = new WeightedPoint
            {
                X = point.X,
                Y = point.Y,
                Weight = i % 2 == 0 ? 3 : 1
            };
        }
        return points;
    }

    private static Point ParseWeightedPoint(string v)
    {
        var parts = v.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        var x = int.Parse(parts[0].Split("+")[1]);
        var y = int.Parse(parts[1].Split("+")[1]);
        return new Point { X = x, Y = y };
    }

    private static Point ParsePoint(string v)
    {
        // Prize: X=9778, Y=15506
        var parts = v.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        var x = int.Parse(parts[0].Split("=")[1]);
        var y = int.Parse(parts[1].Split("=")[1]);
        return new Point { X = x, Y = y };
    }
}
