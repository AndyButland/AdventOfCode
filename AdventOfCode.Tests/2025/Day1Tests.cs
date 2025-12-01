namespace AdventOfCode.Year2025.Tests;

public class Day1Tests
{
    private static string s_input = @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";

    [Test]
    public void GetNumberOfTimesStoppingOnZero_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day1.GetNumberOfTimesStoppingOnZero(inputLines);
        result.Should().Be(3);
    }

    [Test]
    public void GetNumberOfTimesPassingZero_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day1.GetNumberOfTimesPassingZero(inputLines);
        result.Should().Be(6);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}
