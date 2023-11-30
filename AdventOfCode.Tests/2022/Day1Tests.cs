namespace AdventOfCode.Year2022.Tests;

public class Day1Tests
{
    private static string s_input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [Test]
    public void GetMaxCaloriesCarriedByAnElf_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day1.GetMaxCaloriesCarriedByAnElf(inputLines);
        result.Should().Be(24000);
    }

    [Test]
    public void GetCaloriesCarriedByTopThreeElves_ReturnsCorrectResultForTestInput()
    {
        var inputLines = s_input.Split(Environment.NewLine);
        inputLines.Count().Should().Be(14);

        var result = Day1.GetCaloriesCarriedByTopElves(inputLines, 3);
        result.Should().Be(45000);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}