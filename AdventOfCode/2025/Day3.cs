namespace AdventOfCode.Year2025;

public static class Day3
{
    public static long GetTotalOutputJoltageForTwoDigits(string[] inputLines) => GetTotalOutputJoltage(inputLines, numberOfDigits: 2);

    public static long GetTotalOutputJoltageForTwelveDigits(string[] inputLines) => GetTotalOutputJoltage(inputLines, numberOfDigits: 12);

    private static long GetTotalOutputJoltage(string[] inputLines, int numberOfDigits)
    {
        long total = 0;

        foreach (var line in inputLines)
        {
            var largest = GetLargestNumber(line, numberOfDigits, 0);
            total += largest;
        }

        return total;
    }

    private static long GetLargestNumber(string line, int numberOfDigits, int startIndex)
    {
        long result = 0;
        var position = startIndex;

        for (var digitIndex = 0; digitIndex < numberOfDigits; digitIndex++)
        {
            var digitsRemaining = numberOfDigits - digitIndex - 1;
            var searchEnd = line.Length - digitsRemaining;

            var maxDigit = 0;
            var maxPosition = position;

            for (var i = position; i < searchEnd; i++)
            {
                var digit = line[i] - '0';
                if (digit > maxDigit)
                {
                    maxDigit = digit;
                    maxPosition = i;
                }
            }

            result = result * 10 + maxDigit;
            position = maxPosition + 1;
        }

        return result;
    }
}
