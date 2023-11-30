using System.Diagnostics;

namespace AdventOfCode.Year2022;

public static class Day4
{
    public enum ContainCheck
    {
        FullyContains,
        Overlaps
    }

    public static int GetNumberOfContainingRanges(string[] inputLines, ContainCheck containCheck)
    {
        var total = 0;
        foreach (var line in inputLines)
        {
            var ranges = GetRanges(line);
            if (DoesOneRangeContainTheOther(ranges, containCheck))
            {
                total += 1;
            }
        }

        return total;
    }

    private static (string Range1, string Range2) GetRanges(string line)
    {
        var parts = line.Split(',');
        return new(parts[0], parts[1]);
    }

    private static bool DoesOneRangeContainTheOther((string Range1, string Range2) ranges, ContainCheck containCheck)
    {
        var expandedRange1 = ExpandRange(ranges.Range1);
        var expandedRange2 = ExpandRange(ranges.Range2);
        return RangeContains(expandedRange1, expandedRange2, containCheck) ||
            RangeContains(expandedRange2, expandedRange1, containCheck);
    }
    private static bool RangeContains(IEnumerable<int> containingRange, IEnumerable<int> containedRange, ContainCheck containCheck) =>
        containCheck == ContainCheck.FullyContains
            ? containedRange.All(x => containingRange.Contains(x))
            : containedRange.Any(x => containingRange.Contains(x));

    private static IEnumerable<int> ExpandRange(string range)
    {
        var parts = range.Split('-');
        var start = int.Parse(parts[0]);
        var finish = int.Parse(parts[1]);
        return Enumerable.Range(start, finish - start + 1);
    }
}