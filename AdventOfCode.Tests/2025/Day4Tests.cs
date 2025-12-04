namespace AdventOfCode.Year2025.Tests;

public class Day4Tests
{
    private static string s_input = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";

    [Test]
    public void GetNumberOfRollsOfPaper_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day4.GetNumberOfRollsOfPaper(inputLines);
        result.Should().Be(13);
    }

    [Test]
    public void GetNumberOfRollsOfPaperThatCanBeRemoved_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day4.GetNumberOfRollsOfPaperThatCanBeRemoved(inputLines);
        result.Should().Be(43);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}
