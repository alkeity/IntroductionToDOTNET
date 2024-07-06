//#define CLASS_CONSOLE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CLASS_CONSOLE
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Title = "Введение в .NET";
			Console.WriteLine("\tHello .Net!");
			Console.ResetColor();
			//Console.SetCursorPosition(22, 11);
			Console.CursorLeft = 32;
			Console.CursorTop = 11;
			Console.Beep(333, 2000);
			Console.Clear();
			Console.WriteLine("Привет, .NET!");
#endif
			#region ConsoleWriteRegion
			Console.Write("Введите Ваше имя: ");
			string firstName = Console.ReadLine();

			Console.Write("Введите Вашу фамилию: ");
			string lastName = Console.ReadLine();

			Console.Write("Введите Ваш возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			//Console.WriteLine(firstName + " " + lastName + ", " + age); // str concatenation
			//Console.WriteLine(string.Format("{0} {1}, {2}", lastName, firstName, age)); // string formatting
			Console.WriteLine($"{lastName} {firstName}, {age}"); // str interpolation
			#endregion
		}
	}
}
