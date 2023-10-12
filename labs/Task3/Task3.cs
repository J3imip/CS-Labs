namespace Task3;

public class Complex
{
    private double Real { get; }
    private double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(
            a.Real * b.Real - a.Imaginary * b.Imaginary,
            a.Real * b.Imaginary + a.Imaginary * b.Real
        );
    }

    public static Complex operator /(Complex a, Complex b)
    {
        var denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        return new Complex(
            (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
            (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator
        );
    }

    public static implicit operator string(Complex c)
    {
        return $"{c.Real} + {c.Imaginary}i";
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

internal static class Program
{
    private static void Main()
    {
        var complex1 = new Complex(2, 3);
        var complex2 = new Complex(1, 4);

        var sum = complex1 + complex2;
        var difference = complex1 - complex2;
        var product = complex1 * complex2;
        var quotient = complex1 / complex2;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Quotient: {quotient}");

        // Implicit cast
        string complexString = complex1;
        Console.WriteLine($"Complex as string: {complexString}");
    }
}