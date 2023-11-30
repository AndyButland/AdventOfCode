namespace AdventOfCode.Year2022.Tests;

public class Day15Tests
{
    private static string s_input1 = @"Sensor at x=8, y=7: closest beacon is at x=2, y=10";

    private static string s_input2 = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";

    [Test]
    public void GetNumberOfPositionsThatCannotContainABeacon_WithInput1_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input1);

        var result = Day15.GetNumberOfPositionsThatCannotContainABeacon(inputLines, 10);
        result.Should().Be(12);
    }

    [Test]
    public void GetNumberOfPositionsThatCannotContainABeacon_WithInput2_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day15.GetNumberOfPositionsThatCannotContainABeacon(inputLines, 10);
        result.Should().Be(26);
    }

    [Test]
    public void GetTuningFrequencyOfBeacon_WithInput2_ReturnsCorrectResultForTestInput()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day15.GetTuningFrequencyOfBeacon(inputLines, 20);
        result.Should().Be(56000011);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}