namespace Advent.UseCases.Day24;

internal enum LogicGate
{
    And,
    Or,
    Xor
}

internal class Wire : IEquatable<Wire>
{
    public required string Name { get; init; }
    public bool? Signal { get; set; } // Nullable to represent undetermined state
    public bool? OriginalSignal { get; set; }

    public void Reset() => Signal = OriginalSignal;

    public bool Equals(Wire? other) => other is not null && Name == other.Name;

    public override bool Equals(object? obj) => obj is Wire wire && Equals(wire);

    public override int GetHashCode() => Name.GetHashCode();

    public static bool operator ==(Wire left, Wire right) => left.Equals(right);

    public static bool operator !=(Wire left, Wire right) => !(left == right);
}

internal class Gate
{
    public required string Lhs { get; init; }
    public required string Rhs { get; init; }
    public LogicGate Type { get; init; } // AND, OR, XOR, etc.
    public required string OutputWireName { get; set; }
}

internal class Day24Circuit
{
    private bool _isSolved = false;
    public HashSet<Wire> Wires { get; init; } = [];
    public List<Gate> Gates { get; init; } = [];

    public Wire GetWire(string name) => Wires.First(w => w.Name == name);

    /// <summary>
    /// Get the signal of the output wire with the given name.
    /// If the circuit has not been solved yet, it will be solved first.
    /// </summary>
    /// <param name="outputWireName"></param>
    /// <returns></returns>
    public bool? GetOutputSignal(string outputWireName)
    {
        Solve();
        // // Return the signal of the requested output wire
        return GetWire(outputWireName).Signal;
    }

    /// <summary>
    /// Solve the circuit by computing the signal of each wire
    /// based on the signals of the input wires and the gates.
    /// until all signals are computed.
    /// </summary>
    private void Solve()
    {
        if (_isSolved)
        {
            return;
        }

        // Solve the circuit
        while (Gates.Any(g => GetWire(g.OutputWireName).Signal == null))
        {
            foreach (var gate in Gates)
            {
                List<bool?> inputSignals = [GetWire(gate.Lhs).Signal, GetWire(gate.Rhs).Signal];
                bool? outputSignal = ApplyGate(gate, inputSignals);
                GetWire(gate.OutputWireName).Signal = outputSignal;
            }
        }

        _isSolved = true;
    }

    /// <summary>
    /// Reset the circuit by setting all wire signals to their original values.
    /// </summary>
    public void Reset()
    {
        foreach (var wire in Wires)
        {
            wire.Reset();
        }
        _isSolved = false;
    }

    public void SwapOutputWires(string outputWireName1, string outputWireName2)
    {
        Reset();
        var gate1 = Gates.First(g => g.OutputWireName == outputWireName1);
        var gate2 = Gates.First(g => g.OutputWireName == outputWireName2);
        gate1.OutputWireName = outputWireName2;
        gate2.OutputWireName = outputWireName1;
    }

    private long GetNumber(char startsWith = 'z')
    {
        var outputWires = Wires
            .Where(w => w.Name.StartsWith(startsWith))
            .OrderBy(w => w.Name)
            .Select(w => w.Name);

        List<bool> signals = [];
        foreach (var wire in outputWires)
        {
            var signal = GetOutputSignal(wire);
            if (!signal.HasValue)
                throw new InvalidOperationException("Signal not found");
            signals.Add(signal.Value);
        }
        // convert all the bools to binary and then into a long
        return signals.Select((b, i) => b ? 1L << i : 0).Aggregate((a, b) => a | b);
    }

    public long GetInput1Number()
    {
        return GetNumber('x');
    }

    public long GetInput2Number()
    {
        return GetNumber('y');
    }

    public long GetOutputNumber()
    {
        return GetNumber();
    }

    private static bool? ApplyGate(Gate gate, List<bool?> inputSignals)
    {
        // Compute output signal based on gate type
        return gate.Type switch
        {
            LogicGate.And
                => inputSignals.Aggregate((a, b) => a.HasValue && b.HasValue ? a & b : null),
            LogicGate.Or
                => inputSignals.Aggregate((a, b) => a.HasValue && b.HasValue ? a | b : null),
            LogicGate.Xor
                => inputSignals.Aggregate((a, b) => a.HasValue && b.HasValue ? a ^ b : null),
            _ => null
        };
    }
}
