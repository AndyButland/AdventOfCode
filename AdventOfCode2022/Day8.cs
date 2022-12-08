namespace AdventOfCode2022
{
    public static class Day8
    {
        private enum Direction
        {
            NS,
            EW
        }

        private enum Movement
        {
            Up,
            Down
        }

        public static int GetNumberOfVisibleTrees(string[] inputLines)
        {
            var grid = CreateGrid(inputLines);
            var result = GetVisibleTreesInGrid(grid);
            return result;
        }

        public static int GetHighestScenicScore(string[] inputLines)
        {
            var grid = CreateGrid(inputLines);
            var result = GetHighestScenicScoreInGrid(grid);
            return result;
        }

        private static List<List<int>> CreateGrid(string[] inputLines)
        {
            var grid = new List<List<int>>();
            foreach (var line in inputLines)
            {
                var row = new List<int>();
                foreach (var c in line)
                {
                    row.Add((int)char.GetNumericValue(c));
                }

                grid.Add(row);
            }

            return grid;
        }

        private static int GetVisibleTreesInGrid(List<List<int>> grid)
        {
            var result = 0;
            var rowIndex = 0;
            foreach (var row in grid)
            {
                if (IsOnEdge(rowIndex, grid.Count))
                {
                    result += grid[0].Count;
                }
                else
                {
                    var colIndex = 0;
                    foreach (var col in row)
                    {
                        if (IsOnEdge(colIndex, row.Count) || IsVisible(grid, rowIndex, colIndex))
                        {
                            result += 1;
                        }

                        colIndex++;
                    }
                }

                rowIndex++;
            }

            return result;
        }

        private static bool IsOnEdge(int index, int length) => index == 0 || index == length - 1;

        private static bool IsVisible(List<List<int>> grid, int rowIndex, int colIndex)
        {
            var value = grid[rowIndex][colIndex];

            var visibleWest = IsVisibleInDirection(grid, grid[0].Count, value, Direction.EW, Movement.Down, colIndex, rowIndex);
            var visibleEast = IsVisibleInDirection(grid, grid[0].Count, value, Direction.EW, Movement.Up, colIndex, rowIndex);
            var visibleNorth = IsVisibleInDirection(grid, grid.Count, value, Direction.NS, Movement.Down, rowIndex, colIndex);
            var visibleSouth = IsVisibleInDirection(grid, grid.Count, value, Direction.NS, Movement.Up, rowIndex, colIndex);

            return visibleWest || visibleEast || visibleNorth || visibleSouth;
        }

        private static bool IsVisibleInDirection(List<List<int>> grid, int length, int value, Direction direction, Movement movement, int indexInDirection, int indexInOtherDirection)
        {
            for (int i = GetLoopStart(indexInDirection, movement);
                HasLoopCompleted(movement, i, length);
                i += GetLoopIncrement(movement))
            {
                var gridValue = GetValueAtPosition(grid, direction, indexInOtherDirection, i);
                if (gridValue >= value)
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetLoopStart(int index, Movement movement) => index + (movement == Movement.Up ? 1 : -1);

        private static bool HasLoopCompleted(Movement movement, int i, int length) => (movement == Movement.Up && i < length) || (movement == Movement.Down && i >= 0);

        private static int GetLoopIncrement(Movement movement) => movement == Movement.Up ? 1 : -1;

        private static int GetValueAtPosition(List<List<int>> grid, Direction direction, int indexInOtherDirection, int i) =>
            grid[direction == Direction.EW ? indexInOtherDirection : i][direction == Direction.EW ? i : indexInOtherDirection];

        private static int GetHighestScenicScoreInGrid(List<List<int>> grid)
        {
            var result = 0;
            var rowIndex = 0;
            foreach (var row in grid)
            {
                var colIndex = 0;
                foreach (var col in row)
                {
                    var scoreForPosition = GetScoreForPosition(grid, rowIndex, colIndex);
                    if (scoreForPosition > result)
                    {
                        result = scoreForPosition;
                    }

                    colIndex++;
                }

                rowIndex++;
            }

            return result;
        }

        private static int GetScoreForPosition(List<List<int>> grid, int rowIndex, int colIndex)
        {
            var value = grid[rowIndex][colIndex];

            var scoreWest = GetScoreInDirection(grid, grid[0].Count, value, Direction.EW, Movement.Down, colIndex, rowIndex);
            var scoreeEast = GetScoreInDirection(grid, grid[0].Count, value, Direction.EW, Movement.Up, colIndex, rowIndex);
            var scoreNorth = GetScoreInDirection(grid, grid.Count, value, Direction.NS, Movement.Down, rowIndex, colIndex);
            var scoreSouth = GetScoreInDirection(grid, grid.Count, value, Direction.NS, Movement.Up, rowIndex, colIndex);

            return scoreWest * scoreeEast * scoreNorth * scoreSouth;
        }

        private static int GetScoreInDirection(List<List<int>> grid, int length, int value, Direction direction, Movement movement, int indexInDirection, int indexInOtherDirection)
        {
            var treeCount = 0;
            for (int i = GetLoopStart(indexInDirection, movement);
                HasLoopCompleted(movement, i, length);
                i += GetLoopIncrement(movement))
            {
                treeCount++;
                var gridValue = GetValueAtPosition(grid, direction, indexInOtherDirection, i);
                if (gridValue >= value)
                {
                    break;
                }
            }

            return treeCount;
        }
    }
}
