namespace AdventOfCode2022
{
    public static class Day16
    {        
        public class Valve
        {
            public string Name { get; set; } = string.Empty; 

            public int FlowRate { get; set; }

            public List<string> LeadsTo { get; set; } = new();

            public bool IsOpen { get; set; }

            public int GetReleasedPressure() => IsOpen ? FlowRate : 0;
        }

        public static int GetMaximumPressure(string[] inputLines)
        {
            var valves = GetValves(inputLines);
            return GetMaximumPressure(valves);
        }

        private static List<Valve> GetValves(string[] inputLines)
        {
            var valves = new List<Valve>();
            foreach (var line in inputLines)
            {
                var replacedLine = line
                    .Replace("Valve ", string.Empty)
                    .Replace(" has flow rate= ", "|")
                    .Replace("; tunnels lead to valves ", "|");
                var replacedLineParts = replacedLine.Split('|');
                var leadsToParts = replacedLineParts[2].Split(new string[] { ", " }, StringSplitOptions.None);
                var valve = new Valve
                {
                    Name = replacedLineParts[0],
                    FlowRate = int.Parse(leadsToParts[1]),
                    LeadsTo = leadsToParts.ToList(),
                };
                valves.Add(valve);
            }

            return valves;
        }

        private static int GetMaximumPressure(List<Valve> valves)
        {
            const int Minutes = 30;
            var releasedPressure = 0;

            var currentValve = valves.Single(x => x.Name == "AA");

            for (var i = 1; i <= Minutes; i++)
            {

            }

            return releasedPressure;
        }

    }
}


