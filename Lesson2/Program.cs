using System;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");
			Console.WriteLine("Проверка числа на чётность:");

			do
			{
				int num = ReadInt($"Веедите число в диапозоне от {int.MinValue} до {int.MaxValue}:");
				Console.WriteLine($"Данное число было {(num % 2 == 0 ? "" : "не")}чётным.");

				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
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
