namespace AdventOfCode.Year2025;

public static class Day6
{
    public static long GetSumOfAnswers(string[] inputLines)
    {
        var (numbers, operations) = ParseInput(inputLines);

        int rows = numbers.GetLength(0);
        int cols = numbers.GetLength(1);
        long sum = 0;

        for (int col = 0; col < cols; col++)
        {
            long result = operations[col] == '*' ? 1 : 0;

            for (int row = 0; row < rows; row++)
            {
                if (operations[col] == '*')
                {
                    result *= numbers[row, col];
                }
                else
                {
                    result += numbers[row, col];
                }
            }

            sum += result;
        }

        return sum;
    }

    public static long GetSumOfAnswers2(string[] inputLines)
    {
        var (segments, operations) = ParseInput2(inputLines);

        int rows = segments.GetLength(0);
        int cols = segments.GetLength(1);
        long sum = 0;

        for (int col = 0; col < cols; col++)
        {
            int segmentWidth = segments[0, col].Length;
            long result = operations[col] == '*' ? 1 : 0;

            // For each character position (right to left)
            for (int charPos = segmentWidth - 1; charPos >= 0; charPos--)
            {
                // Form a number from digits at this position, skipping spaces
                int newNum = 0;
                bool hasDigit = false;

                for (int row = 0; row < rows; row++)
                {
                    char c = segments[row, col][charPos];
                    if (c != ' ')
                    {
                        newNum = newNum * 10 + (c - '0');
                        hasDigit = true;
                    }
                }

                if (hasDigit)
                {
                    if (operations[col] == '*')
                    {
                        result *= newNum;
                    }
                    else
                    {
                        result += newNum;
                    }
                }
            }

            sum += result;
        }

        return sum;
    }

    private static (int[,] Numbers, char[] Operations) ParseInput(string[] inputLines)
    {
        int rows = inputLines.Length - 1;
        var firstRowValues = inputLines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int cols = firstRowValues.Length;

        var numbers = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var values = inputLines[row].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < cols; col++)
            {
                numbers[row, col] = int.Parse(values[col]);
            }
        }

        var opStrings = inputLines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var operations = opStrings.Select(s => s[0]).ToArray();

        return (numbers, operations);
    }

    private static (string[,] Segments, char[] Operations) ParseInput2(string[] inputLines)
    {
        int numRows = inputLines.Length - 1;
        int lineLength = inputLines[0].Length;

        // Find separator columns (columns where all number rows have a space)
        var separatorCols = new List<int>();
        for (int col = 0; col < lineLength; col++)
        {
            bool allSpaces = true;
            for (int row = 0; row < numRows; row++)
            {
                if (col >= inputLines[row].Length || inputLines[row][col] != ' ')
                {
                    allSpaces = false;
                    break;
                }
            }

            if (allSpaces)
            {
                separatorCols.Add(col);
            }
        }

        // Find groups of consecutive non-separator columns
        var groups = new List<(int Start, int End)>();
        int? groupStart = null;

        for (int col = 0; col <= lineLength; col++)
        {
            bool isSeparator = col == lineLength || separatorCols.Contains(col);

            if (!isSeparator && groupStart == null)
            {
                groupStart = col;
            }
            else if (isSeparator && groupStart != null)
            {
                groups.Add((groupStart.Value, col - 1));
                groupStart = null;
            }
        }

        // Extract raw segments
        int numCols = groups.Count;
        var segments = new string[numRows, numCols];

        for (int groupIdx = 0; groupIdx < groups.Count; groupIdx++)
        {
            var (start, end) = groups[groupIdx];
            for (int row = 0; row < numRows; row++)
            {
                segments[row, groupIdx] = inputLines[row].Substring(start, end - start + 1);
            }
        }

        // Parse operations from last line
        var opStrings = inputLines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var operations = opStrings.Select(s => s[0]).ToArray();

        return (segments, operations);
    }
}
