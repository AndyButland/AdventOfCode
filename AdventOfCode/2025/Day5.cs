namespace AdventOfCode.Year2025;

public static class Day5
{
    public static long GetNumberOfAvailableFreshIngredients(string[] inputLines)
    {
        var (freshRanges, availableIngredients) = ParseInput(inputLines);

        int freshCount = 0;
        foreach (var availableIngredient in availableIngredients)
        {
            if (freshRanges.Any(r => availableIngredient >= r.Start && availableIngredient <= r.End))
            {
                freshCount++;
            }
        }

        return freshCount;
    }

    public static long GetAllIngredientsConsideredFresh(string[] inputLines)
    {
        var (freshRanges, _) = ParseInput(inputLines);

        // Sort ranges by start
        var sortedRanges = freshRanges.OrderBy(r => r.Start).ToList();

        // Merge overlapping ranges
        var mergedRanges = new List<(long Start, long End)>();
        var current = sortedRanges[0];

        for (int i = 1; i < sortedRanges.Count; i++)
        {
            var next = sortedRanges[i];
            if (next.Start <= current.End + 1)
            {
                // Overlapping or adjacent - merge
                current = (current.Start, Math.Max(current.End, next.End));
            }
            else
            {
                // No overlap - add current and start new
                mergedRanges.Add(current);
                current = next;
            }
        }
        mergedRanges.Add(current);

        // Count distinct integers across all merged ranges
        return mergedRanges.Sum(r => r.End - r.Start + 1);
    }

    private static (List<(long Start, long End)> FreshRanges, List<long> AvailableIngredients) ParseInput(string[] inputLines)
    {
        var freshRanges = new List<(long Start, long End)>();
        var availableIngredients = new List<long>();

        int blankLineIndex = Array.IndexOf(inputLines, string.Empty);

        // Parse fresh ingredient ranges (before blank line)
        for (int i = 0; i < blankLineIndex; i++)
        {
            var parts = inputLines[i].Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            freshRanges.Add((start, end));
        }

        // Parse available ingredients (after blank line)
        for (int i = blankLineIndex + 1; i < inputLines.Length; i++)
        {
            availableIngredients.Add(long.Parse(inputLines[i]));
        }

        return (freshRanges, availableIngredients);
    }
}
