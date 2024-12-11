namespace Advent.UseCases.Day4;

public interface IDay4Solver
{
    /// <summary>
    /// Solve the crossword puzzle
    /// </summary>
    /// <param name="word"></param>
    /// <param name="data"></param>
    /// <returns>number of instances that word occurrs in any - | / \ forwards or backwards</returns>
    public int Solve(Day4Data data);
}
