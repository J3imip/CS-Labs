namespace Task5 {
	static class Program {
		static void Main(string[] args) {
			int[,] array2D = {
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

			int[][] unevenArray = CreateUnevenArray(array2D);

			Console.WriteLine("Default 2D array:");
			Print2DArray(array2D);

			Console.WriteLine("\nUneven array:");
			PrintUnevenArray(unevenArray);
		}

		static int[][] CreateUnevenArray(int[,] array2D) {
			int rows = array2D.GetLength(0);
			int[][] unevenArray = new int[rows][];

			for (int i = 0; i < rows; i++) {
				int cols = array2D.GetLength(1);
				int unevenCount = 0;

				for (int j = 0; j < cols; j++) {
					if (array2D[i, j] % 2 == 0) unevenCount++;
				}

				unevenArray[i] = new int[unevenCount];
			}

			for (int i = 0; i < rows; i++) {
				int cols = array2D.GetLength(1);
				int k = 0;

				for (int j = 0; j < cols; j++) {
					if (array2D[i, j] % 2 == 0)
						unevenArray[i][k++] = array2D[i, j];
				}
			}

			return unevenArray;
		}

		static void Print2DArray(int[,] array) {
			int rows = array.GetLength(0);
			int cols = array.GetLength(1);

			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) Console.Write(array[i, j] + " ");
				Console.WriteLine();
			}
		}

		static void PrintUnevenArray(int[][] array) {
			int rows = array.Length;

			for (int i = 0; i < rows; i++) {
				int cols = array[i].Length;

				for (int j = 0; j < cols; j++) Console.Write(array[i][j] + " ");
				Console.WriteLine();
			}
		}
	}
}