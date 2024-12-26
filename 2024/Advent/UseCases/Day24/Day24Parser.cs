namespace Advent.UseCases.Day24;

internal static class Day24Parser
{
    internal static Day24Circuit Parse(string input)
    {
        var group = input.Split("\n\n");

        // input wires
        // examples:
        // x00: 1
        // x01: 0
        // y00: 1
        // y01: 0
        var inputWires = group[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, bool> knownWireStates = [];
        var wires = new HashSet<Wire>();
        foreach (var wire in inputWires)
        {
            var wireParts = wire.Split(": ");
            var name = wireParts[0];
            var signal = wireParts[1] switch
            {
                "1" => true,
                "0" => false,
                _ => throw new InvalidOperationException("Invalid signal")
            };
            knownWireStates.Add(name, signal);
            wires.Add(new Wire { Name = name, Signal = signal });
        }

        // blocks
        // examples:
        // ntg XOR fgs -> mjb
        // y02 OR x01 -> tnw
        // kwq OR kpj -> z05
        // x00 OR x03 -> fst

        var blocks = group[1].Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var gates = new List<Gate>();

        foreach (var block in blocks)
        {
            var blockParts = block.Split(" ");
            var gate = blockParts[1] switch
            {
                "AND" => LogicGate.And,
                "OR" => LogicGate.Or,
                "XOR" => LogicGate.Xor,
                _ => throw new InvalidOperationException("Invalid gate")
            };
            var name = blockParts[^1];
            gates.Add(
                new Gate
                {
                    Lhs =
                        string.Compare(blockParts[0], blockParts[2], StringComparison.Ordinal) < 0
                            ? blockParts[0]
                            : blockParts[2],
                    Rhs =
                        string.Compare(blockParts[0], blockParts[2], StringComparison.Ordinal) < 0
                            ? blockParts[2]
                            : blockParts[0],
                    Type = gate,
                    OutputWireName = name
                }
            );
            bool? wire1Signal = knownWireStates.ContainsKey(blockParts[0])
                ? knownWireStates[blockParts[0]]
                : null;
            bool? wire2Signal = knownWireStates.ContainsKey(blockParts[2])
                ? knownWireStates[blockParts[2]]
                : null;
            wires.Add(new Wire { Name = blockParts[0], Signal = wire1Signal });
            wires.Add(new Wire { Name = blockParts[2], Signal = wire2Signal });
            wires.Add(new Wire { Name = name, Signal = null });
        }
        return new Day24Circuit { Wires = wires, Gates = gates };
    }
}
