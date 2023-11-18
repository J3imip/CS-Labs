namespace Task2;

internal static class StringExtensions
{
    internal static string RemoveExtraSpaces(this string? input)
    {
        if (input == null) return null;

        var parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", parts);
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter string to process: ");
        var input = Console.ReadLine();
        Console.Write("Result: ");
        Console.WriteLine(input.RemoveExtraSpaces());
    }
}