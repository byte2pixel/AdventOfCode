namespace Advent.UseCases.Day23;

internal static class Day23Helper
{
    public static void PopulateGraphFromInput(
        List<(string, string)> edges,
        Dictionary<string, HashSet<string>> adjacencyList
    )
    {
        void AddEdge(string from, string to)
        {
            if (!adjacencyList.TryGetValue(from, out var neighbors))
            {
                neighbors = [];
                adjacencyList[from] = neighbors;
            }
            neighbors.Add(to);
        }

        foreach (var (node1, node2) in edges)
        {
            AddEdge(node1, node2);
            AddEdge(node2, node1);
        }
    }

    public static void ProcessGraph(
        Dictionary<string, HashSet<string>> graph,
        List<List<string>> cliques
    )
    {
        BronKerboschForAllCliques([], [.. graph.Keys], [], graph, cliques);
    }

    private static void BronKerboschForAllCliques(
        List<string> R,
        List<string> P,
        List<string> X,
        Dictionary<string, HashSet<string>> graph,
        List<List<string>> cliques
    )
    {
        // Store every intermediate clique (not just maximal)
        if (R.Count > 0)
        {
            cliques.Add([.. R]);
        }

        // Make a copy of P to avoid modifying while iterating
        foreach (var node in P.ToList())
        {
            var neighbors = graph[node];

            BronKerboschForAllCliques(
                [.. R, node],
                P.Intersect(neighbors).ToList(),
                X.Intersect(neighbors).ToList(),
                graph,
                cliques
            );

            P.Remove(node);
            X.Add(node);
        }
    }
}
