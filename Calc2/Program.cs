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
			Console.WriteLine($"Result: {Browse(expression)}");
		}

		static string Browse(string complexExpr)
		{
			complexExpr = complexExpr.Replace(" ", "");
			for (int i = 0; i < complexExpr.Length; i++)
			{
				if (complexExpr[i] == '(')
				{
					for (int j = 0; j < complexExpr.Length; j++)
					{
						if (complexExpr[j] == ')')
						{
							//string subexpr = complexExpr.Substring(i, j - i);
							//double subresult = Calculate(subexpr.Substring(1, subexpr.Length - 2));
							//complexExpr = complexExpr.Replace(subexpr, subresult.ToString());
							string subexpr = complexExpr.Substring(i + 1, j - i - 1);
							double subres = Calculate(subexpr);
							Console.WriteLine(subexpr + " = " + subres);
							complexExpr = complexExpr.Replace($"({subexpr})", subres.ToString());
							break;
						}
						else if (complexExpr[j] == '(')
						{
							Browse(complexExpr.Substring(i + 1, complexExpr.Length - i - 1));
						}
					}
				}
			}
			return complexExpr;
		}

		static double Calculate(string expression)
		{
			expression = expression.Replace(" ", "");
			Console.WriteLine(expression);
			string operations = "+-*/";
			String[] sNums = expression.Split(operations.ToCharArray());
			double[] dNums = new double[sNums.Length];
			sNums = sNums.Where(item => item != "").ToArray();
			for (int i = 0; i < sNums.Length; i++)
			{
				Console.WriteLine(sNums[i]);
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

					for (int j = 0; j < dNums.Length; j++)
					{
						dNums[j] = dNums[j + 1];
					}

					for (int j = 0; j < sOperations.Length; j++)
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
