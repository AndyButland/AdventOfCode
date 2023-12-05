namespace AdventOfCode.Year2023;

public static class Day5
{
    private static readonly List<string> MapNames = new()
    {
        "seed-to-soil",
        "soil-to-fertilizer",
        "fertilizer-to-water",
        "water-to-light",
        "light-to-temperature",
        "temperature-to-humidity",
        "humidity-to-location"
    };

    public static long GetLowestLocationNumber(string[] inputLines)
    {
        var seeds = GetSeeds(inputLines);
        var maps = BuildMaps(inputLines);

        var location = long.MaxValue;
        foreach (var seed in seeds)
        {
            var seedLocation = GetLocation(seed, maps);
            if (seedLocation < location)
            {
                location = seedLocation;
            }
        }

        return location;
    }

    private static long[] GetSeeds(string[] inputLines) =>
        inputLines[0].Replace("seeds: ", string.Empty).Split(' ').Select(long.Parse).ToArray();

    private static Dictionary<string, List<MapValue>> BuildMaps(string[] inputLines)
    {
        var maps = new Dictionary<string, List<MapValue>>();

        string? mapName = null;
        var mapValues = new List<MapValue>();
        foreach (var line in inputLines.Skip(2))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.EndsWith(":"))
            {
                if (mapName != null)
                {
                    maps.Add(mapName, mapValues);
                }

                mapName = line.Replace(" map:", string.Empty);
                mapValues = new List<MapValue>();
            }
            else
            {
                var mapParts = line.Split(' ').Select(long.Parse).ToArray();
                mapValues.Add(new MapValue(mapParts[1], mapParts[0], mapParts[2]));
            }
        }

        if (mapName != null)
        {
            maps.Add(mapName, mapValues);
        }

        return maps;
    }

    private static long GetLocation(long seed, Dictionary<string, List<MapValue>> maps)
    {
        long value = seed;
        foreach (var mapName in MapNames)
        {
            var map = maps[mapName];
            var range = map.SingleOrDefault(x => value >= x.Source && value < x.Source + x.Range);
            value = range != null ? value - range.Source + range.Destination: value;
        }

        return value;
    }

    private class MapValue
    {
        public MapValue(long source, long destination, long range)
        {
            Source = source;
            Destination = destination;
            Range = range;
        }

        public long Source { get; }

        public long Destination { get; }

        public long Range { get; }
    }
}
