namespace Advent.UseCases.Day4;

public static class Day4Helpers
{
    public static int[] ComputeDiagDecIndexes(int i, int length, int columns)
    {
        int[] indexes = new int[length];
        for (int j = 0; j < length; j++)
        {
            indexes[j] = i + (columns * j) + j;
        }
        return indexes;
    }

    public static int[] ComputeDiagIncIndexes(int i, int length, int columns)
    {
        int[] indexes = new int[length];
        for (int j = 0; j < length; j++)
        {
            indexes[j] = i + (columns * j) - j;
        }
        return indexes;
    }

    public static int[] ComputeHorizontalIndexes(int i, int length)
    {
        int[] indexes = new int[length];
        for (int j = 0; j < length; j++)
        {
            indexes[j] = i + j;
        }
        return indexes;
    }

    public static int[] ComputeVerticalIndexes(int i, int length, int columns)
    {
        int[] indexes = new int[length];
        for (int j = 0; j < length; j++)
        {
            indexes[j] = i + (columns * j);
        }
        return indexes;
    }
}
