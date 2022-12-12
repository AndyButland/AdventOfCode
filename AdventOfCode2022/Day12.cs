using System.Text;

namespace AdventOfCode2022
{
    public static class Day12
    {
        public class TrackedPosition
        {
            public TrackedPosition((int X, int Y) position)
            {
                Position = position;
            }

            public TrackedPosition((int X, int Y) position, int pathLength)
                : this(position)
            {
                PathLength = pathLength;
            }

            public (int X, int Y) Position { get; }

            public int PathLength { get; }
        }

        public static long GetFewestStepsToDestination(string[] inputLines)
        {
            var grid = GetGrid(inputLines);
            var startPosition = GetStartPosition(grid);
            return GetFewestStepsToDestination(grid, startPosition);
        }

        public static long GetFewestStepsToDestination(List<List<char>> grid, TrackedPosition startPosition)
        {
            var trackedPosition = startPosition;

            var searched = new HashSet<(int X, int Y)>() { trackedPosition.Position };
            var queue = new Queue<TrackedPosition>();
            AddPathsToQueue(trackedPosition, grid, queue);

            var pathLength = -1;
            while (queue.TryDequeue(out trackedPosition))
            {
                if (searched.Contains(trackedPosition.Position))
                {
                    continue;
                }

                if (grid[trackedPosition.Position.Y][trackedPosition.Position.X] == 'E')
                {
                    pathLength = trackedPosition.PathLength;
                    break;
                }

                AddPathsToQueue(trackedPosition, grid, queue);
                searched.Add(trackedPosition.Position);
            }

            // var display = GetGridDisplay(grid, searched);

            return pathLength;
        }

        public static long GetFewestStepsFromAnyLowestElevationToDestination(string[] inputLines)
        {
            var grid = GetGrid(inputLines);
            var startPositions = GetAllStartPositions(grid);

            var pathLengths = new List<long>();
            foreach (var startPosition in startPositions)
            {
                var pathLength = GetFewestStepsToDestination(grid, startPosition);
                if (pathLength > -1)
                {
                    pathLengths.Add(pathLength);
                }
            }
            
            return pathLengths.Min();
        }

        private static List<List<char>> GetGrid(string[] inputLines)
        {
            var grid = new List<List<char>>();
            foreach (var line in inputLines)
            {
                grid.Add(line.ToCharArray().ToList());
            }

            return grid;
        }

        private static List<TrackedPosition> GetAllStartPositions(List<List<char>> grid)
        {
            var result = new List<TrackedPosition>();
            var y = 0;
            foreach (var row in grid)
            {
                var x = 0;
                foreach (var c in row)
                {
                    if (c == 'S' || c == 'a')
                    {
                        result.Add(new TrackedPosition((x, y)));
                    }

                    x++;
                }

                y++;
            }

            return result;
        }

        private static TrackedPosition GetStartPosition(List<List<char>> grid)
        {
            var y = 0;
            foreach (var row in grid)
            {
                var x = 0;
                foreach (var c in row)
                {
                    if (c == 'S')
                    {
                        return new TrackedPosition((x, y));
                    }

                    x++;
                }

                y++;
            }

            throw new InvalidOperationException("Could not find start position.");
        }

        private static void AddPathsToQueue(TrackedPosition trackedPosition, List<List<char>> grid, Queue<TrackedPosition> queue)
        {
            var position = trackedPosition.Position;
            var pathLength = trackedPosition.PathLength + 1;
            var currentPositionElevation = grid[position.Y][position.X];

            char? positionNorth = position.Y > 0 ? grid[position.Y - 1][position.X] : null;
            char? positionEast = position.X < grid[0].Count - 1 ? grid[position.Y][position.X + 1] : null;
            char? positionSouth = position.Y < grid.Count - 1 ? grid[position.Y + 1][position.X] : null;
            char? positionWest = position.X > 0 ? grid[position.Y][position.X - 1] : null;

            if (IsInRange(positionNorth, currentPositionElevation))
            {
                queue.Enqueue(new TrackedPosition((position.X, position.Y - 1), pathLength));
            }

            if (IsInRange(positionEast, currentPositionElevation))
            {
                queue.Enqueue(new TrackedPosition((position.X + 1, position.Y), pathLength));
            }

            if (IsInRange(positionSouth, currentPositionElevation))
            {
                queue.Enqueue(new TrackedPosition((position.X, position.Y + 1), pathLength));
            }

            if (IsInRange(positionWest, currentPositionElevation))
            {
                queue.Enqueue(new TrackedPosition((position.X - 1, position.Y), pathLength));
            }
        }

        private static bool IsInRange(char? neighbourElevation, char currentPositionElevation)
        {
            if (!neighbourElevation.HasValue)
            {
                return false;
            }

            if (currentPositionElevation == 'S')
            {
                currentPositionElevation = 'a';
            }

            if (neighbourElevation.Value == 'S')
            {
                neighbourElevation = 'a';
            }

            const string Chars = "abcdefghijklmnopqrstuvwxyzE";
            var neighbourIndex = Chars.IndexOf(neighbourElevation.Value);
            var currentIndex = Chars.IndexOf(currentPositionElevation);
            if (neighbourIndex == -1 || currentIndex == -1)
            {
                throw new InvalidOperationException($"Could not find index of {neighbourElevation.Value} or {currentPositionElevation}");
            }

            return neighbourIndex - currentIndex <= 1;
        }

        private static string GetGridDisplay(List<List<char>> grid, HashSet<(int X, int Y)> searched)
        {
            var sb = new StringBuilder();
            var y = 0;
            foreach (var row in grid)
            {
                var x = 0;
                foreach (var c in row)
                {
                    if (c == 'S' || c == 'E')
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        (int X, int Y) position = (x, y);
                        sb.Append(searched.Contains(position) ? 'v' : '.');
                    }

                    x++;
                }

                sb.AppendLine();
                y++;
            }

            return sb.ToString();
        }
    }
}


