using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day23;

internal class Day23Part1Solver : IDay23Solver
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
        var count = _cliques.Count(clique =>
            clique.Count == 3 && clique.Any(node => node.StartsWith('t'))
        );
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return count.ToString();
    }
}
