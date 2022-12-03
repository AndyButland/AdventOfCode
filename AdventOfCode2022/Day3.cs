using System.Diagnostics;

namespace AdventOfCode2022
{
    public static class Day3
    {
        public static int GetTotalPriortiesOfDuplicatedItems(string[] inputLines)
        {
            var total = 0;
            foreach (var line in inputLines)
            {
                var parts = GetParts(line);
                var matchingItem = GetMatchingItem(parts);
                var priority = GetItemPriority(matchingItem);
                total += priority;
            }

            return total;
        }

        private static (string Part1, string Part2) GetParts(string line)
        {
            var partLength = (int)(line.Length / 2);
            return new(line.Substring(0, partLength), line.Substring(partLength, partLength));
        }

        private static char GetMatchingItem((string Part1, string Part2) parts) =>
            parts.Part1.Select(x => x).First(x => parts.Part2.Contains(x));

        private static int GetItemPriority(char matchingItem) => 
            Char.IsUpper(matchingItem)
                ? (int)matchingItem - 38
                : (int)matchingItem - 96;

        public static int GetTotalPriortiesOfBadgeItems(string[] inputLines)
        {
            var total = 0;
            var groups = GetInputLinesInGroups(inputLines, 3);
            foreach (var group in groups)
            {
                var commonItem = GetCommonItem(group);
                var priority = GetItemPriority(commonItem);
                total += priority;
            }

            return total;
        }

        private static IEnumerable<IEnumerable<string>> GetInputLinesInGroups(string[] inputLines, int size)
        {
            int total = 0;
            while (total < inputLines.Length)
            {
                yield return inputLines.Skip(total).Take(size);
                total += size;
            }
        }

        private static char GetCommonItem(IEnumerable<string> group)
        {
            var groupAsList = group.ToList();
            return groupAsList[0]
                .Select(x => x)
                .Where(x => groupAsList[1].Contains(x) && groupAsList[2].Contains(x))
                .FirstOrDefault();
        }
    }
}