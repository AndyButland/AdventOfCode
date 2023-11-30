namespace AdventOfCode.Year2022;

public static class Day6
{
    public static int GetPositionOfMarker(string input, int markerDistinctCharacters)
    {
        var queue = new Queue<char>();
        var position = 0;
        foreach (var c in input)
        {
            queue.Enqueue(c);

            position++;

            if (IsQueueFilled(queue, markerDistinctCharacters))
            {
                if (IsQueueFilledWithDifferentCharaters(queue, markerDistinctCharacters))
                {
                    break;
                }

                queue.Dequeue();
            }
        }

        return position;
    }

    private static bool IsQueueFilled(Queue<char> queue, int markerDistinctCharacters) => queue.Count() == markerDistinctCharacters;

    private static bool IsQueueFilledWithDifferentCharaters(Queue<char> queue, int markerDistinctCharacters)
    {
        var items = new List<char>();
        for (int i = 0; i < markerDistinctCharacters; i++)
        {
            items.Add(queue.ElementAt(i));
        }

        return items.Count == items.Distinct().Count();
    }
}