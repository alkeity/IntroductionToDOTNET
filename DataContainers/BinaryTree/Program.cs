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
				tree.Insert(rand.Next(100), tree.root);
			}
			tree.Print(tree.root);
		}
	}
}
