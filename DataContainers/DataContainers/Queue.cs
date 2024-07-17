using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class Queue<T>
	{
		Node<T> head;
		Node<T> tail;
		int count;

		public Node<T> Head
		{
			get => head;
			set { head = value; }
		}

		public Node<T> Tail
		{
			get => tail;
			set { tail = value; }
		}

		public int Count
		{
			get => count;
			private set { count = value; }
		}

        public Queue()
        {
			Head = null;
			Tail = null;
			count = 0;
        }
    }
}
