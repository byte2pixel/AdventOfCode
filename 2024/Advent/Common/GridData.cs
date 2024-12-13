namespace Advent.Common;

public readonly ref struct GridData
{
    private readonly Memory<char> Data;
    public readonly int Rows;
    public readonly int Columns;

    public GridData(Span<char> data, int rows, int columns)
    {
        Data = data.ToArray();
        Rows = rows;
        Columns = columns;
    }

    public readonly char this[int row, int column]
    {
        get => Data.Span[row * Columns + column];
        set => Data.Span[row * Columns + column] = value;
    }

    public readonly char this[(int row, int column) position]
    {
        get => Data.Span[position.row * Columns + position.column];
        set => Data.Span[position.row * Columns + position.column] = value;
    }

    // return an entire row
    public readonly ReadOnlySpan<char> this[int row] => Data.Span.Slice(row * Columns, Columns);

    public readonly int Count(char c) => Data.Span.Count(c);

    public readonly int Length => Data.Length;

    // check if a cell is within the grid
    public readonly bool IsValid((int row, int column) position) =>
        position.row >= 0
        && position.row < Rows
        && position.column >= 0
        && position.column < Columns;

    public readonly (int Row, int Column) Find(char c)
    {
        for (int i = 0; i < Rows; i++)
        {
            var index = this[i].IndexOf(c);
            if (index != -1)
            {
                return (i, index);
            }
        }
        throw new InvalidOperationException($"No {c} position found");
    }

    internal IEnumerable<(int row, int column)> FindAll(char c)
    {
        var results = new List<(int row, int column)>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (this[row, column] == c)
                {
                    results.Add((row, column));
                }
            }
        }
        return results;
    }

    internal char[] GetUniqueChars(char[] filterChars)
    {
        var uniqueChars = new HashSet<char>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (filterChars.Contains(this[row, column]))
                    continue;
                uniqueChars.Add(this[row, column]);
            }
        }
        return [.. uniqueChars];
    }
}
