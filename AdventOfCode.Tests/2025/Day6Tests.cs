namespace AdventOfCode.Year2025.Tests;

public class Day6Tests
{
    private static string s_input = @"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  ";

    [Test]
    public void SolvePart1_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day6.GetSumOfAnswers(inputLines);
        result.Should().Be(4277556);
    }

    [Test]
    public void SolvePart2_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day6.GetSumOfAnswers2(inputLines);
        result.Should().Be(3263827);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}
