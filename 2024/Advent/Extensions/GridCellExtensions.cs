namespace Advent.Extensions;

public static class GridCellExtensions
{
    /// <summary>
    /// Sorts grid cells by row, then by column
    /// </summary>
    public static IOrderedEnumerable<GridCell> SortByRowThenColumn(this IEnumerable<GridCell> cells)
    {
        return cells.OrderBy(c => c.Row).ThenBy(c => c.Column);
    }

    /// <summary>
    /// Sorts grid cells by column, then by row
    /// </summary>
    public static IOrderedEnumerable<GridCell> SortByColumnThenRow(this IEnumerable<GridCell> cells)
    {
        return cells.OrderBy(c => c.Column).ThenBy(c => c.Row);
    }

    /// <summary>
    /// Finds cells in the same row with no gaps
    /// </summary>
    public static IEnumerable<IGrouping<int, GridCell>> FindCellsInSameRow(
        this IEnumerable<GridCell> cells
    )
    {
        return cells
            .GroupBy(c => c.Row)
            .Where(g =>
                g.Select(c => c.Column).Distinct().Count()
                == g.Max(c => c.Column) - g.Min(c => c.Column) + 1
            );
    }

    /// <summary>
    /// Finds cells in the same column with no gaps
    /// </summary>
    public static IEnumerable<IGrouping<int, GridCell>> FindCellsInSameColumn(
        this IEnumerable<GridCell> cells
    )
    {
        return cells
            .GroupBy(c => c.Column)
            .Where(g =>
                g.Select(c => c.Row).Distinct().Count() == g.Max(c => c.Row) - g.Min(c => c.Row) + 1
            );
    }

    /// <summary>
    /// Finds groups of consecutive cells in rows
    /// </summary>
    /// <param name="cells">Collection of grid cells</param>
    /// <param name="minCount">Minimum number of consecutive cells to find</param>
    /// <returns>Groups of consecutive cells in rows</returns>
    public static IEnumerable<IEnumerable<GridCell>> FindConsecutiveCellsInRow(
        this IEnumerable<GridCell> cells,
        int minCount = 3
    )
    {
        return cells
            .GroupBy(c => c.Row)
            .SelectMany(rowGroup =>
            {
                var sortedColumns = rowGroup.OrderBy(c => c.Column).ToList();
                var consecutiveGroups = new List<List<GridCell>>();

                if (sortedColumns.Count < minCount)
                    return [];

                var currentGroup = new List<GridCell> { sortedColumns[0] };

                for (int i = 1; i < sortedColumns.Count; i++)
                {
                    if (sortedColumns[i].Column == sortedColumns[i - 1].Column + 1)
                    {
                        currentGroup.Add(sortedColumns[i]);
                    }
                    else
                    {
                        if (currentGroup.Count >= minCount)
                            consecutiveGroups.Add(currentGroup);
                        currentGroup = [sortedColumns[i]];
                    }
                }

                if (currentGroup.Count >= minCount)
                    consecutiveGroups.Add(currentGroup);

                return consecutiveGroups;
            });
    }

    /// <summary>
    /// Finds groups of consecutive cells in columns
    /// </summary>
    /// <param name="cells">Collection of grid cells</param>
    /// <param name="minCount">Minimum number of consecutive cells to find</param>
    /// <returns>Groups of consecutive cells in columns</returns>
    public static IEnumerable<IEnumerable<GridCell>> FindConsecutiveCellsInColumn(
        this IEnumerable<GridCell> cells,
        int minCount = 3
    )
    {
        return cells
            .GroupBy(c => c.Column)
            .SelectMany(columnGroup =>
            {
                var sortedRows = columnGroup.OrderBy(c => c.Row).ToList();
                var consecutiveGroups = new List<List<GridCell>>();

                if (sortedRows.Count < minCount)
                    return [];

                var currentGroup = new List<GridCell> { sortedRows[0] };

                for (int i = 1; i < sortedRows.Count; i++)
                {
                    if (sortedRows[i].Row == sortedRows[i - 1].Row + 1)
                    {
                        currentGroup.Add(sortedRows[i]);
                    }
                    else
                    {
                        if (currentGroup.Count >= minCount)
                            consecutiveGroups.Add(currentGroup);
                        currentGroup = [sortedRows[i]];
                    }
                }

                if (currentGroup.Count >= minCount)
                    consecutiveGroups.Add(currentGroup);

                return consecutiveGroups;
            });
    }
}
