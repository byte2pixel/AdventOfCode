namespace Advent.UseCases.Day17;

internal class Day17Part1Solver : IDay17Solver
{
    public string Solve(Day17Data data)
    {
        var result = Day17Program.RunProgram(data);
        return string.Join(",", result);
    }
}
