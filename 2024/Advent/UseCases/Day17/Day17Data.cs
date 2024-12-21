namespace Advent.UseCases.Day17
{
    public struct Day17Data
    {
        public long RegisterA { get; set; }
        public long RegisterB { get; set; }
        public long RegisterC { get; set; }
        public int[] Opcode { get; init; }
        public int[] Operand { get; init; }
        public string OriginalProgram { get; init; }
    }
}
