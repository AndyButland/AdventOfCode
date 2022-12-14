using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public static class Day14
    {
        public record Point
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        public static int GetNumberOfSandUnitsWithNoFloor(string[] inputLines)
        {
            var inputs = GetInputs(inputLines);
            var cave = GetEmptyCave(inputs);
            AddRocks(cave, inputs);

            var display = DisplayCave(cave);

            var count = 0;
            while (AddSand(cave))
            {
                count++;
            }

            return count;
        }

        public static int GetNumberOfSandUnitsWithFloor(string[] inputLines)
        {
            var inputs = GetInputs(inputLines);
            var cave = GetEmptyCave(inputs, true);
            AddRocks(cave, inputs);

            var count = 0;
            while (AddSand(cave))
            {
                count++;
            }

            var display = DisplayCave(cave);

            return count;
        }

        private static List<List<Point>> GetInputs(string[] inputLines)
        {
            var inputs = new List<List<Point>>();
            foreach (var line in inputLines)
            {
                var row = new List<Point>();
                var points = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                foreach (var point in points)
                {
                    var pointParts = point.Split(',');
                    row.Add(new Point { X = int.Parse(pointParts[0]), Y = int.Parse(pointParts[1]) });
                }

                inputs.Add(row);
            }

            return inputs;
        }

        private static List<List<char>> GetEmptyCave(List<List<Point>> inputs, bool withFloor = false)
        {
            var cave = new List<List<char>>();
            var height = GetCaveHeight(inputs, withFloor);
            for (int y = 0; y < height; y++)
            {
                var cells = new List<char>();
                for (int x = 0; x < 1000; x++)
                {
                    cells.Add('.');
                }

                cave.Add(cells);
            }

            if (withFloor)
            {
                for (int i = 0; i < 1000; i++)
                {
                    cave[cave.Count - 1][i] = '#';
                }
            }

            return cave;
        }

        private static int GetCaveHeight(List<List<Point>> inputs, bool withFloor) =>
            inputs
                .Select(x => x.Max(y => y.Y))
                .Max() + (withFloor ? 2 : 0) + 1;

        private static void AddRocks(List<List<char>> cave, List<List<Point>> inputs)
        {
            foreach (var input in inputs)
            {
                for (int i = 0; i < input.Count - 1; i++)
                {
                    var point1 = input[i];
                    var point2 = input[i + 1];

                    cave[point1.Y][point1.X] = '#';
                    if (point1.X == point2.X)
                    {
                        var s = point1.Y;
                        var f = point2.Y;
                        var d = f > s ? 1 : -1;
                        while (f != s)
                        {
                            s += d;
                            cave[s][point1.X] = '#';
                        }
                    }
                    else
                    {
                        var s = point1.X;
                        var f = point2.X;
                        var d = f > s ? 1 : -1;
                        while (f != s)
                        {
                            s += d;
                            cave[point1.Y][s] = '#';
                        }
                    }
                }
            }
        }

        private static string DisplayCave(List<List<char>> cave)
        {
            var sb = new StringBuilder();
            foreach (var row in cave)
            {
                foreach (var cell in row)
                {
                    sb.Append(cell);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static bool AddSand(List<List<char>> cave)
        {
            var x = 500;
            var y = 0;

            if (cave[y][x] == 'o')
            {
                return false;
            }

            cave[y][x] = 'o';

            while (y < cave.Count - 1)
            {
                if (SandComesToRest(cave, ref x, ref y))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool SandComesToRest(List<List<char>> cave, ref int x, ref int y)
        {
            if (cave[y + 1][x] == '.')
            {
                cave[y][x] = '.';
                cave[y + 1][x] = 'o';
                y++;
                return false;
            }

            if (cave[y + 1][x - 1] == '.')
            {
                cave[y][x] = '.';
                cave[y + 1][x - 1] = 'o';
                x--;
                y++;
                return false;
            }

            if (cave[y + 1][x + 1] == '.')
            {
                cave[y][x] = '.';
                cave[y + 1][x + 1] = 'o';
                x++;
                y++;
                return false;
            }

            cave[y][x] = 'o';
            return true;
        }
    }
}


