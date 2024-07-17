using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class Stack<T>
	{
		BaseNode<T> head;
		int count;

		public BaseNode<T> Head
		{
			get => head;
			set { head = value; }
		}

		public int Count
		{
			get => count;
			private set { count = value; }
		}

        public Stack()
        {
			Head = null;
			count = 0;
        }

		public void AddElement(T value)
		{
			BaseNode<T> temp = new BaseNode<T>(value);
			temp.Next = Head;
			Head = temp;
			Count++;
		}

		public void RemoveElement()
		{
			BaseNode<T> temp = Head;
			Head = temp.Next;
			Count--;
		}

		public BaseNode<T> GetElement()
		{
			if (head == null)
			{
				throw new Exception("Stack is empty");
			}
			BaseNode<T> temp = Head;
			RemoveElement();
			return temp;
		}

		public void Clear()
		{
			while (count > 0)
			{
				RemoveElement();
			}
		}
    }
}
