using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Square
	{
		int maxX;
		int maxY;

		int size;
		int posX;
		int posY;
		ConsoleColor color;

        public Square()
        {
			size = 1;
			maxX = Console.WindowWidth - size * 2;
			maxY = Console.WindowHeight - size;
			posX = (Console.WindowWidth - size * 2) / 2;
			posY = (Console.WindowHeight - size) / 2 - 1;
			color = ConsoleColor.White;
        }

        public Square(int size, ConsoleColor color) : this()
        {
			maxX = Console.WindowWidth - size * 2;
			maxY = Console.WindowHeight - size - 1;
			Size = size;
			Color = color;
        }

        ~Square() { Console.WriteLine("bye square"); }

		public int PosX
		{
			get { return posX; }
			set {  posX = value < 0 ? posX = 0 : value > maxX ? posX = maxX : value; }
		}

		public int PosY
		{
			get { return posY; }
			set { posY = value < 0 ? posY = 0 : value > maxY ? posY = maxY : value; }
		}

		public int Size
		{
			get { return size; }
			set { size = value < 1 ? size = 1 : value > 10 ? size = 10 : value; }
		}

		public ConsoleColor Color
		{
			get { return color; }
			set { color = value; }
		}

		public void Draw()
		{
			Console.BackgroundColor = color;
			Console.CursorTop = posY;
			for (uint i = 0; i < size; i++)
			{
				Console.CursorLeft = posX;
				for (uint j = 0; j < size; j++)
				{
					Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.ResetColor();
		}
    }

	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WindowHeight = 20;
			Console.WindowWidth = 40;

			Square square = new Square(3, ConsoleColor.Cyan);
			ConsoleKey key;

			do
			{
				square.Draw();
				key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						square.PosY--;
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						square.PosY++;
						break;
					case ConsoleKey.LeftArrow:
					case ConsoleKey.A:
						square.PosX -= 2;
						break;
					case ConsoleKey.RightArrow:
					case ConsoleKey.D:
						square.PosX += 2;
						break;
					default:
						break;
				}
				Console.Clear();
			} while (key != ConsoleKey.Escape);
		}
	}
}
