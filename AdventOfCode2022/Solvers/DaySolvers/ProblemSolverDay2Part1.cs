// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay2Part1 : IProblemSolver
{
    private readonly List<RockPaperScissorsRound> _input = new();

    private Dictionary<GameMove, int> scores = new()
    {
        {GameMove.Rock, 1},
        {GameMove.Paper, 2},
        {GameMove.Scissors, 3}
    };

    public ProblemSolverDay2Part1(IEnumerable<string> input)
    {
        _input = input.Select(x => new RockPaperScissorsRound (x.Split(' '))).ToList();
    }

    public string Solve()
    {
        return $"{CalculateScore()}";
    }

    private int CalculateScore()
    {
        var score = 0;
        
        foreach (var turn in _input)
        {
            score += scores[turn.MyMove];
            score += CalculateTurn(turn);
        }

        return score;
    }

    private static int CalculateTurn(RockPaperScissorsRound turn)
    {
        if (turn.MyMove == turn.OpponentMove)
            return 3;

        return turn.MyMove switch
        {
            GameMove.Paper => turn.OpponentMove == GameMove.Scissors ? 0 : 6,
            GameMove.Rock => turn.OpponentMove == GameMove.Paper ? 0 : 6,
            GameMove.Scissors => turn.OpponentMove == GameMove.Rock ? 0 : 6,
            _ => 0
        };
    }
}