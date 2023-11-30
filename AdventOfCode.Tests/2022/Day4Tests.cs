namespace AdventOfCode.Year2022.Tests;

public class Day4Tests
{
    private static string s_input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

    [Test]
    public void GetNumberOfContainingRanges_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day4.GetNumberOfContainingRanges(inputLines, Day4.ContainCheck.FullyContains);
        result.Should().Be(2);
    }

    [Test]
    public void GetNumberOfOverlappingRanges_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day4.GetNumberOfContainingRanges(inputLines, Day4.ContainCheck.Overlaps);
        result.Should().Be(4);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}