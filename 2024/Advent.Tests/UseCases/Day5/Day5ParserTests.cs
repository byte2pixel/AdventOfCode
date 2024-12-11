using Advent.UseCases.Day5;
using Xunit;

namespace Advent.Tests.UseCases.Day5
{
    public class Day5ParserTests
    {
        private const string TestData =
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

        [Fact]
        public void ParseInput_ShouldReturnExpectedResult()
        {
            // Act
            var result = Day5Parser.Parse(TestData);

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
