using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Square
	{
		int size;
		int posX;
		int posY;
		ConsoleColor color;

        public Square()
        {
			size = 5;
			posX = (Console.WindowWidth - size * 2) / 2;
			posY = (Console.WindowHeight - size) / 2;
			color = ConsoleColor.Cyan;
        }

        ~Square() { Console.WriteLine("bye square"); }

		public int getX() { return posX; }
		public int getY() { return posY; }
		public int getSize() { return size; }

        public void setColor(ConsoleColor color)
		{
			this.color = color;
		}

		public void changePosX(int x)
		{
			posX += x;
			if (posX < 0) posX = 0;
			else if (posX > Console.WindowWidth - size * 2) posX = Console.WindowWidth - size * 2;
		}

		public void changePosY(int y)
		{
			posY += y;
			if (posY < 0) posY = 0;
			else if (posY > Console.WindowHeight - size - 1) posY = Console.WindowHeight - size - 1;
		}

		public void Draw(bool clear = false)
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
			Console.WindowHeight = 40;
			Console.WindowWidth = 80;

			Square square = new Square();
			ConsoleKey key;

			do
			{
				square.Draw();
				key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						square.changePosY(-1);
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						square.changePosY(1);
						break;
					case ConsoleKey.LeftArrow:
					case ConsoleKey.A:
						square.changePosX(-1);
						break;
					case ConsoleKey.RightArrow:
					case ConsoleKey.D:
						square.changePosX(1);
						break;
					default:
						break;
				}
				Console.Clear();
			} while (key != ConsoleKey.Escape);

		}
	}
}
