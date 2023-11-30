namespace AdventOfCode.Year2022.Tests;

public class Day17Tests
{
    private static string s_input = @">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";

    [Test]
    public void GetRockHeight_ReturnsCorrectResultForTestInput()
    {
        var result = Day17.GetRockHeight(s_input);
        result.Should().Be(3068);
    }
}