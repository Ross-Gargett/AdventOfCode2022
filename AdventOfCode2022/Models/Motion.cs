namespace AdventOfCode2022.Models;

public class Motion
{
    public Motion(string motion)
    {
        var splitMotion = motion.Split(" ");

        Direction = splitMotion[0] switch
        {
            "U" => MotionDirection.Up,
            "D" => MotionDirection.Down,
            "L" => MotionDirection.Left,
            "R" => MotionDirection.Right,
            _ => Direction
        };

        Magnitude = int.Parse(splitMotion[1]);
    }
    
    public MotionDirection Direction { get; set; }
    public int Magnitude { get; set; }
}

public enum MotionDirection
{
    Up,
    Down,
    Left,
    Right
}