using Advent.UseCases.Day15;

namespace Advent.Tests.UseCases.Day15;

public class Day15ParserTests
{
    [Fact]
    public void Parse_WhenGivenTestData_ShouldReturnDay15Data()
    {
        var input = TestData.Day15TestData;
        // csharpier-ignore
        var expectedGrid = new char[]
        {
            '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',
            '#', '.', '.', 'O', '.', '.', 'O', '.', 'O', '#',
            '#', '.', '.', '.', '.', '.', '.', '.', 'O', '#',
            '#', '.', 'O', 'O', '.', '.', 'O', '.', 'O', '#',
            '#', '.', '.', 'O', '@', '.', '.', 'O', '.', '#',
            '#', 'O', '#', '.', '.', 'O', '.', '.', '.', '#',
            '#', 'O', '.', '.', 'O', '.', '.', 'O', '.', '#',
            '#', '.', 'O', 'O', '.', 'O', '.', 'O', 'O', '#',
            '#', '.', '.', '.', '.', 'O', '.', '.', '.', '#',
            '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'
        };
        var expectedRows = 10;
        var expectedColumns = 10;
        var expectedMoves =
            "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";
        var expected = new Day15Data
        {
            Data = new GridData(expectedGrid, expectedRows, expectedColumns),
            Moves = expectedMoves.ToCharArray()
        };
        var actual = Day15Parser.Parse(input);
        actual.Data.Rows.Should().Be(expected.Data.Rows);
        actual.Data.Columns.Should().Be(expected.Data.Columns);
        actual.Data.ToArray().Should().BeEquivalentTo(expectedGrid);
        actual.Moves.Should().BeEquivalentTo(expectedMoves);
    }
}
