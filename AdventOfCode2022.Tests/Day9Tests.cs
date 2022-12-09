using AdventOfCode2022;
using static AdventOfCode2022.Day9;

namespace AdventOfCode.Tests
{
    public class Day9Tests
    {
        private static string s_input1 = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

        private static string s_input2 = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";

        [Test]
        public void GetNumberOfTailPositions_WithTwoKnots_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines(s_input1);

            var result = Day9.GetNumberOfTailPositions(inputLines, 2);
            result.Should().Be(13);
        }

        [Test]
        public void GetNumberOfTailPositions_WithNineKnots_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines(s_input1);

            var result = Day9.GetNumberOfTailPositions(inputLines, 9);
            result.Should().Be(1);
        }

        [Test]
        public void GetNumberOfTailPositions_WithNineKnots_ReturnsCorrectResultForTestInput2()
        {
            string[] inputLines = GetInputLines(s_input2);

            var result = Day9.GetNumberOfTailPositions(inputLines, 9);
            result.Should().Be(36);
        }

        private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
    }
}