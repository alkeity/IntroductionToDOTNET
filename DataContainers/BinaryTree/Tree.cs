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
			throw new NotImplementedException();
		}

		int MinValue(Element root)
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			throw new NotImplementedException();
		}

		public int MaxValue()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			throw new NotImplementedException();
		}

		public int Count()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			throw new NotImplementedException();
		}

		public int Sum()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			throw new NotImplementedException();
		}

		public int Avg()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			throw new NotImplementedException();
		}
	}
}
