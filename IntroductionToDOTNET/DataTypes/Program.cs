#define INTEGRAL_TYPES
//#define FLOATING_TYPES
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
			short _short = 0;
			ushort _ushort = 0;
			int _int = 0;
			uint _uint = 0;
			long _long = 0;
			ulong _ulong = 0;

			Console.WriteLine("short");
			Console.WriteLine($"Занимает {sizeof(short)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {short.MinValue} - {short.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_short.GetType()}");
			Console.WriteLine(delimiter);

			Console.WriteLine("ushort");
			Console.WriteLine($"Занимает {sizeof(ushort)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {ushort.MinValue} - {ushort.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_ushort.GetType()}");
			Console.WriteLine(delimiter);

			Console.WriteLine("int");
			Console.WriteLine($"Занимает {sizeof(int)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {int.MinValue} - {int.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_int.GetType()}");
			Console.WriteLine(delimiter);

			Console.WriteLine("uint");
			Console.WriteLine($"Занимает {sizeof(uint)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {uint.MinValue} - {uint.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_uint.GetType()}");
			Console.WriteLine(delimiter);

			Console.WriteLine("long");
			Console.WriteLine($"Занимает {sizeof(long)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {long.MinValue} - {long.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_long.GetType()}");
			Console.WriteLine(delimiter);

			Console.WriteLine("ulong");
			Console.WriteLine($"Занимает {sizeof(ulong)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {ulong.MinValue} - {ulong.MaxValue}");
			Console.WriteLine($"Класс-обертка: {_ulong.GetType()}");
			Console.WriteLine(delimiter);
#endif
#if FLOATING_TYPES
			Console.WriteLine("float");
			Console.WriteLine($"Занимает {sizeof(float)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {float.MinValue} - {float.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("double");
			Console.WriteLine($"Занимает {sizeof(double)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {double.MinValue} - {double.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("decimal");
			Console.WriteLine($"Занимает {sizeof(decimal)} байта");
			Console.WriteLine($"Диапазон принимаемых значений: {decimal.MinValue} - {decimal.MaxValue}");
			Console.WriteLine(delimiter); 
#endif
			int a = 2;
			uint b = 3;
			//a = (int)b; // this works
			//a = int(b); // Syntax error

			Console.WriteLine((a + b).GetType());
		}
	}
}
