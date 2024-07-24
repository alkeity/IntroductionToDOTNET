#define TREE_BASE_CHECK
//#define INITIALIZER_CHECK
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Program
	{
		static readonly string delimiter = "\n-----------------------------\n";
		static void Main(string[] args)
		{
			Random rand = new Random();
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
#if TREE_BASE_CHECK
			Tree tree = new Tree();

			for (int i = 0; i < n; i++)
			{
				tree.Insert(rand.Next(100));
			}

			Console.WriteLine(delimiter);
			tree.Print();
			Console.WriteLine("MinValue: " + tree.MinValue());
			Console.WriteLine("MaxValue: " + tree.MaxValue());
			Console.WriteLine("Count: " + tree.Count());
			Console.WriteLine("Sum: " + tree.Sum());
			Console.WriteLine("Avg: " + tree.Avg());
			Console.WriteLine("Height: " + tree.Height());
			Console.WriteLine(delimiter);

			//Console.WriteLine("Value to delete: ");
			//int val = Convert.ToInt32(Console.ReadLine());
			//tree.Erase(val);
			//tree.Print();
			//Console.WriteLine(delimiter);

			tree.Balance();
			Console.WriteLine("Balanced tree:");
			tree.Print();

			//tree.Clear();
			//Console.WriteLine("Tree clear. Print:");
			//tree.Print();
			//Console.WriteLine(delimiter);
#endif
#if INITIALIZER_CHECK
			try
			{
				UniqueTree uTree = new UniqueTree() { 13, 25, 17, 100, 56 };

				//for (int i = 0; i < n; i++)
				//{
				//	uTree.Insert(rand.Next(100));
				//}
				uTree.Print();
			}
			catch (Exception)
			{
				throw;
			}
#endif
#if TREE_PERFORMANCE
			Tree tree = new Tree();

			for (int i = 0; i < n; i++)
			{
				tree.Insert(rand.Next(100));
			}
			Console.WriteLine(delimiter);

			//tree.Print();
			#region NoDelegatePerformanceCheck
			//Stopwatch sw = new Stopwatch();
			//Console.WriteLine("MinValue: " + tree.MinValue());
			//Console.WriteLine("MaxValue: " + tree.MaxValue());
			//Console.WriteLine("Count: " + tree.Count());
			//Console.WriteLine("Sum: " + tree.Sum());
			//Console.WriteLine("Avg: " + tree.Avg());
			//sw.Start();
			//Console.WriteLine("Height: " + tree.Height());
			//sw.Stop();
			//Console.WriteLine($"Вычислено за {sw.Elapsed.TotalMilliseconds} ms");
			//Console.WriteLine(delimiter);
			#endregion

			TreePerformance<int>.Measure("Минимальное значение в дереве", tree.MinValue);
			TreePerformance<int>.Measure("Максимальное значение в дереве", tree.MaxValue);
			TreePerformance<int>.Measure("Сумма элементов дерева", tree.Sum);
			TreePerformance<int>.Measure("Количество элементов дерева", tree.Count);
			TreePerformance<double>.Measure("Cреднее арифметическое элементов дерева", tree.Avg); 
#endif

		}
	}
}
