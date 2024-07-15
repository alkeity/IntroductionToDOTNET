using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms; // позволит подключать к файлу другие DLL-файлы

namespace AbstractShapes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle windowRectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, windowRectangle);

			Rectangle rectangle = new Rectangle(100, 80, 450, 50, 7, Color.CornflowerBlue);
			rectangle.Info(e);

			Square square = new Square(110, 400, 100, 8, Color.BlueViolet);
			square.Info(e);

			Circle circle = new Circle(90, 500, 200, 10, Color.Crimson);
			circle.Info(e);

			TriangleScalene triangle1 = new TriangleScalene(150, 120, 130, 550, 300, 6, Color.PaleVioletRed);
			triangle1.Info(e);

			TriangleIsosceles triangle2 = new TriangleIsosceles(150, 100, 530, 220, 8, Color.MistyRose);
			triangle2.Info(e);

			TriangleEquilateral triangle3 = new TriangleEquilateral(130, 600, 200, 10, Color.Turquoise);
			triangle3.Info(e);
		}
		[DllImport("kernel32.dll")]
		public static extern bool GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
