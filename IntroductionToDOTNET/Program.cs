//#define TASK1
//#define CHESS_HARD

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
#if TASK1
			int sizeSimple = 4;
			int sizeDiamond = 10;
			int sizePlusMinus = 5;

			Console.WriteLine("Rectangle");
			DrawSimpleSymbolShape(sizeSimple, '*', ' ', (int x, int y) => { return true; });

			Console.WriteLine("Triangles");
			DrawSimpleSymbolShape(sizeSimple, '*', ' ', (int x, int y) => { return x <= y; });
			DrawSimpleSymbolShape(sizeSimple, '*', ' ', (int x, int y) => { return y < sizeSimple - x; });
			DrawSimpleSymbolShape(sizeSimple, '*', ' ', (int x, int y) => { return x >= y; });
			DrawSimpleSymbolShape(sizeSimple, '*', ' ', (int x, int y) => { return y >= sizeSimple - x - 1; });

			Console.WriteLine("Diamond");
			for (int i = 0; i < sizeDiamond; i++)
			{
				for (int j = 0; j < sizeDiamond; j++)
				{
					if ((i == sizeDiamond / 2 - j - 1) || (i - sizeDiamond / 2 == sizeDiamond - j - 1))
					{
						Console.Write('/');
					}
					else if (i == j + sizeDiamond / 2 || i == j - sizeDiamond / 2)
					{
						Console.Write('\\');
					}
					else { Console.Write(' '); }
				}
				Console.WriteLine();
			}

			Console.WriteLine("\n+- square");
			DrawSimpleSymbolShape(sizePlusMinus, '+', '-', isBothEvenOrBothOdd);
#else
			int size, startX = 10, startY = 2;

			Console.Write("Введите размер доски: ");
			size = Convert.ToInt32(Console.ReadLine());
#if CHESS_HARD
#else
			DrawSmallChessBoard(size, startX, startY);
#endif
#endif
		}

		static bool isBothEvenOrBothOdd(int x, int y)
		{
			return y % 2 == 0 && x % 2 == 0 || y % 2 != 0 && x % 2 != 0;
		}

		static void DrawSimpleSymbolShape(int size, char sym1, char sym2, Func<int, int, bool> filter)
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (filter(j, i)) { Console.Write(sym1); }
					else { Console.Write(sym2); }
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		static void DrawSmallChessBoard(int size, int startX, int startY)
		{
			Console.CursorTop = startY;
			for (int i = 0; i < size; i++)
			{
				Console.CursorLeft = startX;
				for (int j = 0; j < size; j++)
				{
					if (!isBothEvenOrBothOdd(j, i)) Console.BackgroundColor = ConsoleColor.White;
					Console.Write("  ");
					Console.ResetColor();
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
