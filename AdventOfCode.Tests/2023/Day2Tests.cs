namespace AdventOfCode.Year2023.Tests;

public class Day2Tests
{
    private static string s_input = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

    [Test]
    public void GetSumOfGameIdsPossibleWithCubes_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day2.GetSumOfGameIdsPossibleWithCubes(inputLines, 12, 13, 14);
        result.Should().Be(8);
    }

    [Test]
    public void GetPowerOfMinumumNumberOfCubes_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day2.GetPowerOfMinimumNumberOfCubes(inputLines);
        result.Should().Be(2286);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}