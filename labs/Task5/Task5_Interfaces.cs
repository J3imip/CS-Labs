namespace Task5;

internal interface IEquationSolver
{
    double[] Solve(double a, double b, Func<double, double> equation);
}

internal class BruteForceSolverInterface : IEquationSolver
{
    public double[] Solve(double a, double b, Func<double, double> equation)
    {
        const double step = 0.01;
        var roots = new List<double>();

        for (var x = a; x <= b; x += step)
        {
            if (equation(x) * equation(x + step) < 0)
            {
                roots.Add((x + x + step) / 2);
            }
        }

        return roots.ToArray();
    }
}