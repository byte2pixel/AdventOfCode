using Advent.Extensions;

namespace Advent.UseCases.Day17;

internal static class Day17Program
{
    internal static List<long> RunProgram(Day17Data data)
    {
        List<long> output = [];
        int programIndex = 0;
        while (programIndex < data.Opcode.Length)
        {
            switch (data.Opcode[programIndex])
            {
                case 0:
                    data.RegisterA = PerformAdv(data, data.Operand[programIndex]);
                    break;
                case 1:
                    data.RegisterB = PerformBxl(data, data.Operand[programIndex]);
                    break;
                case 2:
                    data.RegisterB = PerformBst(data, data.Operand[programIndex]);
                    break;
                case 3:
                    if (data.RegisterA != 0)
                    {
                        programIndex = data.Operand[programIndex];
                        continue;
                    }
                    break;
                case 4:
                    data.RegisterB = PerformBxc(data);
                    break;
                case 5:
                    output.Add(GetComboOperandValue(data, data.Operand[programIndex]).Mod(8));
                    break;
                case 6:

                    data.RegisterB = PerformAdv(data, data.Operand[programIndex]);
                    break;
                case 7:

                    data.RegisterC = PerformAdv(data, data.Operand[programIndex]);
                    break;
            }
            programIndex++;
        }
        return output;
    }

    private static long PerformBxc(Day17Data data)
    {
        // XOR register B with register C
        return data.RegisterB ^ data.RegisterC;
    }

    private static long PerformBst(Day17Data data, int operand)
    {
        // comboOperand modulo 8 then keep only the lowest 3 bits
        long comboOperand = GetComboOperandValue(data, operand);
        return (comboOperand % 8) & 0b111;
    }

    private static long PerformBxl(Day17Data data, int literalOperand)
    {
        // XOR register B with literal operand
        return data.RegisterB ^ literalOperand;
    }

    private static long PerformAdv(Day17Data data, int operand)
    {
        if (operand >= 0 && operand <= 3)
        {
            return data.RegisterA >> operand;
        }
        else
        {
            return data.RegisterA / (long)Math.Pow(2, GetComboOperandValue(data, operand));
        }
    }

    private static long GetComboOperandValue(Day17Data data, int operand)
    {
        return operand switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            3 => 3,
            4 => data.RegisterA,
            5 => data.RegisterB,
            6 => data.RegisterC,
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(operand),
                    operand,
                    "Operand must be between 0 and 6, 7 will not appear in a valid program"
                )
        };
    }
}
