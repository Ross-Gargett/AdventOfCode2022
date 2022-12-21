namespace AdventOfCode2022.Models;

public class LongRopeSimulator
{
    private const int NumberOfKnots = 10;
    private const int TailTolerance = 1;
    
    private List<Motion> _motions; 
    private readonly HashSet<Position> _uniquePositions;

    private readonly List<Position> _knotPositions;

    public LongRopeSimulator(List<string> input)
    {
        ParseMotions(input);

        _uniquePositions = new HashSet<Position>();

        _knotPositions = new List<Position>(NumberOfKnots);

        for (var i = 0; i < NumberOfKnots; i++)
        {
            _knotPositions.Add(new Position(0, 0));
        }
    }

    private void ParseMotions(List<string> input)
    {
        _motions = new List<Motion>();
        
        foreach (var line in input)
        {
            _motions.Add(new Motion(line));
        }
    }

    public void Simulate()
    {
        foreach (var motion in _motions)
        {
            MakeMove(motion);
        }
    }

    private void MakeMove(Motion motion)
    {
        for (var i = 0; i < motion.Magnitude; i++)
        {
            MoveHead(motion.Direction);
            CatchupKnots();
            CaptureTailPosition();
        }
    }

    private void MoveHead(MotionDirection direction)
    {
        _knotPositions.ElementAt(0).Move(direction);
    }

    private void CatchupKnots()
    {
        for (var i = 1; i < NumberOfKnots; i++)
        {
            var knot = _knotPositions.ElementAt(i);
            var previousKnot = _knotPositions.ElementAt(i - 1);
            CatchupKnot(knot, previousKnot);
        }
    }

    private void CatchupKnot(Position knot, Position previousKnot)
    {
        if (OutOfVerticalRange(knot, previousKnot))
        {
            HandleVerticalMove(knot, previousKnot);
        }
        else if (OutOfHorizontalRange(knot, previousKnot))
        {
            HandleHorizontalMove(knot, previousKnot);
        }
    }

    private void CaptureTailPosition()
    {
        _uniquePositions.Add(new Position(_knotPositions.ElementAt(NumberOfKnots - 1)));
    }
    
    private void HandleVerticalMove(Position knot, Position previousKnot)
    {
        knot.Move(knot.Y > previousKnot.Y 
            ? MotionDirection.Down 
            : MotionDirection.Up);

        if (knot.X < previousKnot.X)
        {
            knot.Move(MotionDirection.Right);
        }
        else if (knot.X > previousKnot.X)
        {
            knot.Move(MotionDirection.Left);
        }
    }

    private void HandleHorizontalMove(Position knot, Position previousKnot)
    {
        knot.Move(knot.X > previousKnot.X 
            ? MotionDirection.Left 
            : MotionDirection.Right);

        if (knot.Y < previousKnot.Y)
        {
            knot.Move(MotionDirection.Up);
        }
        else if (knot.Y > previousKnot.Y)
        {
            knot.Move(MotionDirection.Down);
        }
    }

    private bool OutOfVerticalRange(Position knot, Position previousKnot)
    {
        return Math.Abs(knot.Y - previousKnot.Y) 
               > TailTolerance;
    }

    private bool OutOfHorizontalRange(Position knot, Position previousKnot)
    {
        return Math.Abs(knot.X - previousKnot.X) 
               > TailTolerance;
    }

    public int CountTailPositions()
    {
        return _uniquePositions.Count;
    }
}