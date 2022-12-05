namespace AdventOfCode2022
{
    public static class Day5
    {
        public enum MoveBehaviour
        {
            SingleItem,
            MultipleItems
        }

        public static string GetTopCratesFromStacks(string[] inputLines, MoveBehaviour behaviour)
        {
            var stacks = GetStacks(inputLines);
            MoveCratesOnStacks(inputLines, stacks, behaviour);
            return string.Join(string.Empty, stacks.Select(x => x.Pop().ToString()));
        }

        private static List<Stack<char>> GetStacks(string[] inputLines)
        {
            var stacks = new List<Stack<char>>();

            var stackStartIndex = 0;
            foreach (var line in inputLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                stackStartIndex++;
            }

            stackStartIndex--; // skip over number labels

            for (int i = stackStartIndex; i >= 0; i--)
            {
                var charIndex = -1;
                foreach (var c in inputLines[i])
                {
                    charIndex++;
                    if (c == '[' || c == ']' || char.IsWhiteSpace(c) || char.IsDigit(c))
                    {
                        continue;
                    }

                    var stackIndex = (int)((charIndex + 3) / 4) - 1;
                    var stackCount = stacks.Count;
                    if (stackIndex >= stackCount)
                    {

                        for (int j = 0; j < stackIndex + 1 - stackCount; j++)
                        {
                            stacks.Add(new Stack<char>());
                        }
                    }

                    stacks[stackIndex].Push(c);
                }
            }


            return stacks;
        }

        private static void MoveCratesOnStacks(string[] inputLines, List<Stack<char>> stacks, MoveBehaviour behaviour)
        {
            foreach (var line in inputLines)
            {
                if (!line.StartsWith("move"))
                {
                    continue;
                }

                var instruction = GetInstruction(line);
                ProcessInstruction(instruction, stacks, behaviour);
            }
        }

        private static void ProcessInstruction((int Number, int FromIndex, int ToIndex) instruction, List<Stack<char>> stacks, MoveBehaviour behaviour)
        {
            if (behaviour == MoveBehaviour.SingleItem)
            {
                for (int i = 0; i < instruction.Number; i++)
                {
                    var item = stacks[instruction.FromIndex].Pop();
                    stacks[instruction.ToIndex].Push(item);
                }
            }
            else
            {
                var items = new List<char>();
                for (int i = 0; i < instruction.Number; i++)
                {
                    items.Add(stacks[instruction.FromIndex].Pop());
                }

                items.Reverse();
                foreach (var item in items)
                {
                    stacks[instruction.ToIndex].Push(item);
                }
            }
        }

        private static (int Number, int FromIndex, int ToIndex) GetInstruction(string line)
        {
            var parsedLine = line
                .Replace("move", string.Empty)
                .Replace("from", string.Empty)
                .Replace("to", string.Empty)
                .Replace("  ", ",");
            var parsedLineParts = parsedLine.Split(',').Select(x => int.Parse(x.ToString())).ToArray();
            return new(parsedLineParts[0], parsedLineParts[1] - 1, parsedLineParts[2] - 1);
        }
    }
}