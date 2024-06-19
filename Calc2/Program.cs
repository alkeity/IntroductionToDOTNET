using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите простое арифметическое выражение: ");
			string expression = Console.ReadLine();
			//Console.WriteLine(expression);
			expression = expression.Replace('.', ',');
			String[] nums = expression.Split('+', '-', '*', '/');
			//for (int i = 0; i < nums.Length; i++)
			//{
			//	Console.Write(nums[i] + ' ');
			//}

			double a = Convert.ToDouble(nums[0]);
			double b = Convert.ToDouble(nums[1]);
			char s = expression[expression.IndexOfAny(new char[]{ '+', '-', '*', '/' })];

			//Console.WriteLine(a + " " + s + " " + b);

			switch (s)
			{
				case '+':
					Console.WriteLine($"{a} + {b} = {a + b}");
					break;
				case '-':
					Console.WriteLine($"{a} - {b} = {a - b}");
					break;
				case '*':
					Console.WriteLine($"{a} * {b} = {a * b}");
					break;
				case '/':
					Console.WriteLine($"{a} / {b} = {a / b}");
					break;
				default:
					break;
			}
			Main(args);
		}
	}
}
