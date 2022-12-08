﻿// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solvers.DaySolvers;

namespace AdventOfCode2022.Solvers;

public interface IProblemSolverBuilder
{
    IProblemSolverBuilder ForDay(int day);
    IProblemSolverBuilder ForPart(int part);
    IProblemSolver Build();
}

public class ProblemSolverBuilder : IProblemSolverBuilder
{
    private int _day;
    private int _part;

    public IProblemSolver Build()
    {
        var input = ReadInput();

        return (_day, _part) switch
        {
            (1, 1) => new ProblemSolverDay1Part1(input),
            (1, 2) => new ProblemSolverDay1Part2(input),
			(2, 1) => new ProblemSolverDay2Part1(input),
            (2, 2) => new ProblemSolverDay2Part2(input),
            (3, 1) => new ProblemSolverDay3Part1(input),
            (3, 2) => new ProblemSolverDay3Part2(input),
            (4, 1) => new ProblemSolverDay4Part1(input),
            (4, 2) => new ProblemSolverDay4Part2(input),
            (5, 1) => new ProblemSolverDay5Part1(input),
            (5, 2) => new ProblemSolverDay5Part2(input),
            (6, 1) => new ProblemSolverDay6Part1(input),
            (6, 2) => new ProblemSolverDay6Part2(input),
            _ => throw new ArgumentOutOfRangeException("")
        };
    }

    private string[] ReadInput()
    {
        var path = Path.Combine("Input", $"Day{_day}", $"{_part}.txt");
        return File.ReadAllLines(path);
    }

    public IProblemSolverBuilder ForDay(int day)
    {
        _day = day;
        return this;
    }

    public IProblemSolverBuilder ForPart(int part)
    {
        _part = part;
        return this;
    }
}