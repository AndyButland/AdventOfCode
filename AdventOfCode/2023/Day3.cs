
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Year2023;

public static class Day3
{
    const string Digits = "0123456789";

    public static int GetSumOfPartNumbers(string[] inputLines)
    {
        var data = GetData(in inputLines);

        var partNumbers = GetPartNumbers(data);

        return partNumbers
            .Where(x => HasAdjacentSymbol(data, x, out _))
            .Select(x => int.Parse(x.Value))
            .Sum();
    }

    public static int GetSumOfGearRatios(string[] inputLines)
    {
        var data = GetData(in inputLines);

        var partNumbers = GetPartNumbers(data);

        foreach (var partNumber in partNumbers)
        {
            partNumber.GearPoint = GetGearPoint(data, partNumber);
        }

        var partNumberWithGears = partNumbers
            .Where(x => x.GearPoint is not null)
            .ToList();

        var partNumberPairs = new List<(PartNumber, PartNumber)>();

        foreach (var partNumberWithGear in partNumberWithGears)
        {
            // Skip if recorded.
            if (partNumberPairs.Any(x => x.Item1.StartPoint.RowIndex == partNumberWithGear.StartPoint.RowIndex &&
                                         x.Item1.StartPoint.CharIndex == partNumberWithGear.StartPoint.CharIndex))
            {
                continue;
            }

            PartNumber? matchingPartNumber = null;
            foreach (var partNumberWithGear2 in partNumberWithGears)
            {
                // Skip if self.
                if (partNumberWithGear.StartPoint.RowIndex == partNumberWithGear2.StartPoint.RowIndex &&
                    partNumberWithGear.StartPoint.CharIndex == partNumberWithGear2.StartPoint.CharIndex)
                {
                    continue;
                }

                // Skip if recorded.
                if (partNumberPairs.Any(x => x.Item2.StartPoint.RowIndex == partNumberWithGear2.StartPoint.RowIndex &&
                                             x.Item2.StartPoint.CharIndex == partNumberWithGear2.StartPoint.CharIndex))
                {
                    continue;
                }

                if (partNumberWithGear.GearPoint!.RowIndex == partNumberWithGear2.GearPoint!.RowIndex &&
                    partNumberWithGear.GearPoint.CharIndex == partNumberWithGear2.GearPoint.CharIndex)
                {
                    if (matchingPartNumber is null)
                    {
                        // Found one.
                        matchingPartNumber = partNumberWithGear2;
                    }
                    else
                    {
                        // Found more than one.
                        break;
                    }
                }
            }

            if (matchingPartNumber is not null)
            {
                partNumberPairs.Add((partNumberWithGear, matchingPartNumber));
            }
        }

        return partNumberPairs
            .Select(x => int.Parse(x.Item1.Value) * int.Parse(x.Item2.Value))
            .Sum() / 2;    // / 2 as will have double-counted.
    }

    internal static List<List<char>> GetData(in string[] inputLines)
    {
        var data = new List<List<char>>();
        foreach (var line in inputLines)
        {
            var row = new List<char>();
            foreach (char c in line)
            {
                row.Add(c);
            }

            data.Add(row);
        }

        return data;
    }

    private static IList<PartNumber> GetPartNumbers(List<List<char>> data)
    {
        var result = new List<PartNumber>();
        var rowIndex = 0;
        foreach (var row in data)
        {
            int? numberStartIndex = null;
            var charIndex = 0;
            PartNumber? partNumber = null;
            foreach (var c in row)
            {
                if (Digits.Contains(c))
                {
                    if (numberStartIndex.HasValue)
                    {
                        partNumber!.Value += c;
                    }
                    else
                    {
                        partNumber = new PartNumber { Value = c.ToString(), StartPoint = new Point { RowIndex = rowIndex, CharIndex = charIndex } };
                        numberStartIndex = charIndex;
                    }
                }
                else if (partNumber != null)
                {
                    result.Add(partNumber);

                    numberStartIndex = null;
                    partNumber = null;
                }

                charIndex++;
            }

            if (partNumber != null)
            {
                result.Add(partNumber);
            }

            rowIndex++;
        }

        return result;
    }

    internal class PartNumber
    {
        public string Value { get; set; } = string.Empty;

        public Point StartPoint { get; set; } = new Point { RowIndex = 0, CharIndex = 0 };

        public Point? GearPoint { get; set; }
    }

    internal class Point
    {
        public int RowIndex { get; set; }

        public int CharIndex { get; set; }
    }

    internal static bool HasAdjacentSymbol(List<List<char>> data, PartNumber partNumber, [NotNullWhen(true)]out Point? symbolPoint, char? forSymbol = null) =>
        CheckLeft(data, partNumber, out symbolPoint, forSymbol) ||
        CheckRight(data, partNumber, out symbolPoint, forSymbol) ||
        CheckAbove(data, partNumber, out symbolPoint, forSymbol) ||
        CheckBelow(data, partNumber, out symbolPoint, forSymbol);

    private static bool CheckLeft(List<List<char>> data, PartNumber partNumber, out Point? symbolPoint, char? forSymbol = null)
    {
        if (partNumber.StartPoint.CharIndex > 0 && CheckPoint(data, partNumber.StartPoint.RowIndex, partNumber.StartPoint.CharIndex - 1, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex, CharIndex = partNumber.StartPoint.CharIndex - 1 };
            return true;
        }

        symbolPoint = null;
        return false;
    }
        

    private static bool CheckRight(List<List<char>> data, PartNumber partNumber, out Point? symbolPoint, char? forSymbol = null)
    {
        if (partNumber.StartPoint.CharIndex + partNumber.Value.Length < data[partNumber.StartPoint.RowIndex].Count && CheckPoint(data, partNumber.StartPoint.RowIndex, partNumber.StartPoint.CharIndex + partNumber.Value.Length, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex, CharIndex = partNumber.StartPoint.CharIndex + partNumber.Value.Length };
            return true;
        }

        symbolPoint = null;
        return false;
    }   

    private static bool CheckAbove(List<List<char>> data, PartNumber partNumber, out Point? symbolPoint, char? forSymbol = null)
    {
        if (partNumber.StartPoint.RowIndex == 0)
        {
            symbolPoint = null;
            return false;
        }

        for (int i = 0; i < partNumber.Value.Length; i++)
        {
            if (CheckPoint(data, partNumber.StartPoint.RowIndex - 1, partNumber.StartPoint.CharIndex + i, forSymbol))
            {
                symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex - 1, CharIndex = partNumber.StartPoint.CharIndex + i };
                return true;
            }
        }

        // Check diagonally above and to the left.
        if (partNumber.StartPoint.CharIndex > 0 && CheckPoint(data, partNumber.StartPoint.RowIndex - 1, partNumber.StartPoint.CharIndex - 1, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex - 1, CharIndex = partNumber.StartPoint.CharIndex - 1 };
            return true;
        }

        // Check diagonally above and to the right.
        if (partNumber.StartPoint.CharIndex + partNumber.Value.Length < data[partNumber.StartPoint.RowIndex].Count && CheckPoint(data, partNumber.StartPoint.RowIndex - 1, partNumber.StartPoint.CharIndex + partNumber.Value.Length, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex - 1, CharIndex = partNumber.StartPoint.CharIndex + partNumber.Value.Length };
            return true;
        }

        symbolPoint = null;
        return false;
    }

    private static bool CheckBelow(List<List<char>> data, PartNumber partNumber, out Point? symbolPoint, char? forSymbol = null)
    {
        if (partNumber.StartPoint.RowIndex == data.Count - 1)
        {
            symbolPoint = null;
            return false;
        }

        for (int i = 0; i < partNumber.Value.Length; i++)
        {
            if (CheckPoint(data, partNumber.StartPoint.RowIndex + 1, partNumber.StartPoint.CharIndex + i, forSymbol))
            {
                symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex + 1, CharIndex = partNumber.StartPoint.CharIndex + i };
                return true;
            }
        }

        // Check diagonally below and to the left.
        if (partNumber.StartPoint.CharIndex > 0 && CheckPoint(data, partNumber.StartPoint.RowIndex + 1, partNumber.StartPoint.CharIndex - 1, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex + 1, CharIndex = partNumber.StartPoint.CharIndex - 1 };
            return true;
        }

        // Check diagonally below and to the right.
        if (partNumber.StartPoint.CharIndex + partNumber.Value.Length < data[partNumber.StartPoint.RowIndex].Count && CheckPoint(data, partNumber.StartPoint.RowIndex + 1, partNumber.StartPoint.CharIndex + partNumber.Value.Length, forSymbol))
        {
            symbolPoint = new Point { RowIndex = partNumber.StartPoint.RowIndex + 1, CharIndex = partNumber.StartPoint.CharIndex + partNumber.Value.Length };
            return true;
        }

        symbolPoint = null;
        return false;
    }

    private static bool CheckPoint(List<List<char>> data, int rowIndex, int charIndex, char? forSymbol = null)
    {
        if (forSymbol != null)
        {
            return data[rowIndex][charIndex] == forSymbol;
        }
        
        return data[rowIndex][charIndex] != '.';
    }

    private static Point? GetGearPoint(List<List<char>> data, PartNumber partNumber)
    {
        if (HasAdjacentSymbol(data, partNumber, out Point? symbolPoint, '*'))
        {
            return symbolPoint;
        }

        return null;
    }
}
