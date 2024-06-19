using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
	internal class Program
	{
		static ulong Factorial(uint number)
		{
			return number <= 1 ? 1 : number * Factorial(number - 1);
		}

		static ulong Power(uint number, uint power)
		{
			return power == 0 ? 0 :
				power == 1 ? number :
				number * Power(number, power - 1);
		}

		static void Main(string[] args)
		{
			uint num = 12, power = 6;
			Console.WriteLine($"Факториал числа {num}: {Factorial(num)}");
			Console.WriteLine($"{num} в {power} степени: {Power(num, power)}");
		}
	}
}
