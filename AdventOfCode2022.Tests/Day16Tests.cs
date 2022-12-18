using AdventOfCode2022;

namespace AdventOfCode.Tests
{
    public class Day16Tests
    {
        private static string s_input = @"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II";


        [Test]
        public void GetMaximumPressure_ReturnsCorrectResultForTestInput()
        {
            string[] inputLines = GetInputLines(s_input);

            var result = Day16.GetMaximumPressure(inputLines);
            result.Should().Be(1651);
        }

        private static string[] GetInputLines(string input) => input.Split(Environment.NewLine);
    }
}