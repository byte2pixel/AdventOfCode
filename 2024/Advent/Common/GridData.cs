using System.Text;

namespace Advent.Common;

public readonly struct GridData : IEquatable<GridData>
{
    private readonly char[] _cells;
    public readonly int Rows;
    public readonly int Columns;

    public GridData(Span<char> data, int rows, int columns)
    {
        _cells = data.ToArray();
        Rows = rows;
        Columns = columns;
    }

    public GridData(string[] table)
    {
        if (table.Length == 0)
        {
            throw new ArgumentException("Table is empty");
        }
        if (table.Any(x => x.Length != table[0].Length))
        {
            throw new ArgumentException("Rows are not the same length");
        }
        Rows = table.Length;
        Columns = table[0].Length;
        _cells = new char[Rows * Columns];
        for (int i = 0; i < Rows; i++)
        {
            var row = table[i];
            for (int j = 0; j < Columns; j++)
            {
                _cells[i * Columns + j] = row[j];
            }
        }
    }

    public char[] ToArray() => [.. _cells];

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

    public readonly IEnumerable<(GridCell, char)> this[IEnumerable<GridCell> cells]
    {
        get
        {
            List<(GridCell, char)> results = [];
            foreach (var cell in cells)
            {
                results.Add((cell, this[cell]));
            }
            return results;
        }
    }

    // return an entire row
    public readonly ReadOnlySpan<char> this[int row] => _cells.AsSpan(row * Columns, Columns);

    public readonly int Count(char c) => _cells.Count(x => x == c);

    public readonly int Length => _cells.Length;

    // check if a cell is within the grid
    public readonly bool IsValid(GridCell cell) =>
        cell.Row >= 0 && cell.Row < Rows && cell.Column >= 0 && cell.Column < Columns;

    public readonly bool IsValid(GridCell cell, Direction direction) => IsValid(cell.Go(direction));

    /// <summary>
    /// Find the first cell that contains the specified character.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
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

    /// <summary>
    /// Find all cells that contain the specified character.
    /// </summary>
    /// <param name="c">The character to search for</param>
    /// <returns>All cells that contain the character</returns>
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
    /// Find all cells that are within the specified distance from the start cell.<br/>
    /// Optionally, the cells can contain the specified character.
    /// </summary>
    /// <param name="start">The starting cell</param>
    /// <param name="distance">The maximum distance</param>
    /// <param name="c">Optional character(s) to search for</param>
    /// <returns>All cells that match the criteria</returns>
    internal IEnumerable<GridCell> FindAll(GridCell start, int distance, char[]? c = null)
    {
        var results = new List<GridCell>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                var end = new GridCell(row, column);
                if (
                    start.ManhattanDistance(end) <= distance
                    && (c == null || c.Contains(this[end]))
                )
                {
                    results.Add(end);
                }
            }
        }
        return results;
    }

    /// <summary>
    /// Returns the adjacent cells that are within the grid.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns>All adjacent cells</returns>
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
    /// Returns the cells from the start cell in the specified direction.
    /// Optionally, the distance can be specified or it will go to the edge of the grid.
    /// Stops if it encounters a wall '#'.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    internal IEnumerable<GridCell> FromTo(GridCell start, Direction direction, int? distance = null)
    {
        distance ??= direction switch
        {
            Direction.North => start.Row,
            Direction.South => Rows - start.Row,
            Direction.East => Columns - start.Column,
            Direction.West => start.Column,
            _ => throw new InvalidOperationException("Invalid direction")
        };
        var results = new List<GridCell>();
        var current = start.Go(direction); // skip the start cell
        for (int i = 0; i < distance; i++)
        {
            if (!IsValid(current))
            {
                break;
            }
            if (this[current] == '#') // wall
            {
                break;
            }
            results.Add(current);
            current = current.Go(direction);
        }
        return results;
    }

    /// <summary>
    /// Returns the all cells that are adjacent to the cell, including those that are outside the grid.
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

    public string[] ToStringArray()
    {
        var result = new string[Rows];
        for (int i = 0; i < Rows; i++)
        {
            result[i] = new string(this[i]);
        }
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            sb.AppendLine(this[i].ToString());
        }
        return sb.ToString();
    }

    public override int GetHashCode() => HashCode.Combine(Rows, Columns, _cells);

    public override bool Equals(object? obj) => obj is GridData data && Equals(data);

    public bool Equals(GridData other)
    {
        if (Rows != other.Rows || Columns != other.Columns)
        {
            return false;
        }
        for (int i = 0; i < Rows; i++)
        {
            if (!this[i].SequenceEqual(other[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator ==(GridData left, GridData right) => left.Equals(right);

    public static bool operator !=(GridData left, GridData right) => !left.Equals(right);
}
