using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class TreePerformance<T>
	{
		public delegate T Method();
		public static void Measure(string message, Method method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			T value = method();
			sw.Stop();
			Console.WriteLine($"{message}: {value}, вычислено за {sw.Elapsed.TotalMilliseconds} ms");
		}
	}
}
