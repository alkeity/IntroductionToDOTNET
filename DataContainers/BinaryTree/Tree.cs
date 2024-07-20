﻿#undef DEBUG
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
#if DEBUG
				Console.WriteLine($"Elem ctor: {GetHashCode()}");
#endif
			}

			~Element()
			{
#if DEBUG
				Console.WriteLine($"Elem dtor: {GetHashCode()}");
#endif
			}
		}
		protected Element root;

        public Tree()
        {
#if DEBUG
			Console.WriteLine($"Tree ctor: {GetHashCode()}");
#endif
		}

		~Tree()
		{
			if (root != null) Clear();
#if DEBUG
			Console.WriteLine($"Tree dtor: {GetHashCode()}");
#endif
		}

		public void Insert(int data)
		{
			Insert(data, this.root);
		}

		protected virtual void Insert(int data, Element root)
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
			Console.WriteLine();
		}

		void Print(Element root)
		{
			if (root == null) return;
			Print(root.PLeft);
			Console.Write(root.Data + " ");
			Print(root.PRight);
		}

		public int MinValue()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return MinValue(root);
		}

		int MinValue(Element root)
		{
			return root.PLeft == null ? root.Data : MinValue(root.PLeft);
		}

		public int MaxValue()
		{
			if (this.root == null) throw new ArgumentNullException("Tree is empty");
			return MaxValue(root);
		}

		int MaxValue(Element root)
		{
			return root.PRight == null ? root.Data : MaxValue(root.PRight);
		}

		public int Count()
		{
			if (this.root == null) return 0;
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

		public void Clear()
		{
			root = Clear(root);
		}

		Element Clear(Element root)
		{
			if (root.PLeft != null)
			{
				root.PLeft = Clear(root.PLeft);
			}
			if (root.PRight != null)
			{
				root.PRight = Clear(root.PRight);
			}
			return null;
		}

		public Element Erase(int data)
		{
			return Erase(data, root);
		}

		Element Erase(int data, Element root) // TODO element exist check
		{
			if (root.Data > data)
			{
				root.PLeft = Erase(data, root.PLeft);
			}
			else if (root.Data < data)
			{
				root.PRight = Erase(data, root.PRight);
			}
			else
			{
				// if element has only one child
				if (root.PLeft == null) return root.PRight;
				else if (root.PRight == null) return root.PLeft;

				// element with 2 children - replace root data with smallest value in right and then delete that elem
				root.Data = MinValue(root.PRight);
				root.PRight = Erase(root.Data, root.PRight);
			}
			return root;
		}

		public int Depth()
		{
			throw new NotImplementedException();
		}

		public void TreePrint()
		{
			throw new NotImplementedException();
		}
	}

	class UniqueTree : Tree
	{
		protected override void Insert(int data, Element root)
		{
			if (this.root == null) this.root = new Element(data);
			if (root == null) return;
			if (data < root.Data)
			{
				if (root.PLeft == null) root.PLeft = new Element(data);
				else Insert(data, root.PLeft);
			}
			else if (data > root.Data)
			{
				if (root.PRight == null) root.PRight = new Element(data);
				else Insert(data, root.PRight);
			}
		}
	}
}
