using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day24;

internal class Day24Part2Solver : IDay24Solver
{
    public string Solve(Day24Circuit input)
    {
        Stopwatch sw = new();
        sw.Start();
        HashSet<string> solution = [];
        foreach (var gate in input.Gates)
        {
            CheckXorsZ(solution, gate);
            CheckXorsNonZ(input, solution, gate);
            CheckOrs(input, solution, gate);
        }
        var a = solution.ToList();
        a.Sort();
        var result = string.Join(',', a);
        sw.Stop();
        return result;
    }

    private static void CheckOrs(Day24Circuit input, HashSet<string> solution, Gate gate)
    {
        if (gate.Type == LogicGate.Or)
        {
            var LhsWires = input.Gates.Single(g => g.OutputWireName == gate.Lhs);
            if (LhsWires.Type != LogicGate.And)
            {
                solution.Add(LhsWires.OutputWireName);
            }

            var Rhswires = input.Gates.Single(g => g.OutputWireName == gate.Rhs);
            if (Rhswires.Type != LogicGate.And)
            {
                solution.Add(Rhswires.OutputWireName);
            }
        }
    }

    private static void CheckXorsNonZ(Day24Circuit input, HashSet<string> solution, Gate gate)
    {
        if (
            !gate.OutputWireName.StartsWith('z')
            && gate.Type == LogicGate.Xor
            && !gate.Lhs.StartsWith('x')
        )
        {
            solution.Add(gate.OutputWireName);
        }

        if (gate.Type == LogicGate.And && gate.Lhs != "x00")
        {
            var wires = input.Gates.Where(g =>
                g.Lhs == gate.OutputWireName || g.Rhs == gate.OutputWireName
            );
            foreach (var wire in wires)
            {
                if (wire.Type != LogicGate.Or)
                {
                    solution.Add(gate.OutputWireName);
                    break;
                }
            }
        }
    }

    private static void CheckXorsZ(HashSet<string> solution, Gate gate)
    {
        if (
            gate.OutputWireName.StartsWith('z')
            && gate.Type != LogicGate.Xor
            && gate.OutputWireName != "z45"
        )
        {
            solution.Add(gate.OutputWireName);
        }
    }
}
