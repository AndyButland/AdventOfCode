using AdventOfCode2022;
using System.Reflection;

Console.WriteLine("Advent Of Code Runner");
Console.WriteLine("---------------------");

var input = string.Empty;
while (input != "0")
{

    Console.WriteLine("Please select the exercise you would like to run:");
    Console.WriteLine();
    Console.WriteLine("> '1a' - Day 1 (Calorie Counting), Part 1");
    Console.WriteLine("> '1b' - Day 1 (Calorie Counting), Part 2");
    Console.WriteLine("> '2a' - Day 2 (Rock Paper Scissors), Part 1");
    Console.WriteLine("> '2b' - Day 2 (Rock Paper Scissors), Part 2");
    Console.WriteLine("> '3a' - Day 3 (Rucksack Reorganization), Part 1");
    Console.WriteLine("> '3b' - Day 3 (Rucksack Reorganization), Part 2");
    Console.WriteLine("> '4a' - Day 4 (Camp Cleanup), Part 1");
    Console.WriteLine("> '4b' - Day 4 (Camp Cleanup), Part 2");
    Console.WriteLine("> '5a' - Day 5 (Supply Stacks), Part 1");
    Console.WriteLine("> '5b' - Day 5 (Supply Stacks), Part 2");
    Console.WriteLine();
    Console.WriteLine("Enter '0' to exit.");

    input = Console.ReadLine();

    switch (input)
    {
        case "0":
            break;
        case "1a":
            {
                var result = Day1.GetMaxCaloriesCarriedByAnElf(GetInputData(1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "1b":
            {
                var result = Day1.GetCaloriesCarriedByTopElves(GetInputData(1), 3);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "2a":
            {
                var result = Day2.GetRockPaperScissorScoreWithStrategy1(GetInputData(2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "2b":
            {
                var result = Day2.GetRockPaperScissorScoreWithStrategy2(GetInputData(2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "3a":
            {
                var result = Day3.GetTotalPriortiesOfDuplicatedItems(GetInputData(3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "3b":
            {
                var result = Day3.GetTotalPriortiesOfBadgeItems(GetInputData(3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "4a":
            {
                var result = Day4.GetNumberOfContainingRanges(GetInputData(4), Day4.ContainCheck.FullyContains);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "4b":
            {
                var result = Day4.GetNumberOfContainingRanges(GetInputData(4), Day4.ContainCheck.Overlaps);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "5a":
            {
                var result = Day5.GetTopCratesFromStacks(GetInputData(5), Day5.MoveBehaviour.SingleItem);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "5b":
            {
                var result = Day5.GetTopCratesFromStacks(GetInputData(5), Day5.MoveBehaviour.MultipleItems);
                Console.WriteLine($"Result: {result}");
            }
            break;
        default:
            Console.WriteLine($"Unrecognised input.");
            break;
    }

    Console.WriteLine();
}

static string[] GetInputData(int day)
{
    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = $"AdventOfCode2022.Runner.InputData.Day{day}.txt";

    using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
    {
        if (stream == null)
        {
            throw new InvalidOperationException($"Could not load input date for day {day} from resoure {resourceName}.");
        }

        using (StreamReader reader = new StreamReader(stream))
        {
            string inputData = reader.ReadToEnd();
            return inputData.Split(Environment.NewLine);
        }
    }
}