//#define INTEGRAL_TYPES
//#define INTEGRAL_TYPES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
	internal class Program
	{
		static readonly string delimiter = "\n>-------------------------------<\n";
		static void Main(string[] args)
		{
#if INTEGRAL_TYPES
			Console.WriteLine("short");
			Console.WriteLine($"Занимает {sizeof(short)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {short.MinValue} - {short.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("ushort");
			Console.WriteLine($"Занимает {sizeof(ushort)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {ushort.MinValue} - {ushort.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("int");
			Console.WriteLine($"Занимает {sizeof(int)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {int.MinValue} - {int.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("uint");
			Console.WriteLine($"Занимает {sizeof(uint)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {uint.MinValue} - {uint.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("long");
			Console.WriteLine($"Занимает {sizeof(long)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {long.MinValue} - {long.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("ulong");
			Console.WriteLine($"Занимает {sizeof(ulong)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {ulong.MinValue} - {ulong.MaxValue}");
			Console.WriteLine(delimiter);
#endif
			Console.WriteLine("float");
			Console.WriteLine($"Занимает {sizeof(float)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {float.MinValue} - {float.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("double");
			Console.WriteLine($"Занимает {sizeof(double)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {double.MinValue} - {double.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("decimal");
			Console.WriteLine($"Занимает {sizeof(decimal)} байта");
			Console.WriteLine($"Диапазон принимаемях значений: {decimal.MinValue} - {decimal.MaxValue}");
			Console.WriteLine(delimiter);
		}
	}
}
