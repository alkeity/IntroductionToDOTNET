using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate : Student
	{
		static readonly int SUBJECT_WIDTH = 8;
		string subject;

		public string Subject
		{
			get => subject;
			set => subject = value;
		}

		public Graduate(
			string lastName, string firstName, int age,
			string speciality, string group,
			double rating, double attendance,
			string subject
			) : base(lastName, firstName, age, speciality, group, rating, attendance)
		{
			Subject = subject;
			Console.WriteLine($"Graduate ctor: {this.GetHashCode()}");
		}

		public Graduate(Human human,
			string speciality, string group,
			double rating, double attendance,
			string subject) :base(human, speciality, group, rating, attendance)
		{
			Subject = subject;
		}

		public Graduate(Student student, string subject) : base(student)
		{
			Subject = subject;
		}

		~Graduate()
		{
			Console.WriteLine($"Graduate dtor: {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Subject.PadRight(SUBJECT_WIDTH)}";
		}
	}
}
