using Advent.Common;
using Advent.UseCases.Day6;

namespace Advent.UseCases.Day8
{
    public class Day8Part1Solver : IDay6Solver
    {
        public int Solve(GridData input)
        {
            var copyOfGrid = input;
            var uniqueSignals = input.GetUniqueChars(['.']);
            HashSet<(int x, int y)> overlapNodes = [];
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
            IEnumerable<(int row, int column)> antennaLocations,
            HashSet<(int x, int y)> overlapNodes
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

        private static (int, int) GetNewLocation(
            (int row, int column) location,
            (int x, int y) node
        )
        {
            return (location.row + node.x, location.column + node.y);
        }

        private static void ReplaceWithAnitNode(
            GridData copyOfGrid,
            HashSet<(int x, int y)> overlapNodes,
            (int, int) node1
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

        private static (int x, int y)[] GetAntennasDifference(
            (int row, int column) antenna1,
            (int row, int column) antenna2
        )
        {
            (int x1, int y1) = antenna1;
            (int x2, int y2) = antenna2;
            return [(x2 - x1, y2 - y1), (x1 - x2, y1 - y2)];
        }
    }
}
