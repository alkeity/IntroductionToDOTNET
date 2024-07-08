//#define INHERITANCE_1
//#define INHERITANCE_2
//#define CLASSWORK
#define CLASSWORK2
//#define HOMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Academy
{
	internal class Program
	{
		static readonly string delimiter = "\n>---------------<\n";
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
#if CLASSWORK
			Human[] group = new Human[] {
				new Human("Vercetty", "Tommy", 30),
				new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Shredder", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg")
			};

			StreamWriter writer = new StreamWriter("group.txt");

			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i].ToFile());
			}
			writer.Close();
			string cmd = "group.csv";

			System.Diagnostics.Process.Start("notepad", cmd);
#endif
#if CLASSWORK2
			Human[] group = new Human[] {
				new Human("Vercetty", "Tommy", 30),
				new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Shredder", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg")
			};
			string cmd = "..\\..\\group.csv";

			Print(group);
			Save(group, cmd);

			Human[] group2 = Load(cmd);
			Console.WriteLine();
			Print(group2);

			System.Diagnostics.Process.Start("notepad", cmd);
#endif
#if HOMEWORK
			string cmd = "group.txt";
			Human[] group = Load(cmd);
			Print(group);
#endif
		}

		static void Print(string path)
		{
			Human[] group = Load(path);
			Print(group);
		}

		static void Print(Human[] group)
		{
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i].ToString());
			}
		}

		static void Save(Human[] group, string path)
		{
			using (StreamWriter writer = new StreamWriter(path))
			{
				for (int i = 0; i < group.Length; i++)
				{
					writer.WriteLine(group[i].ToFile());
				}
			}
		}

		static Human[] Load(string path)
		{
			List<Human> group = new List<Human>();

			using (StreamReader reader = new StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					string buffer = reader.ReadLine();
					if (buffer.Length == 0) continue;
					string[] values = buffer.Split(':', ',', ';');
					group.Add(HumanFactory(values.First()));
					group.Last().Init(values);
				}
			}

			return group.ToArray();
		}

		//static Human[] Load(string path)
		//{
		//	string temp;
		//	int length = CountLines(path);
		//	Human[] group = new Human[length];
		//	using (StreamReader reader = new StreamReader(path))
		//	{
		//		for (int i = 0; i < length; i++)
		//		{
		//			temp = reader.ReadLine();
		//			group[i] = ParseString(temp);
		//		}
		//	}
		//	return group;
		//}

		static Human HumanFactory(string type)
		{
			Human human = null;

			switch (type)
			{
				case "Human": human = new Human("", "", 0); break;
				case "Teacher": human = new Teacher("", "", 0, "", 0); break;
				case "Student": human = new Student("", "", 0, "", "", 0, 0); break;
				case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0, ""); break;
				default: throw new Exception("no");
			}
			return human;
		}

		//static Human ParseString(string input)
		//{
		//	Regex ptrn = new Regex(@"\w+( \w+)*");
		//	MatchCollection temp = ptrn.Matches(input);
		//	Human tempHuman = new Human(temp[1].Value, temp[2].Value, Convert.ToInt32(temp[3].Value));

		//	switch (temp[0].Value)
		//	{
		//		case "Human":
		//			return tempHuman;
		//		case "Teacher":
		//			return new Teacher(tempHuman, temp[4].Value, Convert.ToInt32(temp[5].Value));
		//		case "Student":
		//			return new Student(tempHuman, temp[4].Value, temp[5].Value, Convert.ToInt32(temp[6].Value), Convert.ToInt32(temp[7].Value));
		//		case "Graduate":
		//			return new Graduate(tempHuman, temp[4].Value, temp[5].Value, Convert.ToInt32(temp[6].Value), Convert.ToInt32(temp[7].Value), temp[8].Value);
		//		default:
		//			throw new Exception("Incorrect string");
		//	}
		//}

		//static int CountLines(string path)
		//{
		//	int count = 0;
		//	using (StreamReader reader = new StreamReader(path))
		//	{
		//		while (reader.ReadLine() != null) { count++; }
		//	}
		//	return count;
		//}
	}
}
