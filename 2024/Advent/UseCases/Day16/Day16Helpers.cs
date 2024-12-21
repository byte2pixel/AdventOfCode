using Advent.Common;

namespace Advent.UseCases.Day16;

internal class SearchState
{
    public GridCell Position { get; set; }
    public Direction Direction { get; set; }
    public int Score { get; set; }
    public IEnumerable<GridCell> Path { get; set; } = [];
}
