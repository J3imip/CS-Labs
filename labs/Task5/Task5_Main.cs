namespace Task5;

internal static class Program
{
    public static void Main()
    {
        IEquationSolver solverI = new BruteForceSolverInterface();
        EquationSolver solverA = new BruteForceSolverAbstract();

        const double a = -5;
        const double b = 5;
        var rootsI = solverI.Solve(a, b, x => x * x - 4);
        var rootsA = solverA.Solve(a, b, x => x * x - 4);

        Console.WriteLine("Roots of x^2 - 4 = 0, interfaces approach:");
        foreach (var root in rootsI) Console.WriteLine(root);

        Console.WriteLine("\nRoots of x^2 - 4 = 0, abstract classes approach:");
        foreach (var root in rootsA) Console.WriteLine(root);
    }
}