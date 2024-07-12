using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractShapes
{
	class Square : Shape // TODO: think about how to properly inherit this from Rectangle
	{
		double side;

		public double Side
		{
			get => side;
			set
			{
				side = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
			}
		}

        public Square(double side, int startX, int startY, int lineWidth, Color color)
            : base(startX, startY, lineWidth, color)
		{
			Side = side;
		}

		public override double GetArea()
		{
			return Side * 2;
		}

		public override double GetPerimeter()
		{
			return Side * 4;
		}

		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color), StartX, StartY, (float)Side, (float)Side);
		}

		public override string ToString()
		{
			string result = "";
			result += $"Side: {Side}\n";
			result += base.ToString();
			return result;
		}
	}
}
