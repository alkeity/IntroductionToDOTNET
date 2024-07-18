using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Tree
	{
		public class Element
		{
			int data;
			Element pLeft;
			Element pRight;

			public int Data
			{
				get => data;
				set { data = value; }
			}

			public Element PLeft
			{
				get => pLeft;
				set { pLeft = value; }
			}

			public Element PRight
			{
				get => pRight;
				set { pRight = value; }
			}

			public Element(int data, Element pLeft = null, Element pRight = null)
			{
				this.data = data;
				this.pLeft = pLeft;
				this.pRight = pRight;
				Console.WriteLine($"Elem ctor: {GetHashCode()}");
			}

			~Element()
			{
				Console.WriteLine($"Elem dtor: {GetHashCode()}");
			}
		}
		Element root;

        public Tree()
        {
			Console.WriteLine($"Tree ctor: {GetHashCode()}");
        }

		~Tree()
		{
			Console.WriteLine($"Tree dtor: {GetHashCode()}");
		}

		public void Insert(int data)
		{
			Insert(data, this.root);
		}

		void Insert(int data, Element root)
		{
			if (this.root == null) this.root = new Element(data);
			if (root == null) return;
			if (data < root.Data)
			{
				if (root.PLeft == null) root.PLeft = new Element(data);
				else Insert(data, root.PLeft);
			}
			else
			{
				if (root.PRight == null) root.PRight = new Element(data);
				else Insert(data, root.PRight);
			}
		}

		public void Print()
		{
			Print(this.root);
		}

		void Print(Element root)
		{
			if (root == null) return;
			Print(root.PLeft);
			Console.WriteLine(root.Data + " ");
			Print(root.PRight);
		}

		public int MinValue()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return MinValue(root);
		}

		int MinValue(Element root)
		{
			if (root.PLeft == null) return root.Data;
			return MinValue(root.PLeft);
		}

		public int MaxValue()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return MaxValue(root);
		}

		int MaxValue(Element root)
		{
			if (root.PRight == null) return root.Data;
			return MaxValue(root.PRight);
		}

		public int Count()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return Count(root);
		}

		int Count(Element root)
		{
			int result = 0;
			if (root != null)
			{
				result++;
				result += Count(root.PLeft);
				result += Count(root.PRight);
			}
			return result;
		}

		public int Sum()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return Sum(root);
		}

		int Sum(Element root)
		{
			int result = 0;
			if (root != null)
			{
				result += root.Data;
				result += Sum(root.PLeft);
				result += Sum(root.PRight);
			}
			return result;
		}

		public double Avg()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			int sum = Sum(root);
			int count = Count(root);
			return (double)sum / count;
		}
	}
}
