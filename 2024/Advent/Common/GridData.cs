namespace Advent.Common;

public readonly ref struct GridData
{
    private readonly Span<char> _cells;
    public readonly int Rows;
    public readonly int Columns;

    public GridData(Span<char> data, int rows, int columns)
    {
        _cells = data.ToArray();
        Rows = rows;
        Columns = columns;
    }

    public char[] ToArray() => _cells.ToArray();

    public readonly char this[GridCell cell]
    {
        get => _cells[cell.Row * Columns + cell.Column];
        set => _cells[cell.Row * Columns + cell.Column] = value;
    }

    public readonly char this[int row, int column]
    {
        get => _cells[row * Columns + column];
        set => _cells[row * Columns + column] = value;
    }

    public readonly char this[(int row, int column) position]
    {
        get => _cells[position.row * Columns + position.column];
        set => _cells[position.row * Columns + position.column] = value;
    }

    // return an entire row
    public readonly ReadOnlySpan<char> this[int row] => _cells.Slice(row * Columns, Columns);

    public readonly int Count(char c) => _cells.Count(c);

    public readonly int Length => _cells.Length;

    // check if a cell is within the grid
    public readonly bool IsValid(GridCell cell) =>
        cell.Row >= 0 && cell.Row < Rows && cell.Column >= 0 && cell.Column < Columns;

    public readonly bool IsValid(GridCell cell, Direction direction) => IsValid(cell.Go(direction));

    public readonly GridCell Find(char c)
    {
        for (int i = 0; i < Rows; i++)
        {
            var index = this[i].IndexOf(c);
            if (index != -1)
            {
                return new GridCell(i, index);
            }
        }
        throw new InvalidOperationException($"No {c} position found");
    }

    internal IEnumerable<GridCell> FindAll(char c)
    {
        var results = new List<GridCell>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (this[row, column] == c)
                {
                    results.Add(new GridCell(row, column));
                }
            }
        }
        return results;
    }

    /// <summary>
    /// Returns the adjacent cells that are within the grid.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    internal IEnumerable<GridCell> Adjacent(GridCell cell)
    {
        var results = new List<GridCell>();
        foreach (var direction in Enum.GetValues<Direction>())
        {
            var adjacent = cell.Go(direction);
            if (IsValid(adjacent))
            {
                results.Add(adjacent);
            }
        }
        return results;
    }

    /// <summary>
    /// Returns the adjacent cells that contain the specified character.
    /// only if the cell is in the grid and the character matches.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="c">character to search for</param>
    /// <returns>List of adjacent cells</returns>
    internal IEnumerable<GridCell> Adjacent(GridCell cell, char c)
    {
        var results = new List<GridCell>();
        foreach (var direction in Enum.GetValues<Direction>())
        {
            var adjacent = cell.Go(direction);
            if (IsValid(adjacent) && this[adjacent] == c)
            {
                results.Add(adjacent);
            }
        }
        return results;
    }

    /// <summary>
    /// Returns the all cells that are adjacent to the cell.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    internal static IEnumerable<GridCell> AdjacentUnsafe(GridCell cell)
    {
        var results = new List<GridCell>();
        foreach (var direction in Enum.GetValues<Direction>())
        {
            results.Add(cell.Go(direction));
        }
        return results;
    }

    internal char[] GetUniqueChars(char[]? filterChars = null)
    {
        var uniqueChars = new HashSet<char>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (filterChars?.Contains(this[row, column]) ?? false)
                    continue;
                uniqueChars.Add(this[row, column]);
            }
        }
        return [.. uniqueChars];
    }
}
