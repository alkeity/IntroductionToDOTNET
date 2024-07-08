using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	internal class Teacher : Human
	{
		static readonly int SPECIALITY_WIDTH = 20;
		static readonly int EXPERIENCE_WIDTH = 8;

		string speciality;
		int experience;

		public string Speciality
		{
			get => speciality;
			set { speciality = value; }
		}

		public int Experience
		{
			get => experience;
			set { experience = value; }
		}

        public Teacher(
			string lastName, string firstName, int age,
			string speciality, int experience
			) : base(lastName, firstName, age)
        {
            Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"Teacher ctor: {this.GetHashCode()}");
		}

        public Teacher(Human human, string speciality, int experience) : base(human)
        {
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"Teacher ctor: {this.GetHashCode()}");
		}

        ~Teacher()
        {
			Console.WriteLine($"Teacher dtor: {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $"{speciality.PadRight(SPECIALITY_WIDTH)}{experience.ToString().PadRight(EXPERIENCE_WIDTH)}";
		}

		public override string ToFile()
		{
			return base.ToFile().Replace(';', ',') + $"{Speciality},{Experience};";
		}

		public override void Init(string[] values)
		{
			base.Init(values);
			Speciality = values[4];
			Experience = Convert.ToInt32(values[5]);
		}
	}
}
