// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay2Part2 : IProblemSolver
{
    private readonly List<RockPaperScissorsRound2> _input = new();

    private Dictionary<GameMove, int> scores = new()
    {
        {GameMove.Rock, 1},
        {GameMove.Paper, 2},
        {GameMove.Scissors, 3}
    };

    public ProblemSolverDay2Part2(IEnumerable<string> input)
    {
        _input = input.Select(x => new RockPaperScissorsRound2 (x.Split(' '))).ToList();
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
            var moveToMake = DetermineMoveToMake(turn);
            
            score += scores[moveToMake];
            score += CalculateTurn(turn.OpponentMove, moveToMake);
        }

        return score;
    }

    private static int CalculateTurn(GameMove opponentMove, GameMove myMove)
    {
        if (myMove == opponentMove)
            return 3;

        return myMove switch
        {
            GameMove.Paper => opponentMove == GameMove.Scissors ? 0 : 6,
            GameMove.Rock => opponentMove == GameMove.Paper ? 0 : 6,
            GameMove.Scissors => opponentMove == GameMove.Rock ? 0 : 6,
            _ => 0
        };
    }
    
    
    private GameMove DetermineMoveToMake(RockPaperScissorsRound2 turn)
    {
        return turn.MyResult switch
        {
            GameResult.Win => WinningMove(turn.OpponentMove),
            GameResult.Lose => LosingMove(turn.OpponentMove),
            _ => turn.OpponentMove
        };
    }

    private GameMove WinningMove(GameMove opponentMove)
    {
        return opponentMove switch
        {
            GameMove.Paper => GameMove.Scissors,
            GameMove.Scissors => GameMove.Rock,
            _ => GameMove.Paper
        };
    }
    
    private GameMove LosingMove(GameMove opponentMove)
    {
        return opponentMove switch
        {
            GameMove.Paper => GameMove.Rock,
            GameMove.Scissors => GameMove.Paper,
            _ => GameMove.Scissors
        };
    }
}