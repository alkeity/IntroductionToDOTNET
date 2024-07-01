using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Random rnd = new Random();
			int[] simpleArray = new int[10];
			int[,] multiArray = new int[5, 3];
			int[][] jaggedArray = new int[5][];

			FillArray(simpleArray, 30, 131);
			FillArray(multiArray, -20, 10);
			FillArray(jaggedArray, 140, 160);

			PrintArray(simpleArray);
			Console.WriteLine("Sum: " + ArraySum(simpleArray));
			Console.WriteLine("Average: " + ArrayAvg(simpleArray));
			Console.WriteLine("Min value: " + ArrayMin(simpleArray));
			Console.WriteLine("Max value: " + ArrayMax(simpleArray));
			Console.WriteLine();
			PrintArray(multiArray);
			Console.WriteLine("Sum: " + ArraySum(multiArray));
			Console.WriteLine("Average: " + ArrayAvg(multiArray));
			Console.WriteLine("Min value: " + ArrayMin(multiArray));
			Console.WriteLine("Max value: " + ArrayMax(multiArray));
			Console.WriteLine();
			PrintArray(jaggedArray);
			Console.WriteLine("Sum: " + ArraySum(jaggedArray));
			Console.WriteLine("Average: " + ArrayAvg(jaggedArray));
			Console.WriteLine("Min value: " + ArrayMin(jaggedArray));
			Console.WriteLine("Max value: " + ArrayMax(jaggedArray));
			Console.WriteLine("\n");

			int[] smolArray = new int[100];
			FillArray(smolArray, 10, 20);
			PrintArray(smolArray);
			Dictionary<int, int> reps = new Dictionary<int, int>();
			FindRepeats(smolArray, reps);
			Console.WriteLine("Items and repeats, simple array:");
			foreach (KeyValuePair<int, int> pair in reps)
			{
				Console.WriteLine($"{pair.Key}: {pair.Value}");
			}
			reps.Clear();
			Console.WriteLine();

			FindRepeats(multiArray, reps);
			Console.WriteLine("Items and repeats, multidimensional array:");
			foreach (KeyValuePair<int, int> pair in reps)
			{
				Console.WriteLine($"{pair.Key}: {pair.Value}");
			}
			reps.Clear();
			Console.WriteLine();

			FindRepeats(jaggedArray, reps);
			Console.WriteLine("Items and repeats, jagged array:");
			foreach (KeyValuePair<int, int> pair in reps)
			{
				Console.WriteLine($"{pair.Key}: {pair.Value}");
			}
		}

		static void FindRepeats(int[] arr, Dictionary<int, int> valueRepeats)
		{
			foreach (int item in arr)
			{
				try
				{
					valueRepeats.Add(item, 1);
				}
				catch (ArgumentException)
				{
					valueRepeats[item]++;
				}
			}
		}

		static void FindRepeats(int[,] arr, Dictionary<int, int> valueRepeats)
		{
			foreach (int item in arr)
			{
				try
				{
					valueRepeats.Add(item, 1);
				}
				catch (ArgumentException)
				{
					valueRepeats[item]++;
				}
			}
		}

		static void FindRepeats(int[][] arr, Dictionary<int, int> valueRepeats)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr[i].Length; j++)
				{
					try
					{
						valueRepeats.Add(arr[i][j], 1);
					}
					catch (ArgumentException)
					{
						valueRepeats[arr[i][j]]++;
					}
				}
			}
		}

		static int ArraySum(int[] arr)
		{
			int summ = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				summ += arr[i];
			}
			return summ;
		}

		static int ArraySum(int[,] arr)
		{
			int summ = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					summ += arr[i, j];
				}
			}
			return summ;
		}

		static int ArraySum(int[][] arr)
		{
			int summ = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				summ += ArraySum(arr[i]);
			}
			return summ;
		}

		static int ArrayAvg(int[] arr)
		{
			return ArraySum(arr) / arr.Length;
		}

		static int ArrayAvg(int[,] arr)
		{
			return ArraySum(arr) / (arr.GetLength(0) * arr.GetLength(1));
		}

		static int ArrayAvg(int[][] arr)
		{
			int count = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				count += arr[i].Length;
			}
			return ArraySum(arr) / count;
		}

		static int ArrayMin(int[] arr)
		{
			int min = arr[0];
			foreach (int i in arr)
			{
				if (i < min) min = i;
			}
			return min;
		}

		static int ArrayMin(int[,] arr)
		{
			int min = arr[0,0];
			foreach (int i in arr)
			{
				if (i < min) min = i;
			}
			return min;
		}

		static int ArrayMin(int[][] arr)
		{
			int min = ArrayMin(arr[0]);
			int temp;
			for (int i = 1; i < arr.Length; i++)
			{
				temp = ArrayMin(arr[i]);
				if (temp < min) min = temp;
			}
			return min;
		}

		static int ArrayMax(int[] arr)
		{
			int max = arr[0];
			foreach (int i in arr)
			{
				if (i > max) max = i;
			}
			return max;
		}

		static int ArrayMax(int[,] arr)
		{
			int max = arr[0, 0];
			foreach (int i in arr)
			{
				if (i > max) max = i;
			}
			return max;
		}

		static int ArrayMax(int[][] arr)
		{
			int max = ArrayMax(arr[0]);
			int temp;
			for (int i = 1; i < arr.Length; i++)
			{
				temp = ArrayMax(arr[i]);
				if (temp > max) max = temp;
			}
			return max;
		}

		static void FillArray(int[] arr, int start, int end)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(start, end);
			}
		}

		static void FillArray(int[,] arr, int start, int end)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[i, j] = rnd.Next(start, end);
				}
			}
		}

		static void FillArray(int[][] arr, int start, int end)
		{
			Random rnd = new Random();
			int len;
			for (int i = 0; i < arr.Length; i++)
			{
				len = rnd.Next(2, 7);
				arr[i] = new int[len];
				for (int j = 0; j < len; j++)
				{
					arr[i][j] = rnd.Next(start, end);
				}
			}
		}

		static void PrintArray(int[] arr)
		{
			foreach (int i in arr)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}

		static void PrintArray(int[,] arr)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					Console.Write(arr[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		static void PrintArray(int[][] arr)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr[i].Length; j++)
				{
					Console.Write(arr[i][j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
