namespace AdventOfCode.Year2022.Tests;

public class Day3Tests
{
    private static string s_input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

    [Test]
    public void GetTotalPriortiesOfDuplicatedItems_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day3.GetTotalPriortiesOfDuplicatedItems(inputLines);
        result.Should().Be(157);
    }

    [Test]
    public void GetTotalPriortiesOfBadgeItems_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines();

        var result = Day3.GetTotalPriortiesOfBadgeItems(inputLines);
        result.Should().Be(70);
    }

    private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
}