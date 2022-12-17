﻿// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Helpers;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay8Part2 : IProblemSolver
{
    private readonly Forest _forest;
    
    public ProblemSolverDay8Part2(IEnumerable<string> input)
    {
        _forest = new Forest(input.ToList());
    }

    public string Solve()
    {
        return $"{_forest.GetHighestScenicScore()}";
    }
}