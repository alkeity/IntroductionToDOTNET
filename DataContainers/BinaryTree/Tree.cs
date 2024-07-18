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
			public int data;
			public Element pLeft;
			public Element pRight;

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
		public Element root;

        public Tree()
        {
			Console.WriteLine($"Tree ctor: {GetHashCode()}");
        }

		~Tree()
		{
			Console.WriteLine($"Tree dtor: {GetHashCode()}");
		}

		public void Insert(int data, Element root)
		{
			if (this.root == null) this.root = new Element(data);
			if (root == null) return;
			if (data < root.data)
			{
				if (root.pLeft == null) root.pLeft = new Element(data);
				else Insert(data, root.pLeft);
			}
			else
			{
				if (root.pRight == null) root.pRight = new Element(data);
				else Insert(data, root.pRight);
			}
		}

		public void Print(Element root)
		{
			if (root == null) return;
			Print(root.pLeft);
			Console.WriteLine(root.data + " ");
			Print(root.pRight);
		}
	}
}
