namespace AdventOfCode.Year2025.Tests;

public class Day2Tests
{
    private static string s_input = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124";

    [Test]
    public void SumInvalidIds_ReturnsExpectedResult()
    {
        var result = Day2.SumInvalidIdsPart1(s_input);
        result.Should().Be(1227775554);
    }

    [Test]
    public void SumInvalidIdsPart2_ReturnsExpectedResult()
    {
        var result = Day2.SumInvalidIdsPart2(s_input);
        result.Should().Be(4174379265);
    }
}
