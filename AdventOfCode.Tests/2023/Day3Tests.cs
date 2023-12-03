namespace AdventOfCode.Year2023.Tests;

public class Day3Tests
{
    private static string s_input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

    private static string s_input2 = @"....221
......*";

    [Test]
    public void GetSumOfPartNumbers_ReturnsCorrectResultForTestInput1()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day3.GetSumOfPartNumbers(inputLines);
        result.Should().Be(4361);
    }

    [Test]
    public void GetSumOfPartNumbers_ReturnsCorrectResultForTestInput2()
    {
        string[] inputLines = GetInputLines(s_input2);

        var result = Day3.GetSumOfPartNumbers(inputLines);
        result.Should().Be(221);
    }

    [Test]
    public void GetSumOfGearRatios_ReturnsCorrectResultForTestInput1()
    {
        string[] inputLines = GetInputLines(s_input);

        var result = Day3.GetSumOfGearRatios(inputLines);
        result.Should().Be(467835);
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolToLeft()
    {
        var data = Day3.GetData(GetInputLines(@"........
.*123...
........"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _ );
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolToRight()
    {
        var data = Day3.GetData(GetInputLines(@"........
..123+..
........"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolAbove()
    {
        var data = Day3.GetData(GetInputLines(@"...?....
..123...
........"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolBelow()
    {
        var data = Day3.GetData(GetInputLines(@"........
..123...
.../...."));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolAboveAndToLeft()
    {
        var data = Day3.GetData(GetInputLines(@".?......
..123...
........"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolAboveAndToRight()
    {
        var data = Day3.GetData(GetInputLines(@".....?..
..123...
........"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolBelowAndToLeft()
    {
        var data = Day3.GetData(GetInputLines(@"........
..123...
.!......"));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    [Test]
    public void HasAdjacentSymbol_FindsSymbolBelowAndToRight()
    {
        var data = Day3.GetData(GetInputLines(@"........
..123...
.....!.."));
        var result = Day3.HasAdjacentSymbol(data, new Day3.PartNumber { Value = "123", StartPoint = new Day3.Point { RowIndex = 1, CharIndex = 2 } }, out _);
        result.Should().BeTrue();
    }

    private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
}