using System.Text;

namespace AdventOfCode.Year2022;

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
                headPosition = MoveHeadPosition(movement.Direction, headPosition, tailPositions);
                visitedPositions.Add(tailPositions.Last());
            }

            // For debug:
            // var display = GetRopeDisplay(headPosition, tailPositions);
        }

        return visitedPositions.Count;
    }

    private static (int X, int Y) MoveHeadPosition(
        char direction,
        (int X, int Y) headPosition,
        List<(int X, int Y)> tailPositions)
    {
        switch (direction)
        {
            case 'U':
                headPosition.Y += 1;
                break;
            case 'D':
                headPosition.Y -= 1;
                break;
            case 'R':
                headPosition.X += 1;
                break;
            case 'L':
                headPosition.X -= 1;
                break;
            default:
                throw new ArgumentException($"{direction} is not valid");
        }

        for (int i = 0; i < tailPositions.Count; i++)
        {
            var tailPosition = tailPositions[i];
            var previousKnotPosition = GetPreviousKnotPosition(i, headPosition, tailPositions);

            if (!ArePositionsTouching(tailPosition, previousKnotPosition))
            {
                tailPosition = MoveTailPosition(tailPosition, previousKnotPosition);
            }

            tailPositions[i] = tailPosition;
        }

        return headPosition;
    }

    private static (int X, int Y) GetPreviousKnotPosition(int i, (int X, int Y) headPosition, List<(int X, int Y)> tailPositions) =>
        i == 0
            ? headPosition
            : tailPositions[i - 1];

    private static bool ArePositionsTouching((int X, int Y) position1, (int X, int Y) position2) =>
        Math.Abs(position2.X - position1.X) <= 1 && Math.Abs(position2.Y - position1.Y) <= 1;

    private static (int X, int Y) MoveTailPosition((int X, int Y) tailPosition, (int X, int Y) previousKnotPosition)
    {
        if (previousKnotPosition.X > tailPosition.X)
        {
            tailPosition.X += 1;
        }
        else if (previousKnotPosition.X < tailPosition.X)
        {
            tailPosition.X -= 1;
        }

        if (previousKnotPosition.Y > tailPosition.Y)
        {
            tailPosition.Y += 1;
        }
        else if (previousKnotPosition.Y < tailPosition.Y)
        {
            tailPosition.Y -= 1;
        }

        return tailPosition;
    }

    private static string GetRopeDisplay((int X, int Y) headPosition, List<(int X, int Y)> tailPositions)
    {
        var grid = new List<List<char>>();
        for (int y = 50; y >= -50; y--)
        {
            var row = new List<char>();
            for (int x = -50; x <= 50; x++)
            {
                if (headPosition.X == x && headPosition.Y == y)
                {
                    row.Add('H');
                }
                else
                {
                    var tailNumber = 1;
                    var addedTailPosition = false;
                    foreach (var tailPosition in tailPositions)
                    {
                        if (tailPosition.X == x && tailPosition.Y == y)
                        {
                            row.Add(tailNumber.ToString()[0]);
                            addedTailPosition = true;
                            break;
                        }

                        tailNumber += 1;
                    }

                    if (!addedTailPosition)
                    {
                        row.Add('.');
                    }
                }                    
            }

            grid.Add(row);
        }

        var sb = new StringBuilder();
        foreach(var row in grid)
        {
            foreach (var item in row)
            {
                sb.Append(item);
            }

            sb.AppendLine();
        }

        sb.AppendLine();

        return sb.ToString();
    }
}
