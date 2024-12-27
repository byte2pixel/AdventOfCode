namespace Advent.UseCases.Day7;

internal class Day7Part2Solver : IDay7Solver
{
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

    private static ulong FindValidEquationResult(uint[] values, ulong targetProduct)
    {
        int operatorCount = values.Length - 1;

        // Generate all possible operator combinations (+, *, |)
        for (
            int operatorConfiguration = 0;
            operatorConfiguration < Math.Pow(3, operatorCount);
            operatorConfiguration++
        )
        {
            // Convert the input values to ulong so they can hold larger numbers
            ulong[] calculationValues = Array.ConvertAll(values, x => (ulong)x);

            char[] operators = GenerateOperators(operatorConfiguration, operatorCount);

            ulong result = CalculateEquationResult(calculationValues, operators);

            if (result == targetProduct)
            {
                return result;
            }
        }

        return 0;
    }

    /// <summary>
    /// Generate the operators based on the configuration
    /// 0 = '+'
    /// 1 = '*'
    /// 2 = '|'
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="operatorCount"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <example>
    /// GenerateOperators(0, 3) => ['+', '+', '+']
    /// GenerateOperators(1, 3) => ['+', '+', '*']
    /// GenerateOperators(2, 3) => ['+', '+', '|']
    /// GenerateOperators(3, 3) => ['+', '*', '+']
    /// GenerateOperators(4, 3) => ['+', '*', '*']
    /// GenerateOperators(5, 3) => ['+', '*', '|']
    /// </example>
    private static char[] GenerateOperators(int configuration, int operatorCount)
    {
        // array to store the operators generated from the configuration
        char[] operators = new char[operatorCount];
        int remainingConfig = configuration;

        for (int operatorIndex = 0; operatorIndex < operatorCount; operatorIndex++)
        {
            int operatorType = remainingConfig % 3; // 0 = '+', 1 = '*', 2 = '|'
            operators[operatorIndex] = operatorType switch
            {
                0 => '+',
                1 => '*',
                2 => '|',
                _ => throw new InvalidOperationException("Invalid operator type")
            };
            remainingConfig /= 3; // Move to the next operator
        }

        return operators; // return the generated operators to be used in the calculation
    }

    /// <summary>
    /// Calculate the result of the equation using the given values and operators
    /// Ignore the order of operations, just calculate from left to right
    /// The result stored in the next value in the array to be used in the next calculation
    /// The last value in the array is the result of the equation
    /// </summary>
    /// <param name="values">the values to use in the calculation</param>
    /// <param name="operators">the operators to use in the calculation</param>
    /// <returns>the result of the equation</returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <example>
    /// CalculateEquationResult([1, 2, 3], ['+', '|']) => 1+2 = 3 | 3 = 33
    /// CalculateEquationResult([5, 6, 7], ['|', '|']) => 5 | 6 | 7 = 567
    /// CalculateEquationResult([5, 6, 7], ['|', '+']) => 56+7 = 63
    /// CalculateEquationResult([5, 6, 7], ['|', '*']) => 56*7 = 392
    /// CalculateEquationResult([5, 6, 7], ['+', '|']) => 5+6 = 11 | 7 = 117
    /// </example>
    private static ulong CalculateEquationResult(ulong[] values, char[] operators)
    {
        for (int operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
        {
            ulong currentResult = operators[operatorIndex] switch
            {
                '+' => values[operatorIndex] + values[operatorIndex + 1],
                '*' => values[operatorIndex] * values[operatorIndex + 1],
                '|'
                    => ulong.Parse(
                        values[operatorIndex].ToString() + values[operatorIndex + 1].ToString()
                    ),
                _ => throw new InvalidOperationException("Invalid operator")
            };

            values[operatorIndex + 1] = currentResult;
        }

        return values[^1];
    }
}
