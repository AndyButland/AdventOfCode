namespace AdventOfCode.Year2023;

public static class Day1
{
    private static readonly Dictionary<string, int> NumbersMap = new Dictionary<string, int>()
    {
        { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 },
        { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
    };

    public static int GetSumOfCalibrationValues(string[] inputLines) =>
        inputLines
            .ToList()
            .Select(x => CombineDigits(GetFirstDigit(x), GetLastDigit(x)))
            .Sum();

    private static int GetFirstDigit(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (int.TryParse(line[i].ToString(), out int parsedDigit))
            {
                return parsedDigit;
            }

            foreach (var item in NumbersMap)
            {
                if (item.Key.Length > line.Length - i)
                {
                    continue;
                }

                if (item.Key == line.Substring(i, item.Key.Length))
                {
                    return item.Value;
                }
            }
        }

        throw new InvalidOperationException($"Could not find first digit in line {line}");
    }

    private static int GetLastDigit(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (int.TryParse(line[i].ToString(), out int parsedDigit))
            {
                return parsedDigit;
            }

            foreach (var item in NumbersMap)
            {
                if (i + 1 - item.Key.Length < 0)
                {
                    continue;
                }

                if (item.Key == line.Substring(i + 1 - item.Key.Length, item.Key.Length))
                {
                    return item.Value;
                }
            }
        }

        throw new InvalidOperationException($"Could not find last digit in line {line}");
    }

    private static int CombineDigits(int v1, int v2) => int.Parse(v1.ToString() + v2.ToString());
}