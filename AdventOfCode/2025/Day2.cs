namespace AdventOfCode.Year2025;

public static class Day2
{
    public static long SumInvalidIdsPart1(string inputData)
    {
        var ranges = ParseIdRanges(inputData);
        long total = 0;

        foreach (var range in ranges)
        {
            for (var id = range.Start; id <= range.End; id++)
            {
                if (IsRepeatedSequence(id))
                {
                    total += id;
                }
            }
        }

        return total;
    }

    public static long SumInvalidIdsPart2(string inputData)
    {
        var ranges = ParseIdRanges(inputData);
        long total = 0;

        foreach (var range in ranges)
        {
            for (var id = range.Start; id <= range.End; id++)
            {
                if (IsRepeatedSequenceAtLeastTwice(id))
                {
                    total += id;
                }
            }
        }

        return total;
    }

    private static List<IdRange> ParseIdRanges(string inputData) =>
        inputData
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(part =>
            {
                var trimmed = part.Trim();
                var dashIndex = trimmed.IndexOf('-');
                var start = long.Parse(trimmed[..dashIndex]);
                var end = long.Parse(trimmed[(dashIndex + 1)..]);
                return new IdRange(start, end);
            })
            .ToList();

    private static bool IsRepeatedSequence(long id)
    {
        var str = id.ToString();
        if (str.Length % 2 != 0)
        {
            return false;
        }

        var half = str.Length / 2;
        return str[..half] == str[half..];
    }

    private static bool IsRepeatedSequenceAtLeastTwice(long id)
    {
        var str = id.ToString();
        var len = str.Length;

        for (var patternLen = 1; patternLen <= len / 2; patternLen++)
        {
            if (len % patternLen != 0)
            {
                continue;
            }

            var pattern = str[..patternLen];
            var isMatch = true;

            for (var i = patternLen; i < len; i += patternLen)
            {
                if (str.Substring(i, patternLen) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                return true;
            }
        }

        return false;
    }

    public record IdRange(long Start, long End);
}
