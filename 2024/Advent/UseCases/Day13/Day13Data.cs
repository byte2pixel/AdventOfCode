namespace Advent.UseCases.Day13;

internal interface IPoint
{
    public long X { get; init; }
    public long Y { get; init; }
}

internal readonly struct Point : IPoint
{
    public long X { get; init; }
    public long Y { get; init; }
}

internal readonly struct WeightedPoint : IPoint, IComparable<WeightedPoint>
{
    public long Weight { get; init; }
    public long X { get; init; }
    public long Y { get; init; }

    public override readonly bool Equals(object? obj) =>
        obj is WeightedPoint point && Weight == point.Weight && X == point.X && Y == point.Y;

    public override readonly int GetHashCode() => HashCode.Combine(Weight, X, Y);

    public readonly int CompareTo(WeightedPoint other) => Weight.CompareTo(other.Weight);

    public static bool operator <(WeightedPoint left, WeightedPoint right) =>
        left.Weight < right.Weight;

    public static bool operator >(WeightedPoint left, WeightedPoint right) =>
        left.Weight > right.Weight;

    public static bool operator <=(WeightedPoint left, WeightedPoint right) =>
        left.Weight <= right.Weight;

    public static bool operator >=(WeightedPoint left, WeightedPoint right) =>
        left.Weight >= right.Weight;

    public static bool operator ==(WeightedPoint left, WeightedPoint right) =>
        left.Weight == right.Weight;

    public static bool operator !=(WeightedPoint left, WeightedPoint right) =>
        left.Weight != right.Weight;
}

internal struct Day13Data
{
    internal IPoint Destination { get; set; }
    internal WeightedPoint[] Points { get; init; }
}
