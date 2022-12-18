// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay9Part1 : IProblemSolver
{
    private readonly RopeSimulator _simulator;
    
    public ProblemSolverDay9Part1(IEnumerable<string> input)
    {
        _simulator = new RopeSimulator(input.ToList());
    }

    public string Solve()
    {
        _simulator.Simulate();
        
        return $"{_simulator.CountTailPositions()}";
    }
}