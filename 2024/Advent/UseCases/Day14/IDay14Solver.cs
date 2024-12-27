namespace Advent.UseCases.Day14;

internal interface IDay14Solver
{
    (int, string[]?) Solve(Day14Data data, Day14Settings settings);
}
