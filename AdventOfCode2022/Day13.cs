using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AdventOfCode2022
{
    public static class Day13
    {
        public class PacketPair
        {
            public JsonNode? Part1 { get; set; }

            public JsonNode? Part2 { get; set; }
        }

        public class Item
        {
            public int? IntValue { get; set; }

            public List<int>? ListValue { get; set; }
        }

        public static long GetSumOfOrderedPairIndices(string[] inputLines)
        {
            var pairs = GetPacketPairs(inputLines);

            var result = 0;
            var index = 1;
            foreach (var pair in pairs)
            {
                if (GetPairOrder(pair.Part1!, pair.Part2!) < 0)
                {
                    result += index;
                }

                index++;
            }

            return result;
        }

        private static List<PacketPair> GetPacketPairs(string[] inputLines)
        {
            var result = new List<PacketPair>();

            for (int i = 0; i < inputLines.Length; i+=3)
            {
                var line1 = inputLines[i];
                var line2 = inputLines[i + 1];

                var pair = new PacketPair
                {
                    Part1 = ParseLine(line1),
                    Part2 = ParseLine(line2),
                };

                result.Add(pair);
            }

            return result;
        }

        private static JsonNode? ParseLine(string line) => JsonNode.Parse(line);

        private static int GetPairOrder(JsonNode part1, JsonNode part2)
        {
            if (part1 is JsonValue part1Value && part2 is JsonValue part2Value)
            {
                return (int)part1Value - (int)part2Value;
            }

            JsonArray part1Array = part1 as JsonArray ?? new JsonArray((int)part1);
            JsonArray part2Array = part2 as JsonArray ?? new JsonArray((int)part2);

            var arrayComparison = Enumerable.Zip(part1Array, part2Array)
                .Select(x => GetPairOrder(x.First!, x.Second!))
                .ToList();

            int arrayComparisonValue = arrayComparison.FirstOrDefault(x => x != 0);

            if (arrayComparisonValue != 0)
            {
                return arrayComparisonValue;
            }

            return part1Array.Count - part2Array.Count;
        }
    }
}


