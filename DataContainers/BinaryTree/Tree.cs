#undef DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Tree : IEnumerable, IEnumerator
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

		object IEnumerator.Current => root.Data;

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

		protected virtual void Insert(Element newElem, Element root)
		{
			if (root == null) return;
			if (newElem.Data < root.Data)
			{
				if (root.PLeft == null) root.PLeft = newElem;
				else Insert(newElem, root.PLeft);
			}
			else
			{
				if (root.PRight == null) root.PRight = newElem;
				else Insert(newElem, root.PRight);
			}
		}

		public void Print()
		{
			Print(this.root);
			Console.WriteLine("Root: " + root.Data);
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
			if (root.PLeft != null) root.PLeft = Clear(root.PLeft);
			if (root.PRight != null) root.PRight = Clear(root.PRight);
			return null;
		}

		public Element Erase(int data)
		{
			return Erase(data, root);
		}

		Element Erase(int data, Element root) // TODO element exist check
		{
			if (root == null) return null;
			if (root.Data > data) root.PLeft = Erase(data, root.PLeft);
			else if (root.Data < data) root.PRight = Erase(data, root.PRight);
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

		public int Height()
		{
			return Depth(root);
		}

		int Depth(Element root)
		{
			if (root == null) return 0;
			int depthLeft = Depth(root.PLeft);
			int depthRight = Depth(root.PRight);
			return depthLeft > depthRight ? depthLeft + 1 : depthRight + 1;
		}

		public void Balance()
		{
			List<Element> array = new List<Element>();
			TreeToArray(ref array, this.root);
			Clear();
			this.root = Balance(array, 0, array.Count - 1);
		}

		Element Balance(List<Element> array, int start, int end)
		{
			if (start > end) return null;
			int midIndex = (start + end) / 2;
			Element root = array[midIndex];
			root.PLeft = Balance(array, start, midIndex - 1);
			root.PRight = Balance(array, midIndex + 1, end);
			return root;
		}

		void TreeToArray(ref List<Element> array, Element root)
		{
			if (root == null) return;
			TreeToArray(ref array, root.PLeft);
			array.Add(root);
			TreeToArray(ref array, root.PRight);
		}

		public void TreePrint()
		{
			TreePrint(root);
		}

		void TreePrint(Element root, string indent = "")
		{
			if (root == null) return;
			Console.WriteLine($"{indent}-[{root.Data}]");
			indent += "   ";
			TreePrint(root.PLeft, indent);
			TreePrint(root.PRight, indent);
		}

		public void Add(int data)
		{
			Insert(data, root);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}

		bool IEnumerator.MoveNext()
		{
			return root == null ? false : true;
		}

		void IEnumerator.Reset()
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
