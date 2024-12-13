using Advent.UseCases.Day5;

namespace Advent.Tests.UseCases.Day5
{
    public class Day5ParserTests
    {
        [Fact]
        public void ParseInput_ShouldReturnExpectedResult()
        {
            // Act
            var result = Day5Parser.Parse(TestData.Day5TestData);

            // Assert
            result.PrintRules.Should().HaveCount(6);
            result
                .PrintRules.Should()
                .ContainKey(47)
                .WhoseValue.Should()
                .BeEquivalentTo([53, 13, 61, 29]);

            result
                .PrintRules.Should()
                .ContainKey(97)
                .WhoseValue.Should()
                .BeEquivalentTo([13, 61, 47, 29, 53, 75]);

            result.PagesToPrint.Should().HaveCount(6);
            result.PagesToPrint.ElementAt(0).Should().ContainInOrder(75, 47, 61, 53, 29);
        }

        [Fact]
        public void ParseInput_ShouldThrowArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            string? input = null;

            // Act
            Action act = () => Day5Parser.Parse(input);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
