namespace AdventOfCode.Year2023;

public static class Day6
{
    public static long GetProductOfNumberOfWaysToWin(string[] inputLines, bool withMultipleRaces = true)
    {
        var races = GetRaces(inputLines, withMultipleRaces);

        var result = 1;
        foreach (var race in races)
        {
            var numberOfTimesRecordBeaten = 0;
            for (long i = 0; i <= race.Duration; i++) {
                var distanceTravelled = GetDistanceTravelled(i, race.Duration);
                if (distanceTravelled > race.RecordDistance) 
                {
                    numberOfTimesRecordBeaten++;
                }
            }

            result *= numberOfTimesRecordBeaten;
        }

        return result;
    }

    private static IList<Race> GetRaces(string[] inputLines, bool withMultipleRaces)
    {
        var times = GetRaceValues(inputLines, 0);
        var recordDistances = GetRaceValues(inputLines, 1);

        if (withMultipleRaces)
        {
            return times.Zip(recordDistances, (t, rd) => new Race(t, rd)).ToList();
        }

        var time = long.Parse(string.Join(string.Empty, times));
        var recordDistance = long.Parse(string.Join(string.Empty, recordDistances));
        var race = new Race(time, recordDistance);
        return new List<Race> { race };
    }

    private static IList<long> GetRaceValues(string[] inputLines, long index) =>
        inputLines[index].Substring(10)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => long.Parse(x.Trim()))
            .ToList();

    private static long GetDistanceTravelled(long timeForButtonPress, long raceDuration)
    {
        var speed = timeForButtonPress;
        var duration = raceDuration - timeForButtonPress;
        return duration * speed;
    }

    private class Race
    {
        public Race(long duration, long recordDistance)
        {
            Duration = duration;
            RecordDistance = recordDistance;
        }

        public long Duration { get; }

        public long RecordDistance { get; }
    }
}
