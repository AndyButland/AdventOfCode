namespace AdventOfCode.Year2023.Tests;

public class Day6Tests
{
    private static string s_input = @"Time:      7  15   30
Distance:  9  40  200";

    [Test]
    public void GetProductOfNumberOfWaysToWin_WithMultipleRaces_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day6.GetProductOfNumberOfWaysToWin(inputLines);
        result.Should().Be(288);
    }

    [Test]
    public void GetProductOfNumberOfWaysToWin_WithSingleRace_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day6.GetProductOfNumberOfWaysToWin(inputLines, false);
        result.Should().Be(71503);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}