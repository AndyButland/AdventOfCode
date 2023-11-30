namespace AdventOfCode.Year2022.Tests;

public class Day14Tests
{
    private static string s_input = @"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";

    [Test]
    public void GetNumberOfSandUnitsWithNoFloor_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day14.GetNumberOfSandUnitsWithNoFloor(inputLines);
        result.Should().Be(24);
    }

    [Test]
    public void GetNumberOfSandUnitsWithFloor_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day14.GetNumberOfSandUnitsWithFloor(inputLines);
        result.Should().Be(93);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}