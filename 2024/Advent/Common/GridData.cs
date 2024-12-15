namespace Advent.Common;

public readonly ref struct GridData
{
    private readonly Span<char> _data;
    public readonly int Rows;
    public readonly int Columns;

    public GridData(Span<char> data, int rows, int columns)
    {
        _data = data.ToArray();
        Rows = rows;
        Columns = columns;
    }

    public char[] ToArray() => _data.ToArray();

    public readonly char this[Vertex vertex]
    {
        get => _data[vertex.Row * Columns + vertex.Column];
        set => _data[vertex.Row * Columns + vertex.Column] = value;
    }

    public readonly char this[int row, int column]
    {
        get => _data[row * Columns + column];
        set => _data[row * Columns + column] = value;
    }

    public readonly char this[(int row, int column) position]
    {
        get => _data[position.row * Columns + position.column];
        set => _data[position.row * Columns + position.column] = value;
    }

    // return an entire row
    public readonly ReadOnlySpan<char> this[int row] => _data.Slice(row * Columns, Columns);

    public readonly int Count(char c) => _data.Count(c);

    public readonly int Length => _data.Length;

    // check if a cell is within the grid
    public readonly bool IsValid(Vertex vertex) =>
        vertex.Row >= 0 && vertex.Row < Rows && vertex.Column >= 0 && vertex.Column < Columns;

    public readonly bool IsValid(Vertex vertex, Direction direction) =>
        IsValid(vertex.Go(direction));

    public readonly Vertex Find(char c)
    {
        for (int i = 0; i < Rows; i++)
        {
            var index = this[i].IndexOf(c);
            if (index != -1)
            {
                return new Vertex(i, index);
            }
        }
        throw new InvalidOperationException($"No {c} position found");
    }

    internal IEnumerable<Vertex> FindAll(char c)
    {
        var results = new List<Vertex>();
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (this[row, column] == c)
                {
                    results.Add(new Vertex(row, column));
                }
            }
        }
        return results;
    }

    internal IEnumerable<Vertex> Adjacent(Vertex vertex)
    {
        var results = new List<Vertex>();
        foreach (var direction in Enum.GetValues<Direction>())
        {
            var adjacent = vertex.Go(direction);
            if (IsValid(adjacent))
            {
                results.Add(adjacent);
            }
        }
        return results;
    }

    internal IEnumerable<Vertex> Adjacent(Vertex vertex, char c)
    {
        var results = new List<Vertex>();
        foreach (var direction in Enum.GetValues<Direction>())
        {
            var adjacent = vertex.Go(direction);
            if (IsValid(adjacent) && this[adjacent] == c)
            {
                results.Add(adjacent);
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
