namespace Advent.UseCases.Day14;

internal static class Day14Parser
{
    internal static Day14Data Parse(string input)
    {
        /*
        // Example input:
        p=54,45 v=-37,75\n
        p=39,0 v=-91,50\n
        p=55,25 v=64,18\n
        p=75,15 v=70,-15\n
        p=38,8 v=66,-55\n
        \n
       */
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var robots = new RobotData[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            robots[i] = new RobotData
            {
                CurrentCell = ParsePoint(parts[0]),
                Velocity = ParsePoint(parts[1])
            };
        }
        return new Day14Data { Robots = robots, };
    }

    private static GridCell ParsePoint(string v)
    {
        // p=54,45
        var parts = v.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var column = int.Parse(parts[0].Split("=")[1]);
        var row = int.Parse(parts[1]);
        return new GridCell(row, column);
    }
}
