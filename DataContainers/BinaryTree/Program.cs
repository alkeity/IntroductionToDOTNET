using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random();
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Tree tree = new Tree();

			for (int i = 0; i < n; i++)
			{
				tree.Insert(rand.Next(100));
			}
			tree.Print();

			Console.WriteLine("MinValue:" + tree.MinValue());
			Console.WriteLine("MaxValue:" + tree.MaxValue());
			Console.WriteLine("Count:" + tree.Count());
			Console.WriteLine("Sum:" + tree.Sum());
			Console.WriteLine("Avg:" + tree.Avg());
		}
	}
}
