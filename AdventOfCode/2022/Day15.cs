namespace AdventOfCode.Year2022;

public static class Day15
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public override int GetHashCode() => X ^ Y;

        public override bool Equals(object obj) =>
            obj is Position position && position.X == X && position.Y == Y;

        public override string ToString() => $"{X},{Y}";
    }

    public class Input
    {
        public Position Sensor { get; set; } = new();

        public Position Beacon { get; set; } = new();
    }

    public static int GetNumberOfPositionsThatCannotContainABeacon(string[] inputLines, int row)
    {
        var inputs = GetInputs(inputLines);
        var positionsExcludedForRow = GetExcludedPositionsForRow(inputs, row);
        return positionsExcludedForRow.Count;
    }

    public static int GetTuningFrequencyOfBeacon(string[] inputLines, int maxDimension)
    {
        var inputs = GetInputs(inputLines);
        var positionsExcludedForRows = GetExcludedPositionsForRows(inputs, maxDimension);
        for (int x = 0; x <= maxDimension; x++)
        {
            for (int y = 0; y <= maxDimension; y++)
            {
                var excludedPosition = positionsExcludedForRows.FirstOrDefault(p => p.X == x && p.Y == y);
                if (excludedPosition == null)
                {
                    var matchingBeacon = inputs.FirstOrDefault(i => i.Beacon.X == x && i.Beacon.Y == y);
                    if (matchingBeacon == null)
                    {
                        return x * 4000000 + y;
                    }
                }    
            }
        }

        return 0;
    }

    private static List<Input> GetInputs(string[] inputLines)
    {
        var inputs = new List<Input>();
        foreach (var line in inputLines)
        {
            var replacedLine = line
                .Replace("Sensor at x=", string.Empty)
                .Replace(", y=", ",")
                .Replace(": closest beacon is at x=", ",");
            var lineParts = replacedLine.Split(',');
            var input = new Input
            {
                Sensor = new Position
                {
                    X = int.Parse(lineParts[0]),
                    Y = int.Parse(lineParts[1])
                },
                Beacon = new Position
                {
                    X = int.Parse(lineParts[2]),
                    Y = int.Parse(lineParts[3])
                },
            };
            inputs.Add(input);
        }

        return inputs;
    }

    private static HashSet<Position> GetExcludedPositionsForRows(List<Input> inputs, int maxDimension)
    {
        var excludedPositions = new HashSet<Position>();
        var rows = Enumerable.Range(0, maxDimension + 1);
        foreach (var row in rows)
        {
            var excludedPositionsForRow = GetExcludedPositionsForRow(inputs, row, 0, maxDimension);
            foreach (var excludedPosition in excludedPositionsForRow)
            {
                excludedPositions.Add(excludedPosition);
            }
        }

        return excludedPositions;
    }

    private static HashSet<Position> GetExcludedPositionsForRow(List<Input> inputs, int row, int? minX = null, int? maxX = null)
    {
        var excludedPositions = new HashSet<Position>();
        foreach (var input in inputs)
        {
            var distance = Math.Abs(input.Beacon.X - input.Sensor.X) +
                           Math.Abs(input.Beacon.Y - input.Sensor.Y);

            var excludedPositionsForInput = GetPositionsWithinDistanceForRow(input.Sensor, input.Beacon, distance, row, minX, maxX);
            foreach (var excludedPosition in excludedPositionsForInput)
            {
                excludedPositions.Add(excludedPosition);
            }
        }

        return excludedPositions;
    }

    private static List<Position> GetPositionsWithinDistanceForRow(
        Position sensorPosition,
        Position beaconPosition,
        int distance,
        int row,
        int? minX = null,
        int? maxX = null)
    {
        // Positions within distance will be a rhombus around the start position.
        var result = new List<Position>();

        // Get the positions above the start position.
        var count = 0;
        for (int y = sensorPosition.Y - distance; y < sensorPosition.Y; y++)
        {
            if (y == row)
            {
                AddPositionsWithinDistanceInRow(result, sensorPosition, beaconPosition, y, count, minX, maxX);
            }

            count++;
        }

        // Get the positions below the start position.
        count = 0;
        for (int y = sensorPosition.Y + distance; y > sensorPosition.Y; y--)
        {
            if (y == row)
            {
                AddPositionsWithinDistanceInRow(result, sensorPosition, beaconPosition, y, count, minX, maxX);
            }

            count++;
        }

        // Get the positions on the same row as the start position.
        if (sensorPosition.Y == row)
        {
            for (int x = sensorPosition.X - distance; x < sensorPosition.X + distance; x++)
            {
                if (minX.HasValue && x < minX.Value)
                {
                    continue;
                }

                if (maxX.HasValue && x > maxX.Value)
                {
                    continue;
                }

                AddPositionWithinDistance(result, beaconPosition, x, sensorPosition.Y);
            }

            // Add the sensor itself.
            result.Add(new Position { X = sensorPosition.X, Y = sensorPosition.Y });
        }

        return result;
    }

    private static void AddPositionsWithinDistanceInRow(
        List<Position> result,
        Position sensorPosition,
        Position beaconPosition,
        int y,
        int count,
        int? minX = null,
        int? maxX = null)
    {
        for (int x = sensorPosition.X - count; x <= sensorPosition.X + count; x++)
        {
            if (minX.HasValue && x < minX.Value)
            {
                continue;
            }

            if (maxX.HasValue && x > maxX.Value)
            {
                continue;
            }

            AddPositionWithinDistance(result, beaconPosition, x, y);
        }
    }

    private static void AddPositionWithinDistance(List<Position> result, Position beaconPosition, int x, int y)
    {
        if (x == beaconPosition.X && y == beaconPosition.Y)
        {
            return;
        }

        result.Add(new Position { X = x, Y = y });
    }
}


