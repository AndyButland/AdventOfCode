using AdventOfCode2022;

namespace AdventOfCode.Tests
{
    public class Day13Tests
    {
        private static string s_input = @"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";


        [Test]
        public void GetSumOfOrderedPairIndices_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines(s_input);

            var result = Day13.GetSumOfOrderedPairIndices(inputLines);
            result.Should().Be(13);
        }

        private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
    }
}