namespace AdventOfCode.Year2023.Tests;

public class Day7Tests
{
    private static string s_input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

    [Test]
    public void GetWinnings_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day7.GetWinnings(inputLines);
        result.Should().Be(6440);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}