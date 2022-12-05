using AdventOfCode2022;
using static AdventOfCode2022.Day5;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        private static string s_input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

        [Test]
        public void GetTopCratesFromStacks_WithSingleItemMoveBehaviour_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines();

            var result = Day5.GetTopCratesFromStacks(inputLines, MoveBehaviour.SingleItem);
            result.Should().Be("CMZ");
        }

        [Test]
        public void GetTopCratesFromStacks_WithMultipleItemMoveBehaviour_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines();

            var result = Day5.GetTopCratesFromStacks(inputLines, MoveBehaviour.MultipleItems);
            result.Should().Be("MCD");
        }

        private static string[] GetInputLines() => s_input.Split(Environment.NewLine);
    }
}