using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
		internal class Program
	{
		static void Main(string[] args)
		{
			Fraction a = new Fraction(1, 2);
			Fraction b = new Fraction(2, 7);
			Console.WriteLine($"{a.ToString()} + {b.ToString()} = {(a + b).ToString()}");
			Console.WriteLine($"{a.ToString()} - {b.ToString()} = {(a - b).ToString()}");
			Console.WriteLine($"{a.ToString()} * {b.ToString()} = {(a * b).ToString()}");
			Console.WriteLine($"{a.ToString()} / {b.ToString()} = {(a / b).ToString()}");
		}
	}

	class Fraction
	{
		int num;
		int denom;

		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}

		public int Numerator
		{
			get { return num; }
			set { num = value; }
		}

		public int Denominator
		{
			get { return denom; }
			set
			{
				if (value == 0) throw new ArgumentException("Denominator cannot be zero.");
				denom = value;
				if (value < 0)
				{
					denom *= -1;
					num *= -1;
				}
			}
		}

		override public string ToString()
		{
			return $"{num}/{denom}";
		}

		public static Fraction operator +(Fraction a, Fraction b)
		{
			int lcm = CalculateLCM(a.denom, b.denom);
			int newDenom = a.denom * (lcm / a.denom);
			int newNum = a.num * (lcm / a.denom) + b.num * (lcm / b.denom);
			return new Fraction(newNum, newDenom);
		}

		public static Fraction operator -(Fraction a, Fraction b)
		{
			int lcm = CalculateLCM(a.denom, b.denom);
			int newDenom = a.denom * (lcm / a.denom);
			int newNum = a.num * (lcm / a.denom) - b.num * (lcm / b.denom);
			return new Fraction(newNum, newDenom);
		}

		public static Fraction operator *(Fraction a, Fraction b)
		{
			return new Fraction(a.num * b.num, a.denom * b.denom);
		}

		public static Fraction operator /(Fraction a, Fraction b)
		{
			return new Fraction(a.num * b.denom, a.denom * b.num);
		}

		// наименьшее общее кратное
		static int CalculateLCM(int a, int b)
		{
			if (a < b) (a, b) = (b, a);

			for (int i = a; i < a * b + 1 ; i++)
			{
				if (i % a == 0 && i % b == 0)
				{
					return i;
				}
			}
			return -1;
		}

		//static int CalculateGCD(int a, int b)
		//{
		//	int temp;
		//	while (b != 0)
		//	{
		//		temp = b;
		//		b = a % b;
		//		a = temp;
		//	}
		//	return a;
		//}
	}
}
