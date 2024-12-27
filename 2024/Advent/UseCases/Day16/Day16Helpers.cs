using Advent.Common;

namespace Advent.UseCases.Day16;

internal class SearchState
{
    internal GridCell Position { get; set; }
    internal Direction Direction { get; set; }
    internal int Score { get; set; }
    internal IEnumerable<GridCell> Path { get; set; } = [];
}
