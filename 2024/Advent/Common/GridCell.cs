namespace Advent.Common;

public readonly struct GridCell(int row, int column) : IEquatable<GridCell>
{
    private static readonly GridCell north = new(-1, 0);
    private static readonly GridCell east = new(0, 1);
    private static readonly GridCell south = new(1, 0);
    private static readonly GridCell west = new(0, -1);

    public readonly int Row = row;
    public readonly int Column = column;

    public override int GetHashCode() => HashCode.Combine(Row, Column);

    public GridCell North => this + north;
    public GridCell East => this + east;
    public GridCell South => this + south;
    public GridCell West => this + west;

    public GridCell Go(Direction direction)
    {
        return direction switch
        {
            Direction.North => North,
            Direction.East => East,
            Direction.South => South,
            Direction.West => West,
            _ => throw new NotImplementedException(),
        };
    }

    public Direction GetDirection(GridCell other)
    {
        return (other - this) switch
        {
            { Row: -1, Column: 0 } => Direction.North,
            { Row: 0, Column: 1 } => Direction.East,
            { Row: 1, Column: 0 } => Direction.South,
            { Row: 0, Column: -1 } => Direction.West,
            _ => throw new NotImplementedException(),
        };
    }

    public int ManhattanDistance(GridCell other) =>
        Math.Abs(Row - other.Row) + Math.Abs(Column - other.Column);

    public bool Equals(GridCell other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj) => obj is GridCell other && Equals(other);

    internal void Deconstruct(out int row, out int column)
    {
        row = Row;
        column = Column;
    }

    public static bool operator ==(GridCell left, GridCell right) => left.Equals(right);

    public static bool operator !=(GridCell left, GridCell right) => !left.Equals(right);

    public static GridCell operator +(GridCell left, GridCell right) =>
        new(left.Row + right.Row, left.Column + right.Column);

    public static GridCell operator -(GridCell left, GridCell right) =>
        new(left.Row - right.Row, left.Column - right.Column);

    public static GridCell operator *(GridCell left, int right) =>
        new(left.Row * right, left.Column * right);

    public static GridCell operator *(int left, GridCell right) => right * left;

    public static GridCell operator /(GridCell left, int right) =>
        new(left.Row / right, left.Column / right);

    public static GridCell operator /(int left, GridCell right) => right / left;

    public static bool operator <(GridCell left, GridCell right) =>
        (left.Row < right.Row && left.Column < right.Column)
        || left.Row == right.Row && left.Column < right.Column;

    public static bool operator >(GridCell left, GridCell right) =>
        left.Row > right.Row || left.Row == right.Row && left.Column > right.Column;

    public static bool operator <=(GridCell left, GridCell right) => left < right || left == right;

    public static bool operator >=(GridCell left, GridCell right) => left > right || left == right;

    public override string ToString() => $"({Row}, {Column})";
}
