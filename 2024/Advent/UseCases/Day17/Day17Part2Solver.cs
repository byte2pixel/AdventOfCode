using Spectre.Console;

namespace Advent.UseCases.Day17;

public class Day17Part2Solver : IDay17Solver
{
    public string Solve(Day17Data data)
    {
        var prog1 = Split(data.OriginalProgram);
        List<long> validAValues = [0];
        var reverseProg = prog1.AsEnumerable().Reverse().ToList();
        for (int i = 0; i < reverseProg.Count; i++)
        {
            List<long> newValidAValues = [];
            foreach (var a in validAValues)
            {
                for (uint j = 0; j < 8; j++)
                {
                    long newA = a << 3;
                    newA += j;
                    data.RegisterA = newA;
                    data.RegisterB = 0;
                    data.RegisterC = 0;
                    var result = Day17Program.RunProgram(data);
                    if (result[0] == reverseProg[i])
                    {
                        newValidAValues.Add(newA);
                    }
                }
            }
            validAValues = [.. newValidAValues];
        }
        return validAValues.Order().First().ToString();
    }

    private static List<long> Split(string input)
    {
        return input.Split(',').Select(long.Parse).ToList();
    }
}
