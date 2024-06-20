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

		static void Fibonacci(uint amount, uint position = 0, uint current = 0, uint next = 1)
		{
			Console.Write(current + " ");
			if (++position < amount)
			{
				Fibonacci(amount, position, next, current + next);
			}
		}

		static void Fibonacci(ulong limit, uint current = 0, uint next = 1)
		{
			Console.Write(current + " ");
			if (next < limit)
			{
				Fibonacci(limit, next, current + next);
			}
		}

		static ulong Fibonacci(uint position)
		{
			if (position <= 1) return position;
			return Fibonacci(position - 1) + Fibonacci(position - 2);
		}

		static void Main(string[] args)
		{
			uint num = 65, power = 15, fiboAmount = 120;
			ulong fiboLimit = 5000;
			Console.WriteLine($"Факториал числа {num}: {Factorial(num)}");
			Console.WriteLine($"{num} в {power} степени: {Power(num, power)}");

			Console.WriteLine($"Ряд Фибоначчи с пределом {fiboLimit}:");
			Fibonacci(fiboLimit, 0, 1);
			Console.WriteLine($"\nРяд Фибоначчи в количестве {fiboAmount} элементов:");
			Fibonacci(fiboAmount, 0, 0, 1);
			Console.WriteLine();
		}
	}
}
