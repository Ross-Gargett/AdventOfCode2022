namespace AdventOfCode2022.Models;

public class RopeSimulator
{
    private const int TailTolerance = 1;
    
    private List<Motion> _motions; 
    private readonly HashSet<Position> _tailPositions;

    private readonly Position _tailPosition;
    private readonly Position _headPosition;

    public RopeSimulator(List<string> input)
    {
        ParseMotions(input);

        _tailPositions = new HashSet<Position>();

        _tailPosition = new Position(0, 0);
        _headPosition = new Position(0, 0);
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
            _headPosition.Move(motion.Direction);
            CatchupTail();
            CaptureTailPosition();
        }
    }

    private void CatchupTail()
    {
        if (OutOfVerticalRange())
        {
            HandleVerticalMove();
        }
        else if (OutOfHorizontalRange())
        {
            HandleHorizontalMove();
        }
    }

    private void CaptureTailPosition()
    {
        _tailPositions.Add(new Position(_tailPosition));
    }
    
    private void HandleVerticalMove()
    {
        _tailPosition.Move(_tailPosition.Y > _headPosition.Y 
            ? MotionDirection.Down 
            : MotionDirection.Up);

        if (_tailPosition.X < _headPosition.X)
        {
            _tailPosition.Move(MotionDirection.Right);
        }
        else if (_tailPosition.X > _headPosition.X)
        {
            _tailPosition.Move(MotionDirection.Left);
        }
    }

    private void HandleHorizontalMove()
    {
        _tailPosition.Move(_tailPosition.X > _headPosition.X 
            ? MotionDirection.Left 
            : MotionDirection.Right);

        if (_tailPosition.Y < _headPosition.Y)
        {
            _tailPosition.Move(MotionDirection.Up);
        }
        else if (_tailPosition.Y > _headPosition.Y)
        {
            _tailPosition.Move(MotionDirection.Down);
        }
    }

    private bool OutOfVerticalRange()
    {
        return Math.Abs(_tailPosition.Y - _headPosition.Y) 
               > TailTolerance;
    }

    private bool OutOfHorizontalRange()
    {
        return Math.Abs(_tailPosition.X - _headPosition.X) 
               > TailTolerance;
    }

    public int CountTailPositions()
    {
        return _tailPositions.Count;
    }
}