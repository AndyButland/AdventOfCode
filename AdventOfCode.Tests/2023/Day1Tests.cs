namespace AdventOfCode.Year2023.Tests;

public class Day1Tests
{
    private static string s_input1 = @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet";

    private static string s_input2 = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

    [Test]
    public void GetSumOfCalibrationValues_ReturnsCorrectResultForTestInput1()
    {
        string[] inputLines = GetInputLines(s_input1);

        var result = Day1.GetSumOfCalibrationValues(inputLines);
        result.Should().Be(142);
    }

    [Test]
    public void GetSumOfCalibrationValues_ReturnsCorrectResultForTestInput2()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day1.GetSumOfCalibrationValues(inputLines);
        result.Should().Be(281);
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}