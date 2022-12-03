namespace AdventOfCode2022
{
    public static class Day2
        {
            private enum Play
            {
                Rock = 1,
                Paper = 2,
                Scissors = 3
            }

            private enum Result
            {
                Lose = 0,
                Draw = 3,
                Win = 6
            }

            public static int GetRockPaperScissorScoreWithStrategy1(string[] inputLines)
            {
                var score = 0;

                foreach (var inputLine in inputLines)
                {
                    var inputLineParts = inputLine.Split(' ');
                    var opponentPlay = inputLineParts[0];
                    var myPlay = inputLineParts[1];
                    score += GetScoreForRound(GetPlay(opponentPlay), GetPlay(myPlay));
                }

                return score;
            }

            private static Play GetPlay(string play) =>
                play == "A" || play == "X"
                    ? Play.Rock
                    : play == "B" || play == "Y"
                        ? Play.Paper
                        : Play.Scissors;

            private static Result GetResult(string result) =>
                result == "X"
                    ? Result.Lose
                    : result == "Y"
                        ? Result.Draw
                        : Result.Win;

            private static int GetScoreForRound(Play opponentPlay, Play myPlay)
            {
                var selectionScore = GetSelectionScore(myPlay);
                var playScore = GetPlayScore(opponentPlay, myPlay);
                return selectionScore + playScore;
            }

            private static int GetSelectionScore(Play play) => (int)play;

            private static int GetPlayScore(Play opponentPlay, Play myPlay)
            {
                if ((opponentPlay == myPlay))
                {
                    return 3;
                }

                if (myPlay == Play.Rock && opponentPlay == Play.Scissors ||
                    myPlay == Play.Scissors && opponentPlay == Play.Paper ||
                    myPlay == Play.Paper && opponentPlay == Play.Rock)
                {
                    return 6;
                }

                return 0;
            }

            public static int GetRockPaperScissorScoreWithStrategy2(string[] inputLines)
            {
                var score = 0;

                foreach (var inputLine in inputLines)
                {
                    var inputLineParts = inputLine.Split(' ');
                    var opponentPlay = inputLineParts[0];
                    var result = inputLineParts[1];
                    score += GetScoreForRound(GetPlay(opponentPlay), GetResult(result));
                }

                return score;
            }

            private static int GetScoreForRound(Play opponentPlay, Result result)
            {
                var myPlay = GetPlayFromResult(opponentPlay, result);
                return GetScoreForRound(opponentPlay, myPlay);
            }

            private static Play GetPlayFromResult(Play opponentPlay, Result result)
            {
                if (result == Result.Draw)
                {
                    return opponentPlay;
                }

                if (result == Result.Win)
                {
                    return opponentPlay == Play.Rock
                        ? Play.Paper
                        : opponentPlay == Play.Scissors
                            ? Play.Rock
                            : Play.Scissors;
                }

                return opponentPlay == Play.Rock
                    ? Play.Scissors
                    : opponentPlay == Play.Scissors
                        ? Play.Paper
                        : Play.Rock;
            }
        }
}