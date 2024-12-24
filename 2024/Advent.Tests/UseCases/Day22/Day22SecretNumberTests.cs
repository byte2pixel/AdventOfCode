using Advent.UseCases.Day22;

namespace Advent.Tests.UseCases.Day22;

public class Day22SecrectNumberTests
{
    [Theory]
    [InlineData(123, 15887950)]
    [InlineData(15887950, 16495136)]
    [InlineData(16495136, 527345)]
    [InlineData(527345, 704524)]
    [InlineData(704524, 1553684)]
    [InlineData(1553684, 12683156)]
    [InlineData(12683156, 11100544)]
    [InlineData(11100544, 12249484)]
    [InlineData(12249484, 7753432)]
    [InlineData(7753432, 5908254)]
    public void GenerateSecretNumber_ShouldReturnExpectedValue(int input, long expected)
    {
        // Act
        var result = Day22SecrectNumber.GenerateSecretNumber(input);
        // Assert
        result.Should().Be(expected);
    }
}
