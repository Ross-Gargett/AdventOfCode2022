// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay11Part1 : IProblemSolver
{
    private readonly MonkeyManager _monkeyManager;
    
    public ProblemSolverDay11Part1(IEnumerable<string> input)
    {
        _monkeyManager = new MonkeyManager(20, MonkeyPart.Part1);
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
            .Select(m => m.Inspections)
            .Aggregate((subtotal, m) => subtotal * m);
        
        return $"{monkeyBusiness}";
    }
}