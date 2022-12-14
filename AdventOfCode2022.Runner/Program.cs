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
    Console.WriteLine("> '6a' - Day 6 (Tuning Trouble), Part 1");
    Console.WriteLine("> '6b' - Day 6 (Tuning Trouble), Part 2");
    Console.WriteLine("> '7a' - Day 7 (No Space Left On Device), Part 1");
    Console.WriteLine("> '7b' - Day 7 (No Space Left On Device), Part 2");
    Console.WriteLine("> '8a' - Day 8 (Treetop Tree House), Part 1");
    Console.WriteLine("> '8b' - Day 8 (Treetop Tree House), Part 2");
    Console.WriteLine("> '9a' - Day 9 (Rope Bridge), Part 1");
    Console.WriteLine("> '9b' - Day 9 (Rope Bridge), Part 2");
    Console.WriteLine("> '10a' - Day 10 (Cathode-Ray Tube), Part 1");
    Console.WriteLine("> '10b' - Day 10 (Cathode-Ray Tube), Part 2");
    Console.WriteLine("> '11a' - Day 11 (Monkey in the Middle), Part 1");
    Console.WriteLine("> '11b' - ...");
    Console.WriteLine("> '12a' - Day 12 (Hill Climbing Algorithm), Part 1");
    Console.WriteLine("> '12b' - Day 12 (Hill Climbing Algorithm), Part 2");
    Console.WriteLine("> '13a' - Day 13 (Distress Signal), Part 1");
    Console.WriteLine("> '13b' - ...");
    Console.WriteLine("> '14a' - Day 14 (Regolith Reservoir), Part 1");
    Console.WriteLine("> '14b' - Day 14 (Regolith Reservoir), Part 2");
    Console.WriteLine();
    Console.WriteLine("Enter '0' to exit.");

    input = Console.ReadLine();

    switch (input)
    {
        case "0":
            break;
        case "1a":
            {
                var result = Day1.GetMaxCaloriesCarriedByAnElf(GetInputDataLines(1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "1b":
            {
                var result = Day1.GetCaloriesCarriedByTopElves(GetInputDataLines(1), 3);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "2a":
            {
                var result = Day2.GetRockPaperScissorScoreWithStrategy1(GetInputDataLines(2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "2b":
            {
                var result = Day2.GetRockPaperScissorScoreWithStrategy2(GetInputDataLines(2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "3a":
            {
                var result = Day3.GetTotalPriortiesOfDuplicatedItems(GetInputDataLines(3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "3b":
            {
                var result = Day3.GetTotalPriortiesOfBadgeItems(GetInputDataLines(3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "4a":
            {
                var result = Day4.GetNumberOfContainingRanges(GetInputDataLines(4), Day4.ContainCheck.FullyContains);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "4b":
            {
                var result = Day4.GetNumberOfContainingRanges(GetInputDataLines(4), Day4.ContainCheck.Overlaps);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "5a":
            {
                var result = Day5.GetTopCratesFromStacks(GetInputDataLines(5), Day5.MoveBehaviour.SingleItem);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "5b":
            {
                var result = Day5.GetTopCratesFromStacks(GetInputDataLines(5), Day5.MoveBehaviour.MultipleItems);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "6a":
            {
                var result = Day6.GetPositionOfMarker(GetInputData(6), 4);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "6b":
            {
                var result = Day6.GetPositionOfMarker(GetInputData(6), 14);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "7a":
            {
                var result = Day7.GetTotalDirectorySize(GetInputDataLines(7), 100000);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "7b":
            {
                var result = Day7.GetSizeOfDirectoryToDelete(GetInputDataLines(7), 8381165);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "8a":
            {
                var result = Day8.GetNumberOfVisibleTrees(GetInputDataLines(8));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "8b":
            {
                var result = Day8.GetHighestScenicScore(GetInputDataLines(8));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "9a":
            {
                var result = Day9.GetNumberOfTailPositions(GetInputDataLines(9), 2);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "9b":
            {
                var result = Day9.GetNumberOfTailPositions(GetInputDataLines(9), 10);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "10a":
            {
                var result = Day10.GetSumOfSignalStrengths(GetInputDataLines(10));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "10b":
            {
                var result = Day10.GetScreenOutput(GetInputDataLines(10));
                Console.Write(result);
                Console.WriteLine();
            }
            break;
        case "11a":
            {
                var result = Day11.GetMonkeyBusinessLevel(GetInputDataLines(11), true, 20);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "11b":
            {
                var result = Day11.GetMonkeyBusinessLevel(GetInputDataLines(11), false, 10000);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "12a":
            {
                var result = Day12.GetFewestStepsToDestination(GetInputDataLines(12));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "12b":
            {
                var result = Day12.GetFewestStepsFromAnyLowestElevationToDestination(GetInputDataLines(12));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "13a":
            {
                var result = Day13.GetSumOfOrderedPairIndices(GetInputDataLines(13));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "14a":
            {
                var result = Day14.GetNumberOfSandUnitsWithNoFloor(GetInputDataLines(14));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "14b":
            {
                var result = Day14.GetNumberOfSandUnitsWithFloor(GetInputDataLines(14));
                Console.WriteLine($"Result: {result}");
            }
            break;
        default:
            Console.WriteLine($"Unrecognised input.");
            break;
    }

    Console.WriteLine();
    Console.ReadLine();
}

static string GetInputData(int day)
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
            return reader.ReadToEnd();
        }
    }
}

static string[] GetInputDataLines(int day) => GetInputData(day).Split(Environment.NewLine);