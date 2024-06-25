using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
	class Calculator
	{
		const string operations = "+-*/";
		public static double Calculate(double var1, double var2, char operation)
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

		public static double CalculateWithBrackets(string expr)
		{
			CheckBrackets(expr);
			double tempResult;
			int start, end;

			do
			{
				end = expr.IndexOf(')');
				if (end != -1)
				{
					start = expr.Substring(0, end).LastIndexOf('(');
					if (start != -1)
					{
						tempResult = Calculate(expr.Substring(start + 1, end - start - 1));
						expr = expr.Remove(start, end - start + 1);
						expr = expr.Insert(start, Convert.ToString(tempResult));
					}
				}
			} while (end != -1);

			return Calculate(expr);
		}

		// method for calculating result of a string expression without brackets
		public static double Calculate(string expr)
		{
			double[] nums = GetAllMatchesFromString<double>(expr, @"-?\d+(\.\d+)?", Convert.ToDouble);
			char[] exprOper = GetAllOperationsFromString(expr);

			if (nums.Length != exprOper.Length + 1)
			{
				throw new Exception("Invalid expression");
			}
			// multiply and divide
			for (int i = 0; i < exprOper.Length; i++)
			{
				if (exprOper[i] == '*' || exprOper[i] == '/')
				{
					nums[i + 1] = Calculate(nums[i], nums[i + 1], exprOper[i]);

					for (int j = i; j < nums.Length - 1; j++)
					{
						nums[j] = nums[j + 1];
					}
					for (int j = i; j < exprOper.Length - 1; j++)
					{
						exprOper[j] = exprOper[j + 1];
					}
					nums[nums.Length - 1] = 0;
					exprOper[exprOper.Length - 1] = '\0';
				}
			}
			// plus and minus
			for (int i = 0; i < exprOper.Length; i++)
			{
				if (operations.Contains(exprOper[i]))
				{
					nums[0] = Calculate(nums[0], nums[i + 1], exprOper[i]);
				}
			}
			return nums[0];
		}

		static void CheckBrackets(string expr)
		{
			if (Regex.Matches(expr, @"\(").Count != Regex.Matches(expr, @"\)").Count)
			{
				throw new Exception("Invalid expression");
			}
		}

		static T[] GetAllMatchesFromString<T>(string expr, string pattern, Func<string, T> convertFunc)
		{
			MatchCollection matchCollection = Regex.Matches(expr, pattern);
			T[] values = new T[matchCollection.Count];

			for (int i = 0; i < matchCollection.Count; i++)
			{
				values[i] = convertFunc(matchCollection[i].Value);
			}
			return values;
		}

		static char[] GetAllOperationsFromString(string expr)
		{
			string[] tempStr = GetAllMatchesFromString<string>(expr, @"[\d\s()][\+*/-][\d\s()-]", Convert.ToString);
			char[] result = new char[tempStr.Length];

			for (int i = 0; i < tempStr.Length; i++)
			{
				result[i] = tempStr[i][1];
			}
			return result;
		}
	}

		internal class Program
	{
		static void Main(string[] args)
		{
			string expr = "((22 + 33) * (44 - 55) + 88) / 2";
			Console.WriteLine(Calculator.CalculateWithBrackets(expr));
		}
	}
}
