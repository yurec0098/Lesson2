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

			var month = ReadInt("Введите порядковый номер текущего месяца:");

			DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
			Console.WriteLine($"Сейчас месяц {formatInfo.GetMonthName(month)}");
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
