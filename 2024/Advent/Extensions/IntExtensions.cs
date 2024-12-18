namespace Advent.Extensions;

public static class IntExtensions
{
    /// <summary>
    /// C# % doesn't work as expected for negative numbers
    /// This method returns the modulus of a number even if it's negative
    /// </summary>
    public static int Mod(this int x, int m) => (x % m + m) % m;
}
