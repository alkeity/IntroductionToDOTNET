using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
		internal class Program
	{
		static void Main(string[] args)
		{
			double var1, var2;
			char operation;
			string choice;

			do
			{
				var1 = GetInput<double>("Введите первое число: ", Convert.ToDouble);
				var2 = GetInput<double>("\nВведите второе число: ", Convert.ToDouble);
				operation = GetInput<char>("\nВведите желаемую операцию: ", Convert.ToChar);

				try
				{
					Console.WriteLine($"{var1} {operation} {var2} = {Calculate(var1, var2, operation)}");

				}
				catch (DivideByZeroException)
				{
					Console.WriteLine("Деление на ноль не поддерживается.");
				}
				catch (ArgumentException)
				{
					Console.WriteLine($"Операция {operation} не поддерживается.");
				}

				Console.Write("Еще раз? y/n ");
				choice = Console.ReadLine();
				if (choice == "Y" || choice == "y")
				{
					Console.Clear();
				}
			} while (choice == "Y" || choice == "y");
		}

		static T GetInput<T>(string msg, Func<string, T>convertFunc)
		{
			T tempVar;
			while (true)
			{
				Console.Write(msg);
				try
				{
					tempVar = convertFunc(Console.ReadLine());
					break;
				}
				catch (FormatException)
				{
					Console.WriteLine("\nНеверный формат ввода.");
				}
			}

			return tempVar;
		}

		static double Calculate(double var1, double var2, char operation)
		{
			double result;
			switch (operation)
			{
				case '+':
					result = var1 + var2;
					break;
				case '-':
					result = var1 - var2;
					break;
				case '*':
					result = var1 * var2;
					break;
				case '/':
					if (var2 == 0)
					{
						throw new DivideByZeroException("Can't divide by zero.");
					}
					result = var1 / var2;
					break;
				default:
					throw new ArgumentException($"Operation {operation} is not supported.");
			}
			return result;
		}
	}
}
