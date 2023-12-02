namespace AdventOfCode.Year2023;

public static class Day2
{
    public static int GetSumOfGameIdsPossibleWithCubes(string[] inputLines, int red, int green, int blue)
    {
        var games = GetGames(inputLines);
        return games
            .Where(x => x.IsPossible(red, green, blue))
            .Select(x => x.Id)
            .Sum();
    }

    public static int GetPowerOfMinimumNumberOfCubes(string[] inputLines)
    {
        var games = GetGames(inputLines);
        return games
            .Select(x => x.GetPowerOfMinimumNumberOfCubes())
            .Sum();
    }

    private static IList<Game> GetGames(string[] inputLines)
    {
        var games = new List<Game>();
        foreach (var line in inputLines)
        {
            var id = GetGameId(line);
            var sets = GetGameSets(line, id);
            var game = new Game(id, sets);
            games.Add(game);
        }

        return games;
    }

    private static int GetGameId(string line)
    {
        var startPosition = "Game ".Length;
        var separatorPosition = line.IndexOf(':');
        return int.Parse(line.Substring(startPosition, separatorPosition - startPosition));
    }

    private static IList<Set> GetGameSets(string line, int id)
    {
        var sets = new List<Set>();
        var setDetails = line.Substring($"Game {id}: ".Length).Split("; ");
        foreach (var setDetail in setDetails)
        {
            var ballDetails = setDetail.Split(", ");
            int red = 0;
            int green = 0;
            int blue = 0;
            foreach (var ballDetail in ballDetails)
            {
                var colorDetails = ballDetail.Split(" ");
                if (!int.TryParse(colorDetails[0], out int number))
                {
                    throw new InvalidOperationException($"Could not parse number of balls from '{colorDetails[0]}' for ball detail '{ballDetail}' on line '{line}'.");
                }

                switch(colorDetails[1])
                {
                    case "red":
                        red = number;
                        break;
                    case "green":
                        green = number;
                        break;
                    case "blue":
                        blue = number;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Not a colour: {colorDetails[1]}");
                }
            }

            var set = new Set(red, green, blue);
            sets.Add(set);
        }

        return sets;
    }

    private class Game
    {
        public Game(int id, IList<Set> sets)
        {
            Id = id;
            Sets = sets;
        }

        public int Id { get; }

        public IList<Set> Sets { get; } = new List<Set>();

        public bool IsPossible(int red, int green, int blue) => Sets.All(x => x.IsPossible(red, green, blue));

        public int GetPowerOfMinimumNumberOfCubes()
        {
            var minReds = Sets.Max(x => x.Red);
            var minGreens = Sets.Max(x => x.Green);
            var minBlues = Sets.Max(x => x.Blue);
            return minReds * minGreens * minBlues;
        }
    }

    private class Set
    {
        public Set(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; }

        public int Green { get; }

        public int Blue { get; }

        public bool IsPossible(int red, int green, int blue) => Red <= red && Green <= green && Blue <= blue;
    }
}
