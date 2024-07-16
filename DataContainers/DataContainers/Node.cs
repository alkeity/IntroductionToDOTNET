using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataContainers
{
	internal class BaseNode<T>
	{
		T value;
		BaseNode<T> next;

		public T Value
		{
			get => value;
			set
			{
				this.value = value;
			}
		}

		public BaseNode<T> Next
		{
			get => next;
			set
			{
				next = value;
			}
		}

        public BaseNode(T value)
        {
            Value = value;
			Next = null;
        }

		public BaseNode(T value, BaseNode<T> next)
		{
			Value = value;
			Next = next;
		}
	}

	internal class Node<T> : BaseNode<T>
	{
		Node<T> prev;

		public Node<T> Prev
		{
			get => prev;
			set
			{
				prev = value;
			}
		}

        public Node(T value) : base(value)
        {
            Prev = null;
        }

		public Node(Node<T> prev, T value) : base(value)
		{
			Prev = prev;
		}

		public Node(T value, Node<T> next) : base(value, next)
		{
			Prev = null;
		}

		public Node(T value, Node<T> next, Node<T> prev) : base(value, next)
		{
			Prev = prev;
		}
	}
}
