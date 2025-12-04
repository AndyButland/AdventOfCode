namespace AdventOfCode.Year2025;

public static class Day4
{
    public static int GetNumberOfRollsOfPaper(string[] inputLines)
    {
        int rows, cols;
        char[,] grid;
        LoadGrid(inputLines, out rows, out cols, out grid);

        int count = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] == '@' && CountAdjacentAt(grid, row, col, rows, cols) < 4)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static int GetNumberOfRollsOfPaperThatCanBeRemoved(string[] inputLines)
    {
        int rows, cols;
        char[,] grid;
        LoadGrid(inputLines, out rows, out cols, out grid);

        int totalRemoved = 0;
        bool changed = true;

        while (changed)
        {
            var toRemove = new List<(int row, int col)>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == '@' && CountAdjacentAt(grid, row, col, rows, cols) < 4)
                    {
                        toRemove.Add((row, col));
                    }
                }
            }

            if (toRemove.Count == 0)
            {
                changed = false;
            }
            else
            {
                foreach (var (row, col) in toRemove)
                {
                    grid[row, col] = 'x';
                }

                totalRemoved += toRemove.Count;
            }
        }

        return totalRemoved;
    }

    private static void LoadGrid(string[] inputLines, out int rows, out int cols, out char[,] grid)
    {
        rows = inputLines.Length;
        cols = inputLines[0].Length;
        grid = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                grid[row, col] = inputLines[row][col];
            }
        }
    }

    private static int CountAdjacentAt(char[,] grid, int row, int col, int rows, int cols)
    {
        int count = 0;
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;

                int newRow = row + dr;
                int newCol = col + dc;

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow, newCol] == '@')
                {
                    count++;
                }
            }
        }
        return count;
    }
}
