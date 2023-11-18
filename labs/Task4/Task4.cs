namespace Task4;

using System.Text;

public class Vector
{
    private readonly double[] _components;

    private Vector(int dimension)
    {
        _components = new double[dimension];
    }

    public Vector(params double[] values)
    {
        _components = new double[values.Length];
        for (var i = 0; i < values.Length; i++)
        {
            _components[i] = values[i];
        }
    }

    private int Dimension => _components.Length;

    private double this[int index]
    {
        get => _components[index];
        set => _components[index] = value;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Dimension != v2.Dimension)
            throw new ArgumentException("Vectors must have the same dimension.");

        var result = new Vector(v1.Dimension);
        for (var i = 0; i < v1.Dimension; i++)
        {
            result[i] = v1[i] + v2[i];
        }
        return result;
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
        if (v1.Dimension != v2.Dimension)
            throw new ArgumentException("Vectors must have the same dimension.");

        var result = new Vector(v1.Dimension);
        for (var i = 0; i < v1.Dimension; i++)
        {
            result[i] = v1[i] - v2[i];
        }
        return result;
    }

    public static Vector operator *(Vector v, double scalar)
    {
        var result = new Vector(v.Dimension);
        for (var i = 0; i < v.Dimension; i++)
        {
            result[i] = v[i] * scalar;
        }
        return result;
    }

    public static double operator *(Vector v1, Vector v2)
    {
        if (v1.Dimension != v2.Dimension)
            throw new ArgumentException("Vectors must have the same dimension.");

        double dotProduct = 0;
        for (var i = 0; i < v1.Dimension; i++)
        {
            dotProduct += v1[i] * v2[i];
        }
        return dotProduct;
    }

    public static Vector operator /(Vector v, double scalar)
    {
        var result = new Vector(v.Dimension);
        for (var i = 0; i < v.Dimension; i++)
        {
            result[i] = v[i] / scalar;
        }
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append('(');
        for (var i = 0; i < Dimension; i++)
        {
            sb.Append(_components[i]);
            if (i < Dimension - 1)
            {
                sb.Append(", ");
            }
        }
        sb.Append(')');
        return sb.ToString();
    }
}

internal static class Program
{
    public static void Main()
    {
        try
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(4, 5, 6);
            var v3 = new Vector(2, 2, 2);

            Console.WriteLine("v1 = " + v1);
            Console.WriteLine("v2 = " + v2);
            Console.WriteLine("v3 = " + v3);

            var sum = v1 + v2;
            Console.WriteLine("Sum: " + sum);

            var difference = v1 - v2;
            Console.WriteLine("Difference: " + difference);

            const double scalar = 2.5;
            var scaled = v1 * scalar;
            Console.WriteLine("Scaled: " + scaled);

            var dotProduct = v1 * v2;
            Console.WriteLine("Dot Product: " + dotProduct);

            var divided = v1 / scalar;
            Console.WriteLine("Divided: " + divided);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
