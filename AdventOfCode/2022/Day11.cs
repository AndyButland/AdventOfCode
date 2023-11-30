using System.Text;

namespace AdventOfCode.Year2022;

public static class Day11
{
    public class Monkey
    {
        public Monkey(Queue<long> items, Operation operation, int testDivisibleByValue, int throwOnTrueToMonkeyIndex, int throwOnFalseToMonkeyIndex)
        {
            Items = items;
            Operation = operation;
            TestDivisibleByValue = testDivisibleByValue;
            ThrowOnTrueToMonkeyIndex = throwOnTrueToMonkeyIndex;
            ThrowOnFalseToMonkeyIndex = throwOnFalseToMonkeyIndex;
        }
        
        public Queue<long> Items { get; }

        public Operation Operation { get; }

        public int TestDivisibleByValue { get; }

        public int ThrowOnTrueToMonkeyIndex { get; }
        
        public int ThrowOnFalseToMonkeyIndex { get; }

        public long InspectionCount { get; private set; } = 0;

        public void IncrementInspectionCount() => InspectionCount++;

        public string ToDebugString(int index)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Monkey {0}:", index);
            sb.AppendLine();
            sb.AppendFormat("  Starting items: {0}", GetDebugStringForItems());
            sb.AppendLine();
            sb.AppendFormat("  Operation: new = old {0} {1}", Operation.Operator, Operation.Operand);
            sb.AppendLine();
            sb.AppendFormat("  Test: divisible by {0}", TestDivisibleByValue);
            sb.AppendLine();
            sb.AppendFormat("    If true: throw to monkey {0}", ThrowOnTrueToMonkeyIndex);
            sb.AppendLine();
            sb.AppendFormat("    If false: throw to monkey {0}", ThrowOnFalseToMonkeyIndex);
            sb.AppendLine();
            return sb.ToString();
        }

        private string GetDebugStringForItems() =>
            string.Join(", ",
                Enumerable.Range(0, Items.Count)
                    .Select(x => Items.ElementAt(x)));
    }

    public class Operation
    {
        public Operation(char @operator, string operand)
        {
            Operator = @operator;
            Operand = operand;
        }

        public char Operator { get; }

        public string Operand { get; }
    }

    public static long GetMonkeyBusinessLevel(string[] inputLines, bool withRelief, int rounds)
    {
        var monkeys = GetMonkeys(inputLines);

        /*
        var sb = new StringBuilder();
        var index = 0;
        foreach (var monkey in monkeys)
        {
            sb.Append(monkey.ToDebugString(index));
            sb.AppendLine();
            index++;
        }

        var asInputString = sb.ToString();
        */

        return GetMonkeyBusinessLevel(monkeys, withRelief, rounds);
    }

    private static List<Monkey> GetMonkeys(string[] inputLines)
    {
        var monkeys = new List<Monkey>();
        for (int i = 0; i < inputLines.Length; i+=7)
        {
            var line = inputLines[i];
            var startingItems = inputLines[i + 1].TrimStart().Replace("Starting items: ", string.Empty).Split(',').Select(x => int.Parse(x.Trim()));
            var queue = new Queue<long>();
            foreach (var item in startingItems)
            {
                queue.Enqueue(item);
            }

            var operationParts = inputLines[i + 2].TrimStart().Replace("Operation: new = old ", string.Empty).Split(' ');
            var operation = new Operation(operationParts[0][0], operationParts[1]);

            var testDivisibleByValue = int.Parse(inputLines[i + 3].TrimStart().Replace("Test: divisible by ", string.Empty));

            var throwOnTrueToMonkeyIndex = int.Parse(inputLines[i + 4].TrimStart().Replace("If true: throw to monkey ", string.Empty));
            var throwOnFalseToMonkeyIndex = int.Parse(inputLines[i + 5].TrimStart().Replace("If false: throw to monkey ", string.Empty));

            monkeys.Add(new Monkey(queue, operation, testDivisibleByValue, throwOnTrueToMonkeyIndex, throwOnFalseToMonkeyIndex));
        }

        return monkeys;
    }

    private static long GetMonkeyBusinessLevel(List<Monkey> monkeys, bool withRelief, int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.TryDequeue(out long worryLevel))
                {
                    var newWorryLevel = GetIncreasedWorryLevel(worryLevel, monkey.Operation);
                    if (withRelief)
                    {
                        newWorryLevel /= 3;
                    }

                    var receivingMonkeyIndex = newWorryLevel % monkey.TestDivisibleByValue == 0
                        ? monkey.ThrowOnTrueToMonkeyIndex
                        : monkey.ThrowOnFalseToMonkeyIndex;
                    monkeys[receivingMonkeyIndex].Items.Enqueue(newWorryLevel);

                    monkey.IncrementInspectionCount();
                }
            }
        }

        return monkeys.OrderByDescending(x => x.InspectionCount).Take(2).Aggregate(1L, (x, y) => x * y.InspectionCount);
    }

    private static long GetIncreasedWorryLevel(long currentLevel, Operation operation)
    {
        if (!long.TryParse(operation.Operand, out long operand))
        {
            if (operation.Operand == "old")
            {
                operand = currentLevel;
            }
            else
            {
                throw new ArgumentException($"{operation.Operand} could not be parsed as an operand.");
            }
        }

        switch(operation.Operator)
        {
            case '+':
                return currentLevel + operand;
            case '*':
                return currentLevel * operand;
            default:
                throw new ArgumentException($"{operation.Operator} could not be parsed as an operator.");
        }
    }
}


