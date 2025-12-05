namespace AdventOfCode.Year2025.Tests;

public class Day5Tests
{
    private static string s_input = @"3-5
10-14
16-20
12-18

1
5
8
11
17
32";

    [Test]
    public void GetNumberOfAvailableFreshIngredients_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day5.GetNumberOfAvailableFreshIngredients(inputLines);
        result.Should().Be(3);
    }

    [Test]
    public void GetAllIngredientsConsideredFresh_ReturnsExpectedResult()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day5.GetAllIngredientsConsideredFresh(inputLines);
        result.Should().Be(14);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}
