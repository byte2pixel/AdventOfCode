using Advent.Common;

namespace Advent.UseCases.Day25;

internal interface IDay25Solver
{
    public string Solve((List<GridData> locks, List<GridData> keys) input);
}
