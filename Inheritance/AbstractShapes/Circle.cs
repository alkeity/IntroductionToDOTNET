using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractShapes
{
	internal class Circle : Shape
	{
		double radius;

		public double Radius
		{
			get => radius;
			set
			{
				radius = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
			}
		}

        public Circle(double radius, int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
        {
            Radius = radius;
        }

		public double GetDiameter()
		{
			return Radius * 2;
		}

		public override double GetArea()
		{
			return Math.PI * (radius * radius);
		}

		public override double GetPerimeter()
		{
			return 2 * Math.PI * radius;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawEllipse(new Pen(Color, LineWidth), StartX, StartY, (float)GetDiameter(), (float)GetDiameter());
		}

		public override string ToString()
		{
			string result = "Circle\n";
			result += $"Radius: {Radius}\nDiameter: {GetDiameter()}\n";
			result += base.ToString();
			return result;
		}
	}
}
