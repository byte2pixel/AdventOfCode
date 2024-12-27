using Advent.Common;
using Advent.UseCases.Day6;

namespace Advent.UseCases.Day8;

internal class Day8Part1Solver : IDay6Solver
{
    public int Solve(GridData input)
    {
        var copyOfGrid = input;
        var uniqueSignals = input.GetUniqueChars(['.']);
        HashSet<GridCell> overlapNodes = [];
        foreach (var signal in uniqueSignals)
        {
            var antennaLocations = input.FindAll(signal);
            PlaceAntiNodes(copyOfGrid, antennaLocations, overlapNodes);
        }
        var count = copyOfGrid.Count('#');
        count += overlapNodes.Count;
        return count;
    }

    private static void PlaceAntiNodes(
        GridData copyOfGrid,
        IEnumerable<GridCell> antennaLocations,
        HashSet<GridCell> overlapNodes
    )
    {
        for (var i = 0; i < antennaLocations.Count(); i++)
        {
            var location = antennaLocations.ElementAt(i);
            for (var j = 0; j < antennaLocations.Count(); j++)
            {
                var otherLocation = antennaLocations.ElementAt(j);

                if (location == otherLocation)
                    continue;

                var nodes = GetAntennasDifference(location, otherLocation);
                var node1 = GetNewLocation(location, nodes[1]);
                var node2 = GetNewLocation(otherLocation, nodes[0]);
                ReplaceWithAnitNode(copyOfGrid, overlapNodes, node1);
                ReplaceWithAnitNode(copyOfGrid, overlapNodes, node2);
            }
        }
    }

    private static GridCell GetNewLocation(GridCell location, GridCell node)
    {
        return new(location.Row + node.Row, location.Column + node.Column);
    }

    private static void ReplaceWithAnitNode(
        GridData copyOfGrid,
        HashSet<GridCell> overlapNodes,
        GridCell node1
    )
    {
        if (copyOfGrid.IsValid(node1))
        {
            if (copyOfGrid[node1] == '.' || copyOfGrid[node1] == '#')
                copyOfGrid[node1] = '#';
            else
                overlapNodes.Add(node1);
        }
    }

    private static GridCell[] GetAntennasDifference(GridCell antenna1, GridCell antenna2)
    {
        return
        [
            new GridCell(antenna2.Row - antenna1.Row, antenna2.Column - antenna1.Column),
            new GridCell(antenna1.Row - antenna2.Row, antenna1.Column - antenna2.Column)
        ];
    }
}
