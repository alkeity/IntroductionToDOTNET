using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractShapes
{
	abstract class Triangle : Shape, IHaveHeight
	{
		double sideA; // base
		double sideB;
		double sideC;

		protected double SideA
		{
			get => sideA;
			set
			{
				sideA = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
			}
		}

		protected double SideB
		{
			get => sideB;
			set
			{
				sideB = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
			}
		}

		protected double SideC
		{
			get => sideC;
			set
			{
				sideC = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
			}
		}

		protected Triangle(double sideA, double sideB, double sideC, int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
		{
			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
		}

		public bool IsDegenerate()
		{
			return sideA + sideB < sideC ||
				sideA + sideC < sideB ||
				sideB + sideC < sideA;
		}

		public double GetHeight()
        {
            return IsDegenerate() ? 0 : (2 * GetArea()) / sideA;
        }

		public override double GetArea()
		{
			double area = 0;
			if (!IsDegenerate())
			{
				double halfP = GetPerimeter() / 2;
				area = Math.Sqrt(halfP * (halfP - sideA) * (halfP - sideB) * (halfP - sideC));
			}
			return area;
		}

		public override double GetPerimeter()
		{
			return IsDegenerate() ? 0 : sideA + sideB + sideC;
		}

		public override string ToString()
		{
			string result = "Degenerate: ";
			result += IsDegenerate() ? "Yes\n" : "No\n";
			if (!IsDegenerate())
			{
				result += base.ToString();
			}
			return result;
		}

		public override void Draw(PaintEventArgs e)
		{
			if (!IsDegenerate())
			{
				e.Graphics.DrawPolygon(new Pen(Color, LineWidth), GetPoints());
			}
		}

		protected abstract PointF[] GetPoints();
	}

	class TriangleScalene : Triangle
	{
		public new double SideA
		{
			get => base.SideA;
			set {  base.SideA = value; }
		}

		public new double SideB
		{
			get => base.SideB;
			set { base.SideB = value; }
		}

		public new double SideC
		{
			get => base.SideC;
			set { base.SideC = value; }
		}

        public TriangleScalene(double sideA, double sideB, double sideC, int startX, int startY, int lineWidth, Color color)
		 : base(sideA, sideB, sideC, startX, startY, lineWidth, color){}

		protected override PointF[] GetPoints()
		{
			PointF[] points = new PointF[3];
			points[0] = new PointF(StartX, StartY);
			points[1] = new PointF((float)(StartX + SideA), StartY);
			points[2] = new PointF(
				(float)(StartX + Math.Sqrt(SideB * SideB + GetHeight() * GetHeight())),
				(float)(StartY - GetHeight())
				);
			return points;
		}

		public override string ToString()
		{
			string result = "Scalene triangle\n";
			result += $"SideA: {SideA}\nSideB: {SideB}\nSideC: {SideC}\n";
			result += base.ToString();
			return result;
		}
	}

	class TriangleIsosceles : Triangle
	{
		public double Side
		{
			get => SideB;
			set
			{
				SideB = value;
				SideC = value;
			}
		}

		public double Base
		{
			get => SideA;
			set => SideA = value;
		}

		public TriangleIsosceles(double side, double triangleBase, int startX, int startY, int lineWidth, Color color)
			: base(triangleBase, side, side, startX, startY, lineWidth, color) { }

		protected override PointF[] GetPoints()
		{
			PointF[] points = new PointF[3];
			points[0] = new PointF(StartX, StartY);
			points[1] = new PointF((float)(StartX + SideA), StartY);
			points[2] = new PointF(
				(float)(StartX + SideA / 2),
				(float)(StartY - SideB)
				);
			return points;
		}

		public override string ToString()
		{
			string result = "Isosceles triangle\n";
			result += $"Side: {SideB}\nBase: {SideA}\n";
			result += base.ToString();
			return result;
		}
	}

	class TriangleEquilateral : Triangle
	{
		public double Side
		{
			get => SideA;
			set
			{
				SideA = value;
				SideB = value;
				SideC = value;
			}
		}

		public TriangleEquilateral(double side, int startX, int startY, int lineWidth, Color color)
			: base(side, side, side, startX, startY, lineWidth, color) { }

		protected override PointF[] GetPoints()
		{
			PointF[] points = new PointF[3];
			points[0] = new PointF(StartX, StartY);
			points[1] = new PointF((float)(StartX + SideA), StartY);
			points[2] = new PointF(
				(float)(StartX + SideA / 2),
				(float)(StartY - SideB)
				);
			return points;
		}

		public override string ToString()
		{
			string result = "Equilateral triangle\n";
			result += $"Side: {SideA}\n";
			result += base.ToString();
			return result;
		}
	}
}
