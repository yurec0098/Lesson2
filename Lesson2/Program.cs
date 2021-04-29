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

			float min_temperature = ReadFloat("Введите минимальную температуру за сутки:");
			float max_temperature = ReadFloat("Введите максимальную температуру за сутки:");

			float average_temperature = (min_temperature + max_temperature) / 2;
			Console.WriteLine($"Средняя температура за сутки состовляла: {average_temperature:0.0} градусов");

			var month = ReadMonthNum("Введите порядковый номер текущего месяца (от 1 до 12):");

			DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
			switch (month)
			{
				case 1:
				case 2:
				case 12:
					if(average_temperature > 0)
						Console.WriteLine($"Дождливая зима. Месяц {formatInfo.GetMonthName(month)} и ");
					else
						Console.WriteLine($"Зима. Месяц {formatInfo.GetMonthName(month)} и ");
					break;

				case 3:
				case 4:
				case 5:
					Console.WriteLine($"Весна. Месяц {formatInfo.GetMonthName(month)} и ");
					break;

				case 6:
				case 7:
				case 8:
					Console.WriteLine($"Лето. Месяц {formatInfo.GetMonthName(month)} и ");
					break;

				case 9:
				case 10:
				case 11:
					Console.WriteLine($"Осень. Месяц {formatInfo.GetMonthName(month)} и ");
					break;

				default:
					Console.WriteLine($"Месяц {formatInfo.GetMonthName(month)}");
					break;
			}
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
