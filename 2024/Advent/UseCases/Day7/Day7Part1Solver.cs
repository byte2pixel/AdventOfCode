using System.Data;
using Spectre.Console;

namespace Advent.UseCases.Day7;

public class Day7Part1Solver : IDay7Solver
{
    public ulong Solve((ulong, uint[])[] input)
    {
        ulong sum = 0;
        foreach (var (product, equationValues) in input)
        {
            // add or multiply the values in the equationValues array
            // to try to match the product
            var operatorCount = equationValues.Length - 1;
            for (int i = 0; i < Math.Pow(2, operatorCount); i++)
            {
                // create a copy of the equationValues array
                var eqCopy = new ulong[equationValues.Length];
                equationValues.CopyTo(eqCopy, 0);
                var binaryString = Convert.ToString(i, 2).PadLeft(operatorCount, '0');
                var operators = binaryString.Select(c => c == '0' ? '+' : '*').ToArray();
                ulong result = 0;
                for (int j = 0; j < operators.Length; j++)
                {
                    if (operators[j] == '+')
                    {
                        ulong value = eqCopy[j] + eqCopy[j + 1];
                        result = value;
                        eqCopy[j + 1] = value;
                    }
                    else if (operators[j] == '*')
                    {
                        ulong value = eqCopy[j] * eqCopy[j + 1];
                        result = value;
                        eqCopy[j + 1] = value;
                    }
                }
                if (result == product)
                {
                    sum += result;
                    break;
                }
            }
        }
        return sum;
    }
}
