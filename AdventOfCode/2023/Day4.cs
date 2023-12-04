namespace AdventOfCode.Year2023;

public static class Day4
{
    public static int GetSumOfPoints(string[] inputLines)
    {
        var cards = GetCards(inputLines);

        return cards
            .Select(x => x.GetScore())
            .Sum();
    }

    public static int GetNumberOfScratchcards(string[] inputLines)
    {
        var cards = GetCards(inputLines);

        var cardCounts = new Dictionary<int, int>();
        foreach (var card in cards)
        {
            cardCounts.Add(card.Id, 1);
        }

        int cardId = 1;
        foreach (var card in cards)
        {
            var winningNumbers = card.GetNumberOfWinningNumbers();
            for (int i = 1; i <= cardCounts[cardId]; i++)
            {
                for (int j = 1; j <= winningNumbers; j++)
                {
                    cardCounts[cardId + j]++;
                }                
            }

            cardId++;
        }

        return cardCounts.Sum(x => x.Value);
    }

    private static IList<Card> GetCards(string[] inputLines)
    {
        var cards = new List<Card>();
        foreach (var line in inputLines)
        {
            var id = GetCardId(line);
            var numbers = GetCardNumbers(line);
            var card = new Card
            {
                Id = id,
                Numbers = numbers.Numbers,
                WinningNumbers = numbers.WinningNumbers,
            };
            cards.Add(card);
        }

        return cards;
    }

    private static int GetCardId(string line)
    {
        var startPosition = "Card ".Length;
        var separatorPosition = line.IndexOf(':');
        return int.Parse(line.Substring(startPosition, separatorPosition - startPosition));
    }

    private static (int[] Numbers, int[] WinningNumbers) GetCardNumbers(string line)
    {
        var numberDetail = line.Substring(line.IndexOf(':') + 1);
        var numberParts = numberDetail.Split('|').Select(x => x.Trim()).ToArray();
        var numbers = GetNumbers(numberParts, 0);
        var winningNumbers = GetNumbers(numberParts, 1);
        return (numbers, winningNumbers);
    }

    private static int[] GetNumbers(string[] numberParts, int index) =>
        numberParts[index].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    private class Card
    {
        public int Id { get; set; }

        public IList<int> Numbers { get; set; } = new List<int>();

        public IList<int> WinningNumbers { get; set; } = new List<int>();

        public int GetNumberOfWinningNumbers() => Numbers
                .Where(x => WinningNumbers.Contains(x))
                .Count();

        public int GetScore()
        {
            var winningNumberCount = GetNumberOfWinningNumbers();
            return (int)Math.Pow(2, winningNumberCount - 1);
        }
    }
}
