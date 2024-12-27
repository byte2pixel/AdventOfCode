namespace Advent.UseCases.Day7;

internal class Day7Part1Solver : IDay7Solver
{
    /// <summary>
    /// Solve the equations and return the sum of the valid results
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public ulong Solve((ulong, uint[])[] input)
    {
        ulong totalSum = 0;
        foreach (var (targetProduct, equationValues) in input)
        {
            ulong validEquationResult = FindValidEquationResult(equationValues, targetProduct);
            totalSum += validEquationResult;
        }
        return totalSum;
    }

    /// <summary>
    /// Find the valid result of the equation that matches the target product
    /// try all possible operator combinations (+ or *)
    /// </summary>
    /// <param name="values"></param>
    /// <param name="targetProduct"></param>
    /// <returns></returns>
    private static ulong FindValidEquationResult(uint[] values, ulong targetProduct)
    {
        int operatorCount = values.Length - 1; // if there are 3 values, there are 2 operators

        // Generate all possible operator combinations (+ or *)
        for (
            int operatorConfiguration = 0;
            operatorConfiguration < Math.Pow(2, operatorCount); // 2^operatorCount
                operatorConfiguration++
        )
        {
            ulong[] calculationValues = Array.ConvertAll(values, x => (ulong)x);
            char[] operators = GenerateOperators(operatorConfiguration, operatorCount);

            ulong result = CalculateEquationResult(calculationValues, operators);

            // If the result is the target product, stop and return the result
            if (result == targetProduct)
            {
                return result;
            }
        }

        return 0;
    }

    /// <summary>
    /// Calculate the result of the equation using the given values and operators
    /// Ignore the order of operations, just calculate from left to right
    /// The result stored in the next value in the array to be used in the next calculation
    /// The last value in the array is the result of the equation
    /// </summary>
    /// <param name="values"></param>
    /// <param name="operators"></param>
    /// <returns></returns>
    private static ulong CalculateEquationResult(ulong[] values, char[] operators)
    {
        for (int operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
        {
            ulong currentResult =
                operators[operatorIndex] == '+'
                    ? values[operatorIndex] + values[operatorIndex + 1]
                    : values[operatorIndex] * values[operatorIndex + 1];

            values[operatorIndex + 1] = currentResult; // store the result in the next value
        }

        return values[^1]; // last value in the array is the result
    }

    /// <summary>
    /// Generate the operators to use in the calculation based on the configuration
    /// 0 = +, 1 = *
    /// by checking the bit at the index, we can determine the operator to use
    /// </summary>
    /// <param name="configuration">the configuration of the operators</param>
    /// <param name="operatorCount">the number of operators needed for the equation</param>
    /// <returns>array of operators to try</returns>
    /// <example>
    /// GenerateOperators(0, 3) => ['+', '+', '+']
    /// GenerateOperators(1, 3) => ['*', '+', '+']
    /// GenerateOperators(2, 3) => ['+', '*', '+']
    private static char[] GenerateOperators(int configuration, int operatorCount)
    {
        char[] operators = new char[operatorCount];

        for (int bitIndex = 0; bitIndex < operatorCount; bitIndex++)
        {
            operators[bitIndex] = ((configuration & (1 << bitIndex)) != 0) ? '*' : '+';
        }

        return operators; // returns the operators to use in the calculation
    }
}
