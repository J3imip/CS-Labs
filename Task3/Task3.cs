namespace Task3 {
	class Program
	{
		static void Main(string[] args) { 
			int number1 = 48, number2 = 18;

			Console.WriteLine($"Before GCD calculation: number1 = {number1}, number2 = {number2}");

			ComputeGCD(ref number1, ref number2);

			Console.WriteLine($"After GCD calculation: number1 = {number1}, number2 = {number2}");
		}

		static void ComputeGCD(ref int a, ref int b) {
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}
		}
	}
}