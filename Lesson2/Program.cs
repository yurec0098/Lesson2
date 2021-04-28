using System;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");

			float min_temperature = ReadFloat("Введите минимальную температуру за сутки:");
			float max_temperature = ReadFloat("Введите максимальную температуру за сутки:");

			Console.WriteLine($"Средняя температура за сутки состовляла: {(min_temperature + max_temperature) / 2:0.0} градусов");
		}

		static int ReadInt(string text)
		{
			int value;
			Console.WriteLine(text);
			while (!int.TryParse(Console.ReadLine(), out value))
				Console.WriteLine($"Повторми... {text}");

			return value;
		}
		static float ReadFloat(string text)
		{
			float value;
			Console.WriteLine(text);
			while (!float.TryParse(Console.ReadLine(), out value))
				Console.WriteLine($"Повторми... {text}");

			return value;
		}
	}
}
