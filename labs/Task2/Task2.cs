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
        const string se = "the    hardest     program   in    the    world";
        Console.WriteLine(se.RemoveExtraSpaces());
    }
}