using System.Diagnostics;

namespace AdventOfCode.Year2025;

public static class Day7
{
    public static long CountNumberOfBeamSplits(string[] inputLines)
    {
        int rows, cols;
        char[,] grid;
        PopulateGrid(inputLines, out rows, out cols, out grid);

        int splitCount = 0;

        // Process the grid row by row
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                char current = grid[row, col];
                char above = row > 0 ? grid[row - 1, col] : ' ';

                if (current == '.' && (above == 'S' || above == '|'))
                {
                    grid[row, col] = '|';
                }
                else if (current == '^' && (above == 'S' || above == '|'))
                {
                    // Change left and right to '|' if within bounds
                    if (col > 0)
                    {
                        grid[row, col - 1] = '|';
                    }
                    if (col < cols - 1)
                    {
                        grid[row, col + 1] = '|';
                    }

                    splitCount++;
                }
            }

            PrintGrid(grid, $"Grid after processing row index: {row}");
        }

        return splitCount;
    }
    public static long GetNumberOfTimelines(string[] inputLines)
    {
        int rows, cols;
        char[,] grid;
        PopulateGrid(inputLines, out rows, out cols, out grid);

        // Find the starting position (S)
        int startCol = -1;
        for (int col = 0; col < cols; col++)
        {
            if (grid[0, col] == 'S')
            {
                startCol = col;
                break;
            }
        }

        // DP approach: track count of timelines for each unique beam configuration
        // Key = sorted comma-separated column positions, Value = number of timelines with this config
        var configurations = new Dictionary<string, long>
        {
            [ConfigKey(new HashSet<int> { startCol })] = 1
        };

        for (int row = 1; row < rows; row++)
        {
            var newConfigurations = new Dictionary<string, long>();

            foreach (var kvp in configurations)
            {
                var beamCols = ParseConfigKey(kvp.Key);
                long timelineCount = kvp.Value;

                // Find splits and continuing beams
                var newBeams = new HashSet<int>();
                var splits = new List<int>();

                foreach (int col in beamCols)
                {
                    char current = grid[row, col];
                    if (current == '.')
                    {
                        newBeams.Add(col);
                    }
                    else if (current == '^')
                    {
                        splits.Add(col);
                    }
                }

                if (splits.Count == 0)
                {
                    // No splits, propagate all timelines to new configuration
                    AddToConfig(newConfigurations, newBeams, timelineCount);
                }
                else
                {
                    // Branch for each combination of left/right choices
                    int numCombinations = 1 << splits.Count;
                    for (int combo = 0; combo < numCombinations; combo++)
                    {
                        var branchBeams = new HashSet<int>(newBeams);

                        for (int i = 0; i < splits.Count; i++)
                        {
                            int splitCol = splits[i];
                            bool goLeft = (combo & (1 << i)) == 0;

                            if (goLeft && splitCol > 0)
                            {
                                branchBeams.Add(splitCol - 1);
                            }
                            else if (!goLeft && splitCol < cols - 1)
                            {
                                branchBeams.Add(splitCol + 1);
                            }
                        }

                        AddToConfig(newConfigurations, branchBeams, timelineCount);
                    }
                }
            }

            configurations = newConfigurations;
        }

        // Sum all timeline counts
        long total = 0;
        foreach (var count in configurations.Values)
        {
            total += count;
        }
        return total;
    }

    private static string ConfigKey(HashSet<int> cols)
    {
        return string.Join(",", cols.OrderBy(c => c));
    }

    private static HashSet<int> ParseConfigKey(string key)
    {
        if (string.IsNullOrEmpty(key))
            return new HashSet<int>();
        return new HashSet<int>(key.Split(',').Select(int.Parse));
    }

    private static void AddToConfig(Dictionary<string, long> configs, HashSet<int> beams, long count)
    {
        string key = ConfigKey(beams);
        if (!configs.ContainsKey(key))
            configs[key] = 0;
        configs[key] += count;
    }


    private static void PopulateGrid(string[] inputLines, out int rows, out int cols, out char[,] grid)
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

    private static void PrintGrid(char[,] grid, string message)
    {
        Trace.WriteLine(message);
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Trace.Write(grid[row, col]);
            }

            Trace.WriteLine(string.Empty);
        }

        Trace.WriteLine(string.Empty);
    }
}
