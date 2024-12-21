namespace Advent.UseCases.Day17;

internal static class Day17Parser
{
    /// <summary>
    /// Parse the input into a Day17Data object
    /// </summary>
    /// <param name="input"></param>
    /// <returns><see cref="Day17Data"/>with registers initialized and opcodes and operands ready</returns>
    public static Day17Data Parse(string input)
    {
        var lines = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var registers = lines[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var originalProgram = lines[1]
            .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
            .Trim('\n');
        var program = originalProgram.Split(",", StringSplitOptions.RemoveEmptyEntries);
        // odd indices are opcodes, even indices are operands
        var opcode = new int[program.Length / 2];
        var operand = new int[program.Length / 2];
        for (int i = 0; i < program.Length; i++)
        {
            if (i % 2 == 0)
            {
                opcode[i / 2] = int.Parse(program[i]);
            }
            else
            {
                operand[i / 2] = int.Parse(program[i]);
            }
        }
        return new Day17Data
        {
            RegisterA = long.Parse(registers[0].Split(": ")[1]),
            RegisterB = long.Parse(registers[1].Split(": ")[1]),
            RegisterC = long.Parse(registers[2].Split(": ")[1]),
            Opcode = opcode,
            Operand = operand,
            OriginalProgram = originalProgram
        };
    }
}
