namespace AdventOfCode.Year2022.Tests;

public class Day12Tests
{
    private static string s_input1 = @"SabcdefghijklmnopqrstuvwxyzE";

    private static string s_input2 = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

    private static string s_input3 = @"Sabcde
xxxhgf
xxxixx
kkkjxx
lmnnno
utsrqp
vwxyzE";

    [Test]
    public void GetFewestStepsToDestination_WithInput1_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input1);

        var result = Day12.GetFewestStepsToDestination(inputLines);
        result.Should().Be(27);
    }

    [Test]
    public void GetFewestStepsToDestination_WithInput2_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day12.GetFewestStepsToDestination(inputLines);
        result.Should().Be(31);
    }

    [Test]
    public void GetFewestStepsToDestination_WithInput3_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input3);

        var result = Day12.GetFewestStepsToDestination(inputLines);
        result.Should().Be(31);
    }

    [Test]
    public void GetFewestStepsFromAnyLowestElevationToDestination_WithInput2_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day12.GetFewestStepsFromAnyLowestElevationToDestination(inputLines);
        result.Should().Be(29);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}