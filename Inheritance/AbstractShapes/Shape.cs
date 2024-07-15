using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Policy;

namespace AbstractShapes
{
	abstract class Shape : IDrawable
	{
		protected static readonly int MIN_START_X = 10;
		protected static readonly int MIN_START_Y = 10;
		protected static readonly int MAX_START_X = 800;
		protected static readonly int MAX_START_Y = 600;
		protected static readonly int MIN_LINE_WIDTH = 3;
		protected static readonly int MAX_LINE_WIDTH = 33;
		protected static readonly int MIN_SIZE = 30;
		protected static readonly int MAX_SIZE = 700;
		int startX;
		int startY;
		int lineWidth;

		public Color Color { get; set; }

		public int StartX
		{
			get => startX;
			set
			{
				startX = value < MIN_START_X ? MIN_START_X : value > MAX_START_X ? MAX_START_X : value;
			}
		}

		public int StartY
		{
			get => startY;
			set
			{
				startY = value < MIN_START_Y ? MIN_START_Y : value > MAX_START_Y ? MAX_START_Y : value;

			}
		}

		public int LineWidth
		{
			get => lineWidth;
			set
			{
				lineWidth = value < MIN_LINE_WIDTH ? MIN_LINE_WIDTH : value > MAX_LINE_WIDTH ? MAX_LINE_WIDTH : value;
			}
		}

		public Shape(int startX, int startY, int lineWidth, Color color)
        {
            StartX = startX;
			StartY = startY;
			LineWidth = lineWidth;
			Color = color;
        }

		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void Draw(PaintEventArgs e);

		public virtual void Info(PaintEventArgs e)
		{
			Console.WriteLine(this);
			this.Draw(e);
		}

		public override string ToString()
		{
			string result = "";
			result += $"Area: {GetArea()}\n";
			result += $"Perimeter: {GetPerimeter()}\n";
			return result;
		}
	}
}
