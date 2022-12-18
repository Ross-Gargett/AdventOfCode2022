namespace AdventOfCode2022.Models;

public class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Position(Position position)
    {
        X = position.X;
        Y = position.Y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Position position) 
        {
            return false;
        }

        return position.X == X
            && position.Y == Y;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + X;
            hash = hash * 23 + Y;
            return hash;
        }
    }

    public void Move(MotionDirection direction)
    {
        switch (direction)
        {
            case MotionDirection.Up:
                Y += 1;
                break;
            case MotionDirection.Down:
                Y -= 1;
                break;
            case MotionDirection.Left:
                X -= 1;
                break;
            case MotionDirection.Right:
                X += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}