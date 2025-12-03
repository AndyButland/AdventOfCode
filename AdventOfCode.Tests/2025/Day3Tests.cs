namespace AdventOfCode.Year2025.Tests;

public class Day3Tests
{
    private static string s_input = @"987654321111111
811111111111119
234234234234278
818181911112111";

    [Test]
    public void GetTotalOutputJoltage_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day3.GetTotalOutputJoltageForTwoDigits(inputLines);
        result.Should().Be(357);
    }

    [Test]
    public void GetTotalOutputJoltageForTwelveDigits_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day3.GetTotalOutputJoltageForTwelveDigits(inputLines);
        result.Should().Be(3121910778619);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}
