//#define CALC_SIMPLE
#define CALC_ADVANCED

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc2
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CALC_SIMPLE
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
			char s = expression[expression.IndexOfAny(new char[] { '+', '-', '*', '/' })];

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
#endif
			bool isCorrect = true;
			do
			{
				Console.Write("Введите арифметическое выражение: ");
				string expression = Console.ReadLine();
				expression = expression.Replace(" ", "");
				string operations = "+-*/";
				String[] sNums = expression.Split(operations.ToCharArray());
				double[] dNums = new double[sNums.Length];
				sNums = sNums.Where(item => item != "").ToArray();
				for (int i = 0; i < sNums.Length; i++)
				{
					dNums[i] = Convert.ToDouble(sNums[i]);
					Console.Write(dNums[i] + " ");
				}
				Console.WriteLine();
				char[] sOperations = expression.Where(item => operations.Contains(item)).ToArray();

				for (int i = 0; i < sOperations.Length; i++)
				{
					Console.Write(sOperations[i] + " ");
				}
				Console.WriteLine();

				if (dNums.Length != sOperations.Length + 1)
				{
					Console.WriteLine("Выражение некорректно.");
					continue;
				}

				for (int i = 0; i < sOperations.Length; i++)
				{
					if (sOperations[i] == '*' || sOperations[i] == '/')
					{
						if (sOperations[i] == '*') { dNums[i] *= dNums[i + 1]; }
						else { dNums[i] /= dNums[i + 1]; }

						for (int j = i; j < dNums.Length - 1; j++)
						{
							dNums[j] = dNums[j + 1];
						}
						for (int j = i; j < sOperations.Length - 1; j++)
						{
							sOperations[j] = sOperations[j + 1];
						}
						dNums[dNums.Length - 1] = 0;
						sOperations[sOperations.Length - 1] = '\0';
					}
				}
				for (int j = 0; j < dNums.Length; j++)
				{
					Console.Write(dNums[j] + " ");
				}
				Console.WriteLine();
				for (int j = 0; j < sOperations.Length; j++)
				{
					Console.Write(sOperations[j] + " ");
				}
				Console.WriteLine();
			} while (!isCorrect);
		}
	}
}
