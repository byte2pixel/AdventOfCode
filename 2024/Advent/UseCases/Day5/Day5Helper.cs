namespace Advent.UseCases.Day5;

#pragma warning disable S3267 // "IEnumerable" LINQs should be simplified
public static class Day5Helper
{
    public static bool AlreadyFollowingRules(HashSet<int> previousPages, List<int> rules)
    {
        foreach (int rule in rules)
        {
            if (previousPages.Contains(rule))
            {
                return false;
            }
        }
        return true;
    }
}
#pragma warning restore S3267
