namespace Advent.UseCases.Day15;

internal interface IDay15Solver
{
    (int, string[]? grid) Solve(Day15Data data);
}
