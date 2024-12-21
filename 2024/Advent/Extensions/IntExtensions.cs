namespace Advent.Extensions;

public static class NumberExtensions
{
    /// <summary>
    /// C# % doesn't work as expected for negative numbers
    /// This method returns the modulus of a number even if it's negative
    /// </summary>
    public static int Mod(this int x, int m) => (x % m + m) % m;

    /// <summary>
    /// C# % doesn't work as expected for negative numbers
    /// This method returns the modulus of a number even if it's negative
    /// </summary>
    public static long Mod(this long x, long m) => (x % m + m) % m;

    public static ulong Mod(this ulong x, ulong m) => (x % m + m) % m;
}
