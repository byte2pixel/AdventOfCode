namespace Advent.UseCases.Day4;

internal interface IDay4Solver
{
    /// <summary>
    /// Solve the crossword puzzle
    /// </summary>
    /// <param name="word"></param>
    /// <param name="data"></param>
    /// <returns>number of instances that word occurrs in any - | / \ forwards or backwards</returns>
    int Solve(Day4Data data);
}
