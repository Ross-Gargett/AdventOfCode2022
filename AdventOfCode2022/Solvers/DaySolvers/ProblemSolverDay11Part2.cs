// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay11Part2 : IProblemSolver
{
    private readonly MonkeyManager _monkeyManager;
    
    public ProblemSolverDay11Part2(IEnumerable<string> input)
    {
        _monkeyManager = new MonkeyManager(10000, MonkeyPart.Part2);
        ParseMonkeys(input);
    }

    private void ParseMonkeys(IEnumerable<string> input)
    {
        var chunked = input.Chunk(7);
        
        foreach (var chunk in chunked)
        {
            var monkey = MonkeyParser.ParseMonkey(chunk);

            _monkeyManager.AddMonkey(monkey);
        }
    }

    public string Solve()
    {
        _monkeyManager.Play();
        
        var activeMonkeys = _monkeyManager.GetMostActiveMonkeys(2);

        var monkeyBusiness = activeMonkeys
            .Select(m => (long)m.Inspections)
            .Aggregate((subtotal, m) => subtotal * m);
        
        return $"{monkeyBusiness}";
    }
}