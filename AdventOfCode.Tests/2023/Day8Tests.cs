using AdventOfCode.Year2022;

namespace AdventOfCode.Year2023.Tests;

public class Day8Tests
{
    private static string s_input1 = @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)";

    private static string s_input2 = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";

    [Test]
    public void GetNumberOfSteps_ReturnsCorrectResultForTestInput1()
    {
        string[] inputLines = GetInputLines(s_input1);

        var result = Day8.GetNumberOfSteps(inputLines);
        result.Should().Be(2);
    }

    [Test]
    public void GetNumberOfSteps_ReturnsCorrectResultForTestInput2()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day8.GetNumberOfSteps(inputLines);
        result.Should().Be(6);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}