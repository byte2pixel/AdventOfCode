namespace Advent.UseCases.Day18;

internal interface IDay18Solver
{
    (string result, string grid) Solve(List<GridCell> data);
}
