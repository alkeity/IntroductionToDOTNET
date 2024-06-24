using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RecursionClasswork
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.Write("Введите номер этажа: ");
			//int floor = Convert.ToInt32(Console.ReadLine());
			//Elevator(floor);

			//try
			//{
			//	for (int i = 0; i < 100; i++)
			//	{
			//		Console.WriteLine($"!{i} = {BigFactorial(i)}");
			//	}
			//}
			//catch (Exception ex)
			//{

			//	Console.WriteLine($"{ex.GetType()}: {ex.Message}");
			//}
			long num = 1000000;
			DateTime start = DateTime.Now;
			Console.WriteLine($"!{num} = {BigFactorial(num)}");
			DateTime end = DateTime.Now;
			TimeSpan duration = end - start;

			Console.WriteLine($"Duration = {duration.ToString("g")}");
		}

		static void Elevator(int floor)
		{
			if (floor == 0) { return; }
			Console.WriteLine($"Вы на {floor} этаже.");
			Elevator(floor - 1);
		}

		static long Factorial(long number)
		{
			return number <= 1 ? 1 : number * Factorial(number - 1);
		}

		static BigInteger BigFactorial(long number)
		{
			BigInteger f = 1;
			for (int i = 1; i < number; i++) { f *= i; }
			return f;
		}

		static BigInteger Power(long number, int power)
		{
			return power == 0 ? 1 :
				power == 1 ? number :
				number > 0 ? number * Power(number, --power) :
				1 / Power(number, --power);
		}
	}
}
