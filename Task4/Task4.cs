namespace Task4 {
	class QuadraticEquation
	{
		private double? root1;
		private double? root2;

		public QuadraticEquation(double a, double b, double c)
		{
			double discriminant = b * b - 4 * a * c;

			if (discriminant >= 0)
			{
				root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
				root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
			}
		}

		public double? Root1
		{
			get { return root1; }
		}

		public double? Root2
		{
			get { return root2; }
		}

		public double? this[int index]
		{
			get
			{
				if (index == 0)
				{
					return root1;
				}
				else if (index == 1)
				{
					return root2;
				}
				else
				{
					return null; 
				}
			}
		}
	}
	static class Program { 
		static void Main(string[] args) {
			do {
				try {
					Console.Write("Enter a, b, c of the quadratic equation (Example: 2 4 6): ");
					string? input = Console.ReadLine();
					int[] numbers = Array.ConvertAll(input.Split(" "), s => int.Parse(s));

					QuadraticEquation qe = new QuadraticEquation(numbers[0], numbers[1], numbers[2]);

					Console.WriteLine(
						$"1st root: {qe[0]}\n" +
						$"2nd root: {qe[1]}"
					);

				} catch (Exception ex) {
					Console.Error.WriteLine(ex.Message);
				}
			} while (true);
		}
	}
}