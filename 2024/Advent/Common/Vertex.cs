namespace Advent.Common;

public readonly struct Vertex(int row, int column) : IEquatable<Vertex>
{
    private static readonly Vertex north = new(-1, 0);
    private static readonly Vertex east = new(0, 1);
    private static readonly Vertex south = new(1, 0);
    private static readonly Vertex west = new(0, -1);

    public readonly int Row = row;
    public readonly int Column = column;

    public override int GetHashCode() => HashCode.Combine(Row, Column);

    public Vertex North => this + north;
    public Vertex East => this + east;
    public Vertex South => this + south;
    public Vertex West => this + west;

    public Vertex Go(Direction direction)
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

    public bool Equals(Vertex other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj) => obj is Vertex other && Equals(other);

    public static bool operator ==(Vertex left, Vertex right) => left.Equals(right);

    public static bool operator !=(Vertex left, Vertex right) => !left.Equals(right);

    public static Vertex operator +(Vertex left, Vertex right) =>
        new(left.Row + right.Row, left.Column + right.Column);

    public static Vertex operator -(Vertex left, Vertex right) =>
        new(left.Row - right.Row, left.Column - right.Column);

    public static bool operator <(Vertex left, Vertex right) =>
        left.Row < right.Row || left.Row == right.Row && left.Column < right.Column;

    public static bool operator >(Vertex left, Vertex right) =>
        left.Row > right.Row || left.Row == right.Row && left.Column > right.Column;

    public static bool operator <=(Vertex left, Vertex right) => left < right || left == right;

    public static bool operator >=(Vertex left, Vertex right) => left > right || left == right;
}
