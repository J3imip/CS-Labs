namespace Task3 {
	class Program
	{
		static void Main() {
			do {
				try {
					Console.Write("Enter 2 numbers (Example: 48 12): ");
					string? input = Console.ReadLine();
					int[] nums = Array.ConvertAll(input.Split(" "), i => int.Parse(i));

					Console.WriteLine($"Numbers before calculating GCD: num1 = {nums[0]}, num2 = {nums[1]}");

					int gcd = CalculateGCD(ref nums[0], ref nums[1]);

					Console.WriteLine($"Greatest Common Divisor: {gcd}");
				}
				catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			} while (true);
		}

		static int CalculateGCD(ref int a, ref int b)
		{
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}

			return a;
		}
	}
}