namespace AdventOfCode2022.Models;

public class MonkeyManager
{
    private readonly List<Monkey> _monkeys;

    private const int NumberOfRounds = 20;
    
    public MonkeyManager()
    {
        _monkeys = new List<Monkey>();
    }

    public void AddMonkey(Monkey monkey)
    {
        _monkeys.Add(monkey);
    }

    public void Play()
    {
        for (var i = 0; i < NumberOfRounds; i++)
        {
            PlayARound();
        }
    }

    private void PlayARound()
    {
        foreach (var monkey in _monkeys)
        {
            var throws = monkey.InspectItems();

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