namespace Task2 { 
	static class Program {
		static void Main(string[] args) {
			do {
				try {
					Console.Write("Enter number: ");

					string? inputStr = Console.ReadLine();
					if (!double.TryParse(inputStr, out double input)) throw new Exception("input type mismatch");

					double? result = CalculateSquareRoot(input, out int errorCode);

					switch (errorCode) { 
						case 0:
							Console.WriteLine($"Square root of {input} = {result.Value.ToString("F")}\n");
							break;
						case -1:
							throw new Exception("input number must be greater than 0");
						default:
							throw new Exception("unable to calculate square root");
					}
				} catch (Exception ex) {
					Console.Error.WriteLine(ex.Message + "\n");
				}
			} while (true);
		}

		static double? CalculateSquareRoot(double x, out int errorCode) {
			errorCode = 0;

			if (x < 0) {
				errorCode = -1;
				return null;
			}

			if (x == 0) return 0;

			double guess = x / 2.0;

			while (true) {
				double newGuess = (guess + x / guess) / 2.0;
				if (Math.Abs(newGuess - guess) < 0.000001) return newGuess; 
				guess = newGuess;
			}
		}
	}
}