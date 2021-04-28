using System;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");
		}

		static int ReadInt(string text)
		{
			int value;
			Console.WriteLine(text);
			while (!int.TryParse(Console.ReadLine(), out value))
				Console.WriteLine($"Повторим... {text}");

			return value;
		}
		static float ReadFloat(string text)
		{
			float value;
			Console.WriteLine(text);
			while (!float.TryParse(Console.ReadLine(), out value))
				Console.WriteLine($"Повторим... {text}");

			return value;
		}
	}
}
