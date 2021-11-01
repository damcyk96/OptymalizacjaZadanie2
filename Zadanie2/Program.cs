using System;
using Google.OrTools.LinearSolver;
using Fractions;
public class LinearProgrammingExample
{
    static void Main()
    {
        Solver solver = Solver.CreateSolver("GLOP");
        Variable x1 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x1");
        Variable x2 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x2");
        Variable x3 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x3");
        Variable x4 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x4");
        Variable x5 = solver.MakeNumVar(0.0, double.PositiveInfinity, "x5");

        solver.Add(3 * x1 + 5 * x2 + 2 * x3 + 5 * x4 + 4 * x5 <= 36);
        solver.Add(7 * x1 + 12 * x2 + 11 * x3 + 10 * x4 <= 21);
        solver.Add(-3 * x2 + 12 * x3 + 7 * x4 + 2 * x5 <= 17);
        solver.Add(0 <= x1);
        solver.Add(0 <= x2);
        solver.Add(0 <= x3);
        solver.Add(0 <= x4);
        solver.Add(0 <= x5);
        solver.Add(x1 <= 20);
        solver.Add(x2 <= 20);
        solver.Add(x3 <= 20);
        solver.Add(x4 <= 20);
        solver.Add(x5 <= 20);

        solver.Maximize(141 * x1 + 393 * x2 + 273 * x3 + 804 * x4 + 175 * x5);

        Solver.ResultStatus resultStatus = solver.Solve();

        Fraction x1Fraction = Fraction.FromDouble(x1.SolutionValue()).Reduce();
        Fraction x2Fraction = Fraction.FromDouble(x2.SolutionValue()).Reduce();
        Fraction x3Fraction = Fraction.FromDouble(x3.SolutionValue()).Reduce();
        Fraction x4Fraction = Fraction.FromDouble(x4.SolutionValue()).Reduce();
        Fraction x5Fraction = Fraction.FromDouble(x5.SolutionValue()).Reduce();
        Fraction resultFraction = Fraction.FromDouble(solver.Objective().Value()).Reduce();


        Console.WriteLine("Result: " + resultFraction);
        Console.WriteLine("x1 = " + x1Fraction);
        Console.WriteLine("x2 = " + x2Fraction);
        Console.WriteLine("x3 = " + x3Fraction);
        Console.WriteLine("x4 = " + x4Fraction);
        Console.WriteLine("x5 = " + x5Fraction);

    }
}