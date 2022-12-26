namespace AdventOfCode2022.Models;

public class MonkeyManager
{
    private readonly List<Monkey> _monkeys;

    private readonly MonkeyPart _part;
    private double _commonFactor;
    private int _numberOfRounds;
    
    public MonkeyManager(int numRounds,
                         MonkeyPart part)
    {
        _monkeys = new List<Monkey>();

        _numberOfRounds = numRounds;
        _part = part;
    }

    public void AddMonkey(Monkey monkey)
    {
        _monkeys.Add(monkey);

        if (_part == MonkeyPart.Part2)
        {
            _commonFactor = _monkeys
                .Select(m => m.DivisibilityTest)
                .Aggregate((f1, f2) => f1 * f2);
        }
    }

    public void Play()
    {
        for (var i = 0; i < _numberOfRounds; i++)
        {
            PlayARound();
        }
    }

    private void PlayARound()
    {
        foreach (var monkey in _monkeys)
        {
            var throws = monkey.InspectItems(_commonFactor, _part);

            foreach (var thr in throws)
            {
                _monkeys[thr.Target].AddItem(thr.Item);
            }
        }
    }

    public IEnumerable<Monkey> GetMostActiveMonkeys(int i)
    {
        return _monkeys
            .OrderByDescending(m => m.Inspections)
            .Take(i);
    }
}

public enum MonkeyPart
{
    Part1,
    Part2
}