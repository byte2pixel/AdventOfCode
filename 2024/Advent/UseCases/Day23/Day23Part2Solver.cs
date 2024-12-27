using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day23;

internal class Day23Part2Solver : IDay23Solver
{
    internal readonly Dictionary<string, HashSet<string>> _graph = [];
    internal readonly List<List<string>> _cliques = [];

    public string Solve(List<(string, string)> input)
    {
        Stopwatch sw = new();
        sw.Start();
        Day23Helper.PopulateGraphFromInput(input, _graph);
        Day23Helper.ProcessGraph(_graph, _cliques);
        sw.Stop();
        var maxClique =
            _cliques.MaxBy(clique => clique.Count)
            ?? throw new InvalidOperationException("No clique found");
        maxClique.Sort();
        // join maxClique using comma as separator
        var password = string.Join(",", maxClique);
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return password;
    }
}
