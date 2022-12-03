namespace AdventOfCode2022;

public class RockPaperScissorsRound
{
    public RockPaperScissorsRound(string[] split)
    {
        OpponentMove = split[0] switch
        {
            "A" => GameMove.Rock,
            "B" => GameMove.Paper,
            "C" => GameMove.Scissors,
            _ => OpponentMove
        };

        MyMove = split[1] switch
        {
            "X" => GameMove.Rock,
            "Y" => GameMove.Paper,
            "Z" => GameMove.Scissors,
            _ => MyMove
        };
    }

    public GameMove OpponentMove { get; set; }
    public GameMove MyMove { get; set; }
}

public class RockPaperScissorsRound2
{
    public RockPaperScissorsRound2(string[] split)
    {
        OpponentMove = split[0] switch
        {
            "A" => GameMove.Rock,
            "B" => GameMove.Paper,
            "C" => GameMove.Scissors,
            _ => OpponentMove
        };

        MyResult = split[1] switch
        {
            "X" => GameResult.Lose,
            "Y" => GameResult.Draw,
            "Z" => GameResult.Win,
            _ => MyResult
        };
    }

    public GameMove OpponentMove { get; set; }
    public GameResult MyResult { get; set; }
}

public enum GameMove
{
    Rock,
    Paper,
    Scissors
}

public enum GameResult
{
    Win,
    Lose,
    Draw
}