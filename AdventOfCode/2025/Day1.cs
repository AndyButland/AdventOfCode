namespace AdventOfCode.Year2025;

public static class Day1
{
    public static int GetNumberOfTimesStoppingOnZero(string[] inputLines)
    {
        var position = 50;
        var counter = 0;

        foreach (var line in inputLines)
        {
            var instruction = new MoveInstruction(line);
            position = Move(position, instruction.GetDelta());
            if (position == 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public static int GetNumberOfTimesPassingZero(string[] inputLines)
    {
        var position = 50;
        var counter = 0;

        foreach (var line in inputLines)
        {
            var instruction = new MoveInstruction(line);
            counter += CountZeroCrossings(position, instruction.GetDelta());
            position = Move(position, instruction.GetDelta());
        }

        return counter;
    }

    private static int Move(int position, int delta)
    {
        var newPosition = (position + delta) % 100;
        return newPosition < 0 ? newPosition + 100 : newPosition;
    }

    private static int CountZeroCrossings(int position, int delta)
    {
        if (delta > 0)
        {
            return (position + delta) / 100;
        }
        else
        {
            var amount = -delta;
            if (position == 0)
            {
                return amount / 100;
            }
            return amount >= position ? (amount - position) / 100 + 1 : 0;
        }
    }

    private record MoveInstruction
    {
        public MoveInstruction(string instruction)
        {
            Direction = instruction[0];
            Amount = int.Parse(instruction[1..]);
        }

        public char Direction { get; init; }

        public int Amount { get; init; }

        public int GetDelta() => Direction == 'L' ? -Amount : Amount;
    }
}
