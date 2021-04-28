using System;
using System.ComponentModel;
using System.Globalization;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");

			var month = ReadMonthNum("Введите порядковый номер текущего месяца (от 1 до 12):");

			DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
			Console.WriteLine($"Сейчас месяц {formatInfo.GetMonthName(month)}");
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

		static int ReadMonthNum(string text)
		{
			int value;
			Console.WriteLine(text);
			while (!(int.TryParse(Console.ReadLine(), out value) && value > 0 && value <= 12))
				Console.WriteLine($"Повторим... {text}");

			return value;
		}
	}
}
