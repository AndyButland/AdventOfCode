namespace AdventOfCode.Year2022.Tests;

public class Day2Tests
{
    private static string s_input = @"A Y
B X
C Z";

    [Test]
    public void GetRockPaperScissorScoreWithStrategy1_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day2.GetRockPaperScissorScoreWithStrategy1(inputLines);
        result.Should().Be(15);
    }

    [Test]
    public void GetRockPaperScissorScoreWithStrategy2_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day2.GetRockPaperScissorScoreWithStrategy2(inputLines);
        result.Should().Be(12);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}