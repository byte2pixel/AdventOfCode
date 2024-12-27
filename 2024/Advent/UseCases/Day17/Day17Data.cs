namespace Advent.UseCases.Day17
{
    internal struct Day17Data
    {
        internal long RegisterA { get; set; }
        internal long RegisterB { get; set; }
        internal long RegisterC { get; set; }
        internal int[] Opcode { get; init; }
        internal int[] Operand { get; init; }
        internal string OriginalProgram { get; init; }
    }
}
