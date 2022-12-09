using static AdventOfCode2022.Day9;

namespace AdventOfCode2022
{
    public static class Day9
    {
        public class Movement
        {
            public Movement(char direction, int steps)
            {
                Direction = direction;
                Steps = steps;
            }

            public char Direction { get; }

            public int Steps { get; }
        }

        public static int GetNumberOfTailPositions(string[] inputLines, int numberOfKnots)
        {
            var movements = GetMovements(inputLines);
            var result = GetNumberOfTailPositions(movements, numberOfKnots);
            return result;
        }

        private static List<Movement> GetMovements(string[] inputLines) =>
            inputLines
                .Select(ParseMovement)
                .ToList();

        private static Movement ParseMovement(string line) =>
            new(line[..1][0], int.Parse(line[2..]));

        private static int GetNumberOfTailPositions(List<Movement> movements, int numberOfKnots)
        {
            var visitedPositions = new HashSet<(int X, int Y)>();

            (int X, int Y) headPosition = new (0, 0);
            var tailPositions = Enumerable.Range(1, numberOfKnots - 1)
                .Select(x =>
                {
                    (int X, int Y) position = new(0, 0);
                    return position;
                })
                .ToList();
            visitedPositions.Add(tailPositions.Last());

            foreach (var movement in movements)
            {
                for (int i = 0; i < movement.Steps; i++)
                {
                    MovePositions(movement.Direction, ref headPosition, tailPositions);
                    visitedPositions.Add(tailPositions.Last());
                }
            }

            return visitedPositions.Count;
        }

        private static void MovePositions(
            char direction,
            ref (int X, int Y) headPosition,
            List<(int X, int Y)> tailPositions)
        {
            switch (direction)
            {
                case 'U':
                    headPosition.Y += 1;
                    for (int i = 0; i < tailPositions.Count; i++)
                    {
                        var tailPosition = tailPositions[i];
                        var previousKnotPosition = i == 0
                            ? headPosition
                            : tailPositions[i - 1];
                        if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.Y))
                        {
                            tailPosition.Y += 1;
                            AlignTailX(previousKnotPosition, ref tailPosition);
                            tailPositions[i] = tailPosition;
                        }
                        else if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.X))
                        {
                            tailPosition.X += (tailPosition.X < previousKnotPosition.X ? 1 : -1);
                            tailPosition.Y += 1;
                            tailPositions[i] = tailPosition;
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case 'D':
                    headPosition.Y -= 1;
                    for (int i = 0; i < tailPositions.Count; i++)
                    {
                        var tailPosition = tailPositions[i];
                        var previousKnotPosition = i == 0
                            ? headPosition
                            : tailPositions[i - 1];
                        if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.Y))
                        {
                            tailPosition.Y -= 1;
                            AlignTailX(previousKnotPosition, ref tailPosition);
                            tailPositions[i] = tailPosition;
                        }
                        else if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.X))
                        {
                            tailPosition.X += (tailPosition.X < previousKnotPosition.X ? 1 : -1);
                            tailPosition.Y -= 1;
                            tailPositions[i] = tailPosition;
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case 'L':
                    headPosition.X -= 1;
                    for (int i = 0; i < tailPositions.Count; i++)
                    {
                        var tailPosition = tailPositions[i];
                        var previousKnotPosition = i == 0
                            ? headPosition
                            : tailPositions[i - 1];
                        if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.X))
                        {
                            tailPosition.X -= 1;
                            AlignTailY(previousKnotPosition, ref tailPosition);
                            tailPositions[i] = tailPosition;
                        }
                        else if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.Y))
                        {
                            tailPosition.Y += (tailPosition.Y < previousKnotPosition.Y ? 1 : -1);
                            tailPosition.X -= 1;
                            tailPositions[i] = tailPosition;
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case 'R':
                    headPosition.X += 1;
                    for (int i = 0; i < tailPositions.Count; i++)
                    {
                        var tailPosition = tailPositions[i];
                        var previousKnotPosition = i == 0
                            ? headPosition
                            : tailPositions[i - 1];
                        if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.X))
                        {
                            tailPosition.X += 1;
                            AlignTailY(previousKnotPosition, ref tailPosition);
                            tailPositions[i] = tailPosition;
                        }
                        else if (TailNeedsToCatchUp(previousKnotPosition, tailPosition, a => a.Y))
                        {
                            tailPosition.Y += (tailPosition.Y < previousKnotPosition.Y ? 1 : -1);
                            tailPosition.X += 1;
                            tailPositions[i] = tailPosition;
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                default:
                    throw new ArgumentException($"{direction} is not valid");
            }
        }

        private static bool TailNeedsToCatchUp(
            (int X, int Y) headPosition,
            (int X, int Y) tailPosition,
            Func<(int X, int Y), int> axisGetter)
            => Math.Abs(axisGetter(headPosition) - axisGetter(tailPosition)) > 1;

        private static void AlignTailX((int X, int Y) headPosition, ref (int X, int Y) tailPosition)
        {
            if (!PositionsAreAligned(headPosition, tailPosition, a => a.X))
            {
                tailPosition.X = headPosition.X;
            }
        }

        private static void AlignTailY((int X, int Y) headPosition, ref (int X, int Y) tailPosition)
        {
            if (!PositionsAreAligned(headPosition, tailPosition, a => a.Y))
            {
                tailPosition.Y = headPosition.Y;
            }
        }

        private static bool PositionsAreAligned(
            (int X, int Y) headPosition,
            (int X, int Y) tailPosition,
            Func<(int X, int Y), int> axisGetter)
            => Math.Abs(axisGetter(headPosition) - axisGetter(tailPosition)) == 0;
    }
}
