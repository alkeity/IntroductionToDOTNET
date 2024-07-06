//#define INHERITANCE_1
//#define INHERITANCE_2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Academy
{
	internal class Program
	{
		static readonly string delimiter = "\n>--------<\n";
		static void Main(string[] args)
		{
#if INHERITANCE_1
			Human human = new Human("Vercetty", "Tommy", 30);
			Console.WriteLine(human);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97);
			Console.WriteLine(student);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			Console.WriteLine(teacher);

			Graduate graduate = new Graduate("Shredder", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg");
			Console.WriteLine(graduate);
#endif
#if INHERITANCE_2
			Human human = new Human("Vercetty", "Tommy", 30);
			Console.WriteLine(human);

			Human human2 = new Human("Diaz", "Ricardo", 50);
			Console.WriteLine(human2);

			Console.WriteLine(delimiter);

			Student student = new Student(human, "Theft", "Vice", 95, 98);
			Console.WriteLine(student);

			Graduate graduate = new Graduate(student, "How to make money");
			Console.WriteLine(graduate);

			Teacher teacher = new Teacher(human2, "Weapon disribution", 20);
			Console.WriteLine(teacher);

			Console.WriteLine(delimiter);
#endif
			Human[] group = new Human[] {
				new Human("Vercetty", "Tommy", 30),
				new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Shredder", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg")
			};

			StreamWriter writer = new StreamWriter("group.txt");

			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i]);
			}
			writer.Close();
			string cmd = "group.txt";

			System.Diagnostics.Process.Start("notepad", cmd);
		}
	}
}
