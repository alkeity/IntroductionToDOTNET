#define TREE_BASE_CHECK
using System;
using System.Collections.Generic;
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
#if TREE_BASE_CHECK
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
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

			Console.WriteLine("Value to delete: ");
			int val = Convert.ToInt32(Console.ReadLine());
			tree.Erase(val);
			tree.Print();
			Console.WriteLine(delimiter);

			tree.Clear();
			Console.WriteLine("Tree clear. Print:");
			tree.Print();
			Console.WriteLine(delimiter);

			//UniqueTree uTree = new UniqueTree();

			//for (int i = 0; i < n; i++)
			//{
			//	uTree.Insert(rand.Next(100));
			//}
			//uTree.Print(); 
#endif
			//Tree tree = new Tree() { 3, 5, 8, 13, 21 };
		}
	}
}
