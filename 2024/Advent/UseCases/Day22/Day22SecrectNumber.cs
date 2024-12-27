namespace Advent.UseCases.Day22;

internal static class Day22SecrectNumber
{
    private const int PRUNE = 16777216;

    internal static long GenerateSecretNumber(long seed)
    {
        seed = (seed << 6) ^ seed; // multiply by 64 and XOR
        long pruned = seed % PRUNE;

        seed = (pruned >> 5) ^ pruned; // divide by 32 and XOR
        pruned = seed % PRUNE;

        seed = (pruned << 11) ^ pruned; // multiply by 2048 and XOR
        return seed % PRUNE;
    }
}
