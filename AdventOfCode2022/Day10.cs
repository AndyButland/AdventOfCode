using System.Text;

namespace AdventOfCode2022
{
    public static class Day10
    {
        public class Instruction
        {
            public Instruction(string command)
            {
                Command = command;
            }

            public string Command { get; }

            public int Value { get; init; }
        }

        public static int GetSumOfSignalStrengths(string[] inputLines)
        {
            var instructions = GetInstructions(inputLines);
            return GetSumOfSignalStrengths(instructions);
        }

        private static List<Instruction> GetInstructions(string[] inputLines) =>
            inputLines
                .Select(ParseInstruction)
                .ToList();

        private static Instruction ParseInstruction(string line)
        {
            if (line.StartsWith("addx"))
            {
                return new Instruction("addx") { Value = int.Parse(line[5..])};
            }

            return new Instruction("noop");
        }

        private static int GetSumOfSignalStrengths(List<Instruction> instructions)
        {
            var result = 0;
            var totalCycles = GetTotalCycles(instructions);
            var cyclesToCheck = GetCyclesToCheck(totalCycles);

            var xValue = 1;
            var cycle = 0;
            foreach (var instruction in instructions)
            {
                cycle++;

                if (cyclesToCheck.Contains(cycle))
                {
                    result += cycle * xValue;
                }

                if (instruction.Command == "addx")
                {
                    cycle++;
                    if (cyclesToCheck.Contains(cycle))
                    {
                        result += cycle * xValue;
                    }

                    xValue += instruction.Value;
                }
            }
            
            return result;
        }

        private static int GetTotalCycles(List<Instruction> instructions)
        {
            return instructions.Where(x => x.Command == "noop").Count() +
                   instructions.Where(x => x.Command == "addx").Count() * 2;
        }

        private static List<int> GetCyclesToCheck(int totalCycles)
        {
            var cyclesToCheck = new List<int>();
            for (int i = 20; i < totalCycles; i += 40)
            {
                cyclesToCheck.Add(i);
            }

            return cyclesToCheck;
        }

        public static string GetScreenOutput(string[] inputLines)
        {
            var instructions = GetInstructions(inputLines);
            return GetScreenOutput(instructions);
        }

        private static string GetScreenOutput(List<Instruction> instructions)
        {
            var xValue = 1;
            var cycle = 0;
            var crtPosition = 0;
            var sb = new StringBuilder();
            foreach (var instruction in instructions)
            {
                cycle++;

                WriteValue(sb, xValue, crtPosition);

                crtPosition = SetNewCrtPosition(crtPosition, sb);

                if (instruction.Command == "addx")
                {
                    cycle++;

                    WriteValue(sb, xValue, crtPosition);

                    xValue += instruction.Value;

                    crtPosition = SetNewCrtPosition(crtPosition, sb);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static int SetNewCrtPosition(int crtPosition, StringBuilder sb)
        {
            crtPosition++;
            if (crtPosition == 40)
            {
                crtPosition = 0;
                WriteNewLine(sb);
            }

            return crtPosition;
        }

        private static void WriteNewLine(StringBuilder sb) => sb.AppendLine();

        private static void WriteValue(StringBuilder sb, int xValue, int crtPosition)
        {
            var value = Math.Abs(crtPosition - xValue) <= 1 ? "#" : ".";
            sb.Append(value);
        }
    }
}
