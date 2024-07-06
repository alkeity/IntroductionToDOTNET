using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		string lastName;
		string firstName;
		int age;

		public string LastName
		{
			get => lastName;
			set {  lastName = value; }
		}

		public string FirstName
		{
			get => firstName;
			set { firstName = value; }
		}

		public int Age
		{
			get => age;
			set { age = value; }
		}

		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"Human ctor: {this.GetHashCode()}");
		}

		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"Human copy ctor: {this.GetHashCode()}");
		}

        ~Human()
        {
			Console.WriteLine($"Human dtor: {this.GetHashCode()}");
		}
        public override string ToString()
		{
			return base.ToString() + $": {lastName} {firstName} {age}";
		}
	}
}
