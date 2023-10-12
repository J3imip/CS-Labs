namespace Task6;

public readonly struct Point3D
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double CalculateDistanceToOrigin()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
}

internal static class Program
{
    public static void Main()
    {
        var point = new Point3D(3.0, 4.0, 5.0);

        var distanceToOrigin = point.CalculateDistanceToOrigin();

        Console.WriteLine($"Coordinates of the point: ({point.X}, {point.Y}, {point.Z})");
        Console.WriteLine($"Distance to the origin: {distanceToOrigin}");
    }
}