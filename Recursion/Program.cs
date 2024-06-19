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
			if (number == 0 || number == 1) return 1;
			return number * Factorial(number - 1);
		}

		static ulong Power(uint number, uint power)
		{
			if (power == 1) { return number; }
			return number * Power(number, power - 1);
		}

		static void Main(string[] args)
		{
			uint num = 12, power = 6;
			Console.WriteLine($"Факториал числа {num}: {Factorial(num)}");
			Console.WriteLine($"{num} в {power} степени: {Power(num, power)}");
		}
	}
}
