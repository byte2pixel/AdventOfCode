using Advent.Extensions;

namespace Advent.Tests.Extensions;

public class GridCellExtensionsTests
{
    [Fact]
    public void SortByRowThenColumn_ShouldSortCellsByRowThenColumn()
    {
        // Arrange
        GridCell[] cells =
        [
            new GridCell(1, 2),
            new GridCell(2, 1),
            new GridCell(1, 1),
            new GridCell(2, 2),
        ];

        // Act
        var result = cells.SortByRowThenColumn().ToArray();

        // Assert
        result
            .Should()
            .BeEquivalentTo(
                [new GridCell(1, 1), new GridCell(1, 2), new GridCell(2, 1), new GridCell(2, 2)]
            );
    }

    [Fact]
    public void SortByColumnThenRow_ShouldSortCellsByColumnThenRow()
    {
        // Arrange
        GridCell[] cells =
        [
            new GridCell(1, 2),
            new GridCell(2, 1),
            new GridCell(1, 1),
            new GridCell(2, 2),
        ];

        // Act
        var result = cells.SortByColumnThenRow().ToArray();

        // Assert
        result
            .Should()
            .BeEquivalentTo(
                [new GridCell(1, 1), new GridCell(2, 1), new GridCell(1, 2), new GridCell(2, 2)]
            );
    }

    [Fact]
    public void FindCellsInSameRow_ShouldReturnCellsInSameRowWithNoGaps()
    {
        // Arrange
        GridCell[] cells =
        [
            // Row 1
            new GridCell(1, 1),
            new GridCell(1, 2),
            new GridCell(1, 3),
            // Row 2
            new GridCell(2, 2),
            new GridCell(2, 3),
            // Row 3
            new GridCell(3, 1),
            new GridCell(3, 2),
            new GridCell(3, 3),
            // Row 4
            new GridCell(4, 1),
            // Gap in 4th row
            new GridCell(4, 4),
            // Gap in 4th row
            new GridCell(4, 6),
            // 8th row
            new GridCell(8, 1),
            new GridCell(8, 2),
            new GridCell(8, 3),
        ];

        // Act
        var result = cells.FindCellsInSameRow().ToArray();

        // Assert
        // result is IGrouping<int, GridCell>[]
        result.Should().HaveCount(4);
        result[0].Key.Should().Be(1);
        result[1].Key.Should().Be(2);
        result[2].Key.Should().Be(3);
        result[3].Key.Should().Be(8);
        result[0].AsEnumerable().Should().HaveCount(3);
        result[1].AsEnumerable().Should().HaveCount(2);
        result[2].AsEnumerable().Should().HaveCount(3);
        result[3].AsEnumerable().Should().HaveCount(3);
    }

    [Fact]
    public void FindCellsInSameColumn_ShouldReturnCellsInSameColumnWithNoGaps()
    {
        // Arrange
        GridCell[] cells =
        [
            // Column 1
            new GridCell(1, 1),
            new GridCell(2, 1),
            new GridCell(3, 1),
            // Column 2
            new GridCell(2, 2),
            new GridCell(3, 2),
            // Column 3
            new GridCell(1, 3),
            new GridCell(2, 3),
            new GridCell(3, 3),
            // Column 4
            new GridCell(1, 4),
            // Gap in 4th column
            new GridCell(4, 4),
            // Gap in 4th column
            new GridCell(6, 4),
            // 8th column
            new GridCell(1, 8),
            new GridCell(2, 8),
            new GridCell(3, 8),
        ];

        // Act
        var result = cells.FindCellsInSameColumn().ToArray();

        // Assert
        // result is IGrouping<int, GridCell>[]
        result.Should().HaveCount(4);
        result[0].Key.Should().Be(1);
        result[1].Key.Should().Be(2);
        result[2].Key.Should().Be(3);
        result[3].Key.Should().Be(8);
        result[0].AsEnumerable().Should().HaveCount(3);
        result[1].AsEnumerable().Should().HaveCount(2);
        result[2].AsEnumerable().Should().HaveCount(3);
        result[3].AsEnumerable().Should().HaveCount(3);
    }

    [Fact]
    public void FindConsecutiveCellsInRow_ShouldReturnConsecutiveCellsInRows()
    {
        // Arrange
        GridCell[] cells =
        [
            // Row 1
            new GridCell(1, 1),
            new GridCell(1, 2),
            new GridCell(1, 3),
            // Row 2 (doesn't have 3 consecutive cells)
            new GridCell(2, 2),
            new GridCell(2, 3),
            // Row 3
            new GridCell(3, 1),
            new GridCell(3, 2),
            new GridCell(3, 3),
            // Row 4 (doesn't have 3 consecutive cells)
            new GridCell(4, 1),
            new GridCell(4, 4),
            new GridCell(4, 6),
            // 8th row
            new GridCell(8, 1),
            new GridCell(8, 2),
            new GridCell(8, 3),
        ];

        // Act
        var result = cells.FindConsecutiveCellsInRow().ToArray();

        // Assert
        result.Should().HaveCount(3);
        result[0]
            .Should()
            .BeEquivalentTo([new GridCell(1, 1), new GridCell(1, 2), new GridCell(1, 3)]);
        result[1]
            .Should()
            .BeEquivalentTo([new GridCell(3, 1), new GridCell(3, 2), new GridCell(3, 3)]);
        result[2]
            .Should()
            .BeEquivalentTo([new GridCell(8, 1), new GridCell(8, 2), new GridCell(8, 3)]);
    }

    [Fact]
    public void FindConsecutiveCellsInColumn_ShouldReturnConsecutiveCellsInColumns()
    {
        // Arrange
        GridCell[] cells =
        [
            // Column 1
            new GridCell(1, 1),
            new GridCell(2, 1),
            new GridCell(3, 1),
            // Column 2 (doesn't have 3 consecutive cells)
            new GridCell(2, 2),
            new GridCell(3, 2),
            // Column 3
            new GridCell(1, 3),
            new GridCell(2, 3),
            new GridCell(3, 3),
            // Column 4 (doesn't have 3 consecutive cells)
            new GridCell(1, 4),
            new GridCell(4, 4),
            new GridCell(6, 4),
            // 8th column
            new GridCell(1, 8),
            new GridCell(2, 8),
            new GridCell(3, 8),
        ];

        // Act
        var result = cells.FindConsecutiveCellsInColumn().ToArray();

        // Assert
        result.Should().HaveCount(3);
        result[0]
            .Should()
            .BeEquivalentTo([new GridCell(1, 1), new GridCell(2, 1), new GridCell(3, 1)]);
        result[1]
            .Should()
            .BeEquivalentTo([new GridCell(1, 3), new GridCell(2, 3), new GridCell(3, 3)]);
        result[2]
            .Should()
            .BeEquivalentTo([new GridCell(1, 8), new GridCell(2, 8), new GridCell(3, 8)]);
    }
}
