using Advent.Common;

namespace Advent.UseCases.Day18;

public interface IDay18Solver
{
    (string result, string grid) Solve(List<GridCell> data);
}
