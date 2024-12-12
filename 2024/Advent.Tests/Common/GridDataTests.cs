namespace Advent.Tests.Common;

public class GridDataTests
{
    private readonly string _testData =
        "....#....."
        + "#........#"
        + ".........."
        + "..#......."
        + ".......#.."
        + ".........."
        + ".#..^....."
        + "........#."
        + "#........."
        + "......#...";
    private readonly int _rows = 10;
    private readonly int _columns = 10;

    [Fact]
    public void Constructor_ShouldInitializeGridWithGivenDimensions()
    {
        var gridData = new GridData(_testData.ToCharArray(), _rows, _columns);

        gridData.Rows.Should().Be(_rows);
        gridData.Columns.Should().Be(_columns);
    }

    [Theory]
    [InlineData(0, 0, '.')]
    [InlineData(0, 1, '.')]
    [InlineData(0, 2, '.')]
    [InlineData(0, 3, '.')]
    [InlineData(0, 4, '#')]
    [InlineData(1, 0, '#')]
    [InlineData(6, 1, '#')]
    [InlineData(6, 4, '^')]
    public void GetCell_ShouldReturnCorrectValue(int row, int column, char expected)
    {
        // Arrange
        var gridData = new GridData(_testData.ToCharArray(), _rows, _columns);

        // Act
        var value = gridData[row, column];

        // Assert
        value.Should().Be(expected);
    }

    [Fact]
    public void GetCell_ShouldThrowExceptionForInvalidIndices()
    {
        // Arrange
        var gridData = new GridData(_testData.ToCharArray(), _rows, _columns);

        // Act & Assert
        try
        {
            _ = gridData[10, 0];
            Assert.Fail("Exception not thrown");
        }
        catch (IndexOutOfRangeException)
        {
            Assert.True(true);
        }
    }
}
