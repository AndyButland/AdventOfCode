namespace AdventOfCode.Year2023;

public static class Day8
{
    public static int GetNumberOfSteps(string[] inputLines)
    {
        var instructions = GetInstructions(inputLines);
        var map = GetMap(inputLines);

        return GetNumberOfSteps(instructions, map);
    }

    private static char[] GetInstructions(string[] inputLines) => inputLines[0].Trim().ToCharArray();

    private static IList<MapEntry> GetMap(string[] inputLines)
    {
        var map = new List<MapEntry>();
        foreach (var line in inputLines.Skip(2))
        {
            var start = line.Substring(0, 3);
            var left = line.Substring(7, 3);
            var right = line.Substring(12, 3);
            map.Add(new MapEntry(start, left, right));
        }

        return map;
    }

    private static int GetNumberOfSteps(char[] instructions, IList<MapEntry> map)
    {
        var steps = 0;
        var instructionIndex = 0;
        var position = map.First(x => x.Start == "AAA").Start;
        var finish = "ZZZ";
        while (position != finish)
        {
            steps++;

            var instruction = instructions[instructionIndex];
            var mapEntry = map.First(x => x.Start == position);
            position = instruction == 'L' ? mapEntry.Left : mapEntry.Right;

            instructionIndex++;
            if (instructionIndex == instructions.Length)
            {
                instructionIndex = 0;
            }
        }

        return steps;
    }

    private class MapEntry
    {
        public MapEntry(string start, string left, string right)
        {
            Start = start;
            Left = left;
            Right = right;
        }

        public string Start { get; }

        public string Left { get; }

        public string Right { get; }
    }

}
