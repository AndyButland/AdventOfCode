namespace AdventOfCode2022
{
    public static class Day1
    {
        public static int GetMaxCaloriesCarriedByAnElf(string[] inputLines)
        {
            List<int> batches = GetBatches(inputLines);
            return batches.Max();
        }

        private static List<int> GetBatches(string[] inputLines)
        {
            var batches = new List<int>();
            var currentBatch = 0;
            foreach (var inputLine in inputLines)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    if (currentBatch > 0)
                    {
                        batches.Add(currentBatch);
                        currentBatch = 0;
                    }
                }
                else
                {
                    currentBatch += int.Parse(inputLine);
                }
            }

            if (currentBatch > 0)
            {
                batches.Add(currentBatch);
            }

            return batches;
        }

        public static int GetCaloriesCarriedByTopElves(string[] inputLines, int top)
        {
            List<int> batches = GetBatches(inputLines);
            return batches
                .OrderByDescending(x => x)
                .Take(top)
                .Sum();
        }
    }
}