namespace AdventOfCode.Year2022.Tests;

public class Day8Tests
{
    private static string s_input = @"30373
25512
65332
33549
35390";

    [Test]
    public void GetNumberOfVisibleTrees_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day8.GetNumberOfVisibleTrees(inputLines);
        result.Should().Be(21);
    }

    [Test]
    public void GetHighestScenicScore_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day8.GetHighestScenicScore(inputLines);
        result.Should().Be(8);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}