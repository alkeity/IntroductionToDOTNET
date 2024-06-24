using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionClasswork
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.Write("Введите номер этажа: ");
			//int floor = Convert.ToInt32(Console.ReadLine());
			//Elevator(floor);
			
			try
			{
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine($"!{i} = {Factorial(i)}");
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine($"{ex.GetType()}: {ex.Message}");
			}
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
	}
}
