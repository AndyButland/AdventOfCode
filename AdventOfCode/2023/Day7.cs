namespace AdventOfCode.Year2023;

public static class Day7
{
    private static readonly char[] Cards = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

    public static int GetWinnings(string[] inputLines)
    {
        var hands = GetHands(inputLines);

        var swapped = true;
        var times = 0;
        while (swapped)
        {
            times++;
            swapped = false;

            for (int i = 0; i < hands.Length - 1; i++)
            {                
                if (IsWinningHand(hands[i].Cards, hands[i + 1].Cards))
                {
                    SwapHands(hands, i);
                    swapped = true;
                }
            }
        }

        return hands
            .Select((x, i) => x.Bid * (i + 1))
            .Sum();
    }

    private static bool IsWinningHand(char[] cards, char[] otherCards)
    {
        if (IsFiveOfKind(cards) && !IsFiveOfKind(otherCards))
        {
            return true;
        }

        if (IsFiveOfKind(otherCards) && !IsFiveOfKind(cards))
        {
            return false;
        }

        if (IsFourOfKind(cards) && !IsFourOfKind(otherCards))
        {
            return true;
        }

        if (IsFourOfKind(otherCards) && !IsFourOfKind(cards))
        {
            return false;
        }

        if (IsFullHouse(cards) && !IsFullHouse(otherCards))
        {
            return true;
        }

        if (IsFullHouse(otherCards) && !IsFullHouse(cards))
        {
            return false;
        }

        if (IsThreeOfKind(cards) && !IsThreeOfKind(otherCards))
        {
            return true;
        }

        if (IsThreeOfKind(otherCards) && !IsThreeOfKind(cards))
        {
            return false;
        }

        if (IsTwoPair(cards) && !IsTwoPair(otherCards))
        {
            return true;
        }

        if (IsTwoPair(otherCards) && !IsTwoPair(cards))
        {
            return false;
        }

        if (IsOnePair(cards) && !IsOnePair(otherCards))
        {
            return true;
        }

        if (IsOnePair(otherCards) && !IsOnePair(cards))
        {
            return false;
        }

        return IsWinningHighCard(cards, otherCards);
    }

    private static bool IsFiveOfKind(char[] cards) => IsOfAKind(cards, 5);

    private static bool IsFourOfKind(char[] cards) => IsOfAKind(cards, 4);

    private static bool IsFullHouse(char[] cards)
    {
        var groups = cards.GroupBy(x => x).Select(g => g.Count());
        return groups.Count() == 2 && groups.Where(x => x == 3).Count() == 1 && groups.Where(x => x == 2).Count() == 1;
    }
    private static bool IsThreeOfKind(char[] cards) => IsOfAKind(cards, 3);

    private static bool IsTwoPair(char[] cards)
    {
        var groups = cards.GroupBy(x => x).Select(g => g.Count());
        return groups.Count() == 3 && groups.Where(x => x == 2).Count() == 2;
    }

    private static bool IsOnePair(char[] cards) => IsOfAKind(cards, 2);

    private static bool IsOfAKind(char[] cards, int number) => cards.GroupBy(x => x).Select(g => g.Count()).Max() == number;

    private static bool IsWinningHighCard(char[] cards, char[] otherCards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            var cardIndex = Array.IndexOf(Cards, cards[i]);
            var otherCardIndex = Array.IndexOf(Cards, otherCards[i]);

            if (cardIndex == otherCardIndex)
            {
                continue;
            }

            return cardIndex < otherCardIndex;
        }

        throw new InvalidOperationException($"Found a duplicate hand: {new string(cards)}");
    }

    private static void SwapHands(Hand[] hands, int i)
    {
        var temp = hands[i + 1];
        hands[i + 1] = hands[i];
        hands[i] = temp;
    }

    private static Hand[] GetHands(string[] inputLines)
    {
        var hands = new List<Hand>();
        foreach (var line in inputLines)
        {
            var lineParts = line.Split(' ');
            var cards = lineParts[0];
            var bid = int.Parse(lineParts[1]);
            var hand = new Hand(cards, bid);
            hands.Add(hand);
        }

        return hands.ToArray();
    }

    private class Hand
    {
        public Hand(string cards, int bid)
        {
            Cards = cards.ToCharArray();
            Bid = bid;
        }

        public char[] Cards { get; }

        public int Bid { get; }
    }
}
