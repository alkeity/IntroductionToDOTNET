using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Student : Human
	{
		string speciality;
		string group;
		double rating;
		double attendance;

		public string Speciality
		{ 
			get => speciality;
			set {  speciality = value; }
		}

		public string Group
		{
			get => group;
			set { group = value; }
		}

		public double Rating
		{
			get => rating;
			set { rating = value; }
		}

		public double Attendance
		{
			get => attendance;
			set { attendance = value; }
		}

        public Student(
			string lastName, string firstName, int age,
			string speciality, string group,
			double rating, double attendance) : base(lastName, firstName, age)
        {
			Speciality = speciality;
            Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"Student ctor: {this.GetHashCode()}");
		}

		public Student(
			Human human,
			string speciality, string group,
			double rating, double attendance
			) :base(human)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"Student ctor: {this.GetHashCode()}");
		}

		public Student(Student other) : base(other)
		{
			this.Speciality = other.Speciality;
			this.Group = other.Group;
			this.Rating = other.Rating;
			this.Attendance = other.Attendance;
		}

        ~Student()
        {
			Console.WriteLine($"Student dtor: {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Speciality} {Group} {Rating} {Attendance}";
		}
	}
}
