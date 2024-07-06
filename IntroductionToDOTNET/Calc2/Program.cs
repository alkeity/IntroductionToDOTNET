//#define CALC_SIMPLE
#define CALC_ADVANCED

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
			string expression = "(22 + 33 * (44 + 55)) / 5";
			Console.WriteLine($"Result: {Calculate(Browse(expression))}");
		}

		static string Browse(string complexExpr)
		{
			complexExpr = complexExpr.Replace(" ", "");
			int start = -1;
			string subexpr;
			double result;

			Console.WriteLine("Current expr: " + complexExpr);
			start = complexExpr.IndexOf('(');
			if (start != -1)
			{
				for (int i = start + 1; i < complexExpr.Length; i++)
				{
					if (complexExpr[i] == ')')
					{
						Console.WriteLine($"Start: {start}, end: {i}");
						subexpr = complexExpr.Substring(start + 1, i - start - 1);
						Console.WriteLine("Expr to calculate: " + subexpr);
						result = Calculate(subexpr);
						Console.WriteLine(subexpr + " = " + result);
						complexExpr = complexExpr.Replace($"({subexpr})", result.ToString());
						break;
					}
					else if (complexExpr[i] == '(')
					{
						Console.WriteLine("recursion");
						complexExpr = complexExpr.Replace(
							complexExpr.Substring(i, complexExpr.Length - i),
							Browse(complexExpr.Substring(i, complexExpr.Length - i))
							);
					}
				}
			}
			return complexExpr;
		}

		static double Calculate(string expression)
		{
			expression = expression.Replace(" ", "");
			Console.WriteLine("Calculating " + expression);
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
				throw new Exception("Invalid expression");
			}

			for (int i = 0; i < sOperations.Length; i++)
			{
				while (sOperations[i] == '*' || sOperations[i] == '/')
				{
					if (sOperations[i] == '*') dNums[i] *= dNums[i + 1];
					else dNums[i] /= dNums[i + 1];

					for (int j = i + 1; j < dNums.Length - 1; j++)
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

			for (int i = 0; i < sOperations.Length; i++)
			{
				while (sOperations[i] == '+' || sOperations[i] == '-')
				{
					if (sOperations[i] == '+') dNums[i] += dNums[i + 1];
					else dNums[i] -= dNums[i + 1];

					for (int j = i + 1; j < dNums.Length - 1; j++)
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

			return dNums[0];
		}
	}
}
