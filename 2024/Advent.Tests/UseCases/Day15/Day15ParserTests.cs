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
            '#','#','#','#','#','#','#','#','#','#',
            '#','.','.','O','.','.','O','.','O','#',
            '#','.','.','.','.','.','.','O','.','#',
            '#','.','O','O','.','.','O','.','O','#',
            '#','.','.','O','@','.','.','O','.','#',
            '#','O','#','.','.','O','.','.','.','#',
            '#','O','.','.','O','.','.','O','.','#',
            '#','.','O','O','.','O','.','O','O','#',
            '#','.','.','.','.','O','.','.','.','#',
            '#','#','#','#','#','#','#','#','#','#'
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
        actual.Data.ToArray().Should().Equal(expectedGrid);
        actual.Moves.Should().BeEquivalentTo(expectedMoves);
    }

    [Fact]
    public void ResizeGrid_WhenGivenSmallTestData_ShouldReturnResizedDay15Data()
    {
        // csharpier-ignore
        var expectedGrid = new char[]
        {
            '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',
            '#', '#', '.', '.', '.', '.', '.', '.', '#', '#', '.', '.', '#', '#',
            '#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '#',
            '#', '#', '.', '.', '.', '.', '[', ']', '[', ']', '@', '.', '#', '#',
            '#', '#', '.', '.', '.', '.', '[', ']', '.', '.', '.', '.', '#', '#',
            '#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '#',
            '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'
        };

        var expectedRows = 7;
        var expectedColumns = 14;
        var expectedMoves = "<vv<<^^<<^^";

        var data = Day15Parser.ResizeGrid(Day15Parser.Parse(TestData.Day15Part2SmallTestData));
        data.Data.Rows.Should().Be(expectedRows);
        data.Data.Columns.Should().Be(expectedColumns);
        data.Data.ToArray().Should().Equal(expectedGrid);
        data.Moves.Should().BeEquivalentTo(expectedMoves);
    }

    [Fact]
    public void ResizeGrid_WhenGivenTestData_ShouldReturnResizedDay15Data()
    {
        var expectedRows = 10;
        var expectedColumns = 20;
        var expectedMoves =
            "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";
        // csharpier-ignore
        char[] expectedGrid = [
           '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',
           '#','#','.','.','.','.','[',']','.','.','.','.','[',']','.','.','[',']','#','#',
           '#','#','.','.','.','.','.','.','.','.','.','.','.','.','[',']','.','.','#','#',
           '#','#','.','.','[',']','[',']','.','.','.','.','[',']','.','.','[',']','#','#',
           '#','#','.','.','.','.','[',']','@','.','.','.','.','.','[',']','.','.','#','#',
           '#','#','[',']','#','#','.','.','.','.','[',']','.','.','.','.','.','.','#','#',
           '#','#','[',']','.','.','.','.','[',']','.','.','.','.','[',']','.','.','#','#',
           '#','#','.','.','[',']','[',']','.','.','[',']','.','.','[',']','[',']','#','#',
           '#','#','.','.','.','.','.','.','.','.','[',']','.','.','.','.','.','.','#','#',
           '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',
        ];

        var data = Day15Parser.ResizeGrid(Day15Parser.Parse(TestData.Day15TestData));
        data.Data.Rows.Should().Be(expectedRows);
        data.Data.Columns.Should().Be(expectedColumns);
        data.Data.ToArray().Should().Equal(expectedGrid);
        data.Moves.Should().BeEquivalentTo(expectedMoves);
    }
}
