namespace Task5;

public abstract class EquationSolver
{
    public abstract double[] Solve(double a, double b, Func<double, double> equation);
}

internal class BruteForceSolverAbstract : EquationSolver
{
    public override double[] Solve(double a, double b, Func<double, double> equation)
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

// class Program
// {
//     static void Main()
//     {
//         EquationSolver solver = new BruteForceSolver();
//
//         // Приклад: рівняння x^2 - 4 = 0
//         double a = -5;
//         double b = 5;
//         double[] roots = solver.Solve(a, b, x => x * x - 4);
//
//         Console.WriteLine("Roots of x^2 - 4 = 0:");
//         foreach (double root in roots)
//         {
//             Console.WriteLine(root);
//         }
//     }
// }