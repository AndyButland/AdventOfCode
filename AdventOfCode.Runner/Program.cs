using System.Reflection;

Console.WriteLine("Advent Of Code Runner");
Console.WriteLine("---------------------");

var input = string.Empty;
while (input != "0")
{

    Console.WriteLine("Please select the exercise you would like to run:");
    Console.WriteLine();
    Console.WriteLine("> '22-1a' - 2022 Day 1 (Calorie Counting), Part 1");
    Console.WriteLine("> '22-1b' - 2022 Day 1 (Calorie Counting), Part 2");
    Console.WriteLine("> '22-2a' - 2022 Day 2 (Rock Paper Scissors), Part 1");
    Console.WriteLine("> '22-2b' - 2022 Day 2 (Rock Paper Scissors), Part 2");
    Console.WriteLine("> '22-3a' - 2022 Day 3 (Rucksack Reorganization), Part 1");
    Console.WriteLine("> '22-3b' - 2022 Day 3 (Rucksack Reorganization), Part 2");
    Console.WriteLine("> '22-4a' - 2022 Day 4 (Camp Cleanup), Part 1");
    Console.WriteLine("> '22-4b' - 2022 Day 4 (Camp Cleanup), Part 2");
    Console.WriteLine("> '22-5a' - 2022 Day 5 (Supply Stacks), Part 1");
    Console.WriteLine("> '22-5b' - 2022 Day 5 (Supply Stacks), Part 2");
    Console.WriteLine("> '22-6a' - 2022 Day 6 (Tuning Trouble), Part 1");
    Console.WriteLine("> '22-6b' - 2022 Day 6 (Tuning Trouble), Part 2");
    Console.WriteLine("> '22-7a' - 2022 Day 7 (No Space Left On Device), Part 1");
    Console.WriteLine("> '22-7b' - 2022 Day 7 (No Space Left On Device), Part 2");
    Console.WriteLine("> '22-8a' - 2022 Day 8 (Treetop Tree House), Part 1");
    Console.WriteLine("> '22-8b' - 2022 Day 8 (Treetop Tree House), Part 2");
    Console.WriteLine("> '22-9a' - 2022 Day 9 (Rope Bridge), Part 1");
    Console.WriteLine("> '22-9b' - 2022 Day 9 (Rope Bridge), Part 2");
    Console.WriteLine("> '22-10a' - 2022 Day 10 (Cathode-Ray Tube), Part 1");
    Console.WriteLine("> '22-10b' - 2022 Day 10 (Cathode-Ray Tube), Part 2");
    Console.WriteLine("> '22-11a' - 2022 Day 11 (Monkey in the Middle), Part 1");
    Console.WriteLine("> '22-11b' - ...");
    Console.WriteLine("> '22-12a' - 2022 Day 12 (Hill Climbing Algorithm), Part 1");
    Console.WriteLine("> '22-12b' - 2022 Day 12 (Hill Climbing Algorithm), Part 2");
    Console.WriteLine("> '22-13a' - 2022 Day 13 (Distress Signal), Part 1");
    Console.WriteLine("> '22-13b' - ...");
    Console.WriteLine("> '22-14a' - 2022 Day 14 (Regolith Reservoir), Part 1");
    Console.WriteLine("> '22-14b' - 2022 Day 14 (Regolith Reservoir), Part 2");
    Console.WriteLine("> '22-15a' - 2022 Day 15 (Beacon Exclusion Zone), Part 1");
    Console.WriteLine("> '22-15b' - 2022 Day 15 (Beacon Exclusion Zone), Part 2");
    Console.WriteLine();
    Console.WriteLine("> '23-1a' - 2023 Day 1 (Trebuchet), Part 1");
    Console.WriteLine("> '23-1b' - 2023 Day 1 (Trebuchet), Part 2");
    Console.WriteLine("> '23-2a' - 2023 Day 2 (Cube Conundrum), Part 1");
    Console.WriteLine("> '23-2b' - 2023 Day 2 (Cube Conundrum), Part 2");
    Console.WriteLine("> '23-3a' - 2023 Day 3 (Gear Ratios), Part 1");
    Console.WriteLine("> '23-3b' - 2023 Day 3 (Gear Ratios), Part 1");
    Console.WriteLine("> '23-4a' - 2023 Day 4 (Scratchcards), Part 1");
    Console.WriteLine("> '23-4b' - 2023 Day 4 (Scratchcards), Part 2");
    Console.WriteLine("> '23-5a' - 2023 Day 5 (If You Give A Seed A Fertilizer), Part 1");
    Console.WriteLine("> '23-5b' - ...");
    Console.WriteLine("> '23-6a' - 2023 Day 6 (Wait For It), Part 1");
    Console.WriteLine("> '23-6b' - 2023 Day 6 (Wait For It), Part 2");
    Console.WriteLine("> '23-7a' - 2023 Day 7 (Camel Cards), Part 1");
    Console.WriteLine("> '23-7b' - ...");
    Console.WriteLine("> '23-8a' - 2023 Day 8 (Haunted Wasteland), Part 1");
    Console.WriteLine("> '23-8b' - ...");
    Console.WriteLine();
    Console.WriteLine("> '25-1a' - 2025 Day 1 (Secret Entrance), Part 1");
    Console.WriteLine("> '25-1b' - 2025 Day 1 (Secret Entrance), Part 2");
    Console.WriteLine("> '25-2a' - 2025 Day 2 (Gift Shop), Part 1");
    Console.WriteLine("> '25-2b' - 2025 Day 2 (Gift Shop), Part 2");
    Console.WriteLine("> '25-3a' - 2025 Day 3 (Lobby), Part 1");
    Console.WriteLine("> '25-3b' - 2025 Day 3 (Lobby), Part 2");
    Console.WriteLine();
    Console.WriteLine("Enter '0' to exit.");

    input = Console.ReadLine();

    switch (input)
    {
        case "0":
            break;
        case "22-1a":
            {
                var result = AdventOfCode.Year2022.Day1.GetMaxCaloriesCarriedByAnElf(GetInputDataLines(2022, 1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-1b":
            {
                var result = AdventOfCode.Year2022.Day1.GetCaloriesCarriedByTopElves(GetInputDataLines(2022, 1), 3);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-2a":
            {
                var result = AdventOfCode.Year2022.Day2.GetRockPaperScissorScoreWithStrategy1(GetInputDataLines(2022, 2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-2b":
            {
                var result = AdventOfCode.Year2022.Day2.GetRockPaperScissorScoreWithStrategy2(GetInputDataLines(2022, 2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-3a":
            {
                var result = AdventOfCode.Year2022.Day3.GetTotalPriortiesOfDuplicatedItems(GetInputDataLines(2022, 3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-3b":
            {
                var result = AdventOfCode.Year2022.Day3.GetTotalPriortiesOfBadgeItems(GetInputDataLines(2022, 3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-4a":
            {
                var result = AdventOfCode.Year2022.Day4.GetNumberOfContainingRanges(GetInputDataLines(2022, 4), AdventOfCode.Year2022.Day4.ContainCheck.FullyContains);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-4b":
            {
                var result = AdventOfCode.Year2022.Day4.GetNumberOfContainingRanges(GetInputDataLines(2022, 4), AdventOfCode.Year2022.Day4.ContainCheck.Overlaps);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-5a":
            {
                var result = AdventOfCode.Year2022.Day5.GetTopCratesFromStacks(GetInputDataLines(2022, 5), AdventOfCode.Year2022.Day5.MoveBehaviour.SingleItem);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-5b":
            {
                var result = AdventOfCode.Year2022.Day5.GetTopCratesFromStacks(GetInputDataLines(2022, 5), AdventOfCode.Year2022.Day5.MoveBehaviour.MultipleItems);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-6a":
            {
                var result = AdventOfCode.Year2022.Day6.GetPositionOfMarker(GetInputData(2022, 6), 4);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-6b":
            {
                var result = AdventOfCode.Year2022.Day6.GetPositionOfMarker(GetInputData(2022, 6), 14);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-7a":
            {
                var result = AdventOfCode.Year2022.Day7.GetTotalDirectorySize(GetInputDataLines(2022, 7), 100000);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-7b":
            {
                var result = AdventOfCode.Year2022.Day7.GetSizeOfDirectoryToDelete(GetInputDataLines(2022, 7), 8381165);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-8a":
            {
                var result = AdventOfCode.Year2022.Day8.GetNumberOfVisibleTrees(GetInputDataLines(2022, 8));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-8b":
            {
                var result = AdventOfCode.Year2022.Day8.GetHighestScenicScore(GetInputDataLines(2022, 8));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-9a":
            {
                var result = AdventOfCode.Year2022.Day9.GetNumberOfTailPositions(GetInputDataLines(2022, 9), 2);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-9b":
            {
                var result = AdventOfCode.Year2022.Day9.GetNumberOfTailPositions(GetInputDataLines(2022, 9), 10);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-10a":
            {
                var result = AdventOfCode.Year2022.Day10.GetSumOfSignalStrengths(GetInputDataLines(2022, 10));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-10b":
            {
                var result = AdventOfCode.Year2022.Day10.GetScreenOutput(GetInputDataLines(2022, 10));
                Console.Write(result);
                Console.WriteLine();
            }
            break;
        case "22-11a":
            {
                var result = AdventOfCode.Year2022.Day11.GetMonkeyBusinessLevel(GetInputDataLines(2022, 11), true, 20);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-11b":
            {
                var result = AdventOfCode.Year2022.Day11.GetMonkeyBusinessLevel(GetInputDataLines(2022, 11), false, 10000);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-12a":
            {
                var result = AdventOfCode.Year2022.Day12.GetFewestStepsToDestination(GetInputDataLines(2022, 12));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-12b":
            {
                var result = AdventOfCode.Year2022.Day12.GetFewestStepsFromAnyLowestElevationToDestination(GetInputDataLines(2022, 12));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-13a":
            {
                var result = AdventOfCode.Year2022.Day13.GetSumOfOrderedPairIndices(GetInputDataLines(2022, 13));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-14a":
            {
                var result = AdventOfCode.Year2022.Day14.GetNumberOfSandUnitsWithNoFloor(GetInputDataLines(2022, 14));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-14b":
            {
                var result = AdventOfCode.Year2022.Day14.GetNumberOfSandUnitsWithFloor(GetInputDataLines(2022, 14));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-15a":
            {
                var result = AdventOfCode.Year2022.Day15.GetNumberOfPositionsThatCannotContainABeacon(GetInputDataLines(2022, 15), 2000000);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "22-15b":
            {
                var result = AdventOfCode.Year2022.Day15.GetTuningFrequencyOfBeacon(GetInputDataLines(2022, 15), 4000000);
                Console.WriteLine($"Result: {result}");
            }
            break;

        case "23-1a":
            {
                var result = AdventOfCode.Year2023.Day1.GetSumOfCalibrationValues(GetInputDataLines(2023, 1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-1b":
            {
                var result = AdventOfCode.Year2023.Day1.GetSumOfCalibrationValues(GetInputDataLines(2023, 1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-2a":
            {
                var result = AdventOfCode.Year2023.Day2.GetSumOfGameIdsPossibleWithCubes(GetInputDataLines(2023, 2), 12, 13, 14);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-2b":
            {
                var result = AdventOfCode.Year2023.Day2.GetPowerOfMinimumNumberOfCubes(GetInputDataLines(2023, 2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-3a":
            {
                var result = AdventOfCode.Year2023.Day3.GetSumOfPartNumbers(GetInputDataLines(2023, 3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-3b":
            {
                var result = AdventOfCode.Year2023.Day3.GetSumOfGearRatios(GetInputDataLines(2023, 3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-4a":
            {
                var result = AdventOfCode.Year2023.Day4.GetSumOfPoints(GetInputDataLines(2023, 4));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-4b":
            {
                var result = AdventOfCode.Year2023.Day4.GetNumberOfScratchcards(GetInputDataLines(2023, 4));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-5a":
            {
                var result = AdventOfCode.Year2023.Day5.GetLowestLocationNumber(GetInputDataLines(2023, 5));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-6a":
            {
                var result = AdventOfCode.Year2023.Day6.GetProductOfNumberOfWaysToWin(GetInputDataLines(2023, 6));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-6b":
            {
                var result = AdventOfCode.Year2023.Day6.GetProductOfNumberOfWaysToWin(GetInputDataLines(2023, 6), false);
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-7a":
            {
                var result = AdventOfCode.Year2023.Day7.GetWinnings(GetInputDataLines(2023, 7));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "23-8a":
            {
                var result = AdventOfCode.Year2023.Day8.GetNumberOfSteps(GetInputDataLines(2023, 8));
                Console.WriteLine($"Result: {result}");
            }
            break;

        case "25-1a":
            {
                var result = AdventOfCode.Year2025.Day1.GetNumberOfTimesStoppingOnZero(GetInputDataLines(2025, 1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "25-1b":
            {
                var result = AdventOfCode.Year2025.Day1.GetNumberOfTimesPassingZero(GetInputDataLines(2025, 1));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "25-2a":
            {
                var result = AdventOfCode.Year2025.Day2.SumInvalidIdsPart1(GetInputData(2025, 2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "25-2b":
            {
                var result = AdventOfCode.Year2025.Day2.SumInvalidIdsPart2(GetInputData(2025, 2));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "25-3a":
            {
                var result = AdventOfCode.Year2025.Day3.GetTotalOutputJoltageForTwoDigits(GetInputDataLines(2025, 3));
                Console.WriteLine($"Result: {result}");
            }
            break;
        case "25-3b":
            {
                var result = AdventOfCode.Year2025.Day3.GetTotalOutputJoltageForTwelveDigits(GetInputDataLines(2025, 3));
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

static string[] GetInputDataLines(int year, int day) => GetInputData(year, day).Split(Environment.NewLine);

static string GetInputData(int year, int day)
{
    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = $"AdventOfCode.Runner.InputData.Year{year}.Day{day}.txt";

    using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
    {
        if (stream == null)
        {
            throw new InvalidOperationException(message: $"Could not load input date for year {year}, day {day} from resource {resourceName}.");
        }

        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}