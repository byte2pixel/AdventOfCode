using Advent.Extensions;

namespace Advent.Tests.Extensions;

public class IntExtensionsTests
{
    [Theory]
    [InlineData(0, 3, 0)]
    [InlineData(1, 3, 1)]
    [InlineData(2, 3, 2)]
    [InlineData(3, 3, 0)]
    [InlineData(4, 3, 1)]
    [InlineData(5, 3, 2)]
    [InlineData(6, 3, 0)]
    [InlineData(7, 3, 1)]
    [InlineData(8, 3, 2)]
    [InlineData(-8, 3, 1)]
    [InlineData(-7, 3, 2)]
    [InlineData(-6, 3, 0)]
    public void Mod_ShouldReturnCorrect_Result_ForMultipleValues(int x, int m, int expected)
    {
        // Act
        var result = x.Mod(m);

        // Assert
        result.Should().Be(expected);
    }
}
