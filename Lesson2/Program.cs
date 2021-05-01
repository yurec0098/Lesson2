using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lesson2
{
	class Program
	{
		[Flags]
		enum DaysOfWeek
		{
			None,

			Monday = 0b_0000_0001,
			Tuesday = 0b_0000_0010,
			Wednesday = 0b_0000_0100,
			Thursday = 0b_0000_1000,
			Friday = 0b_0001_0000,
			Saturday = 0b_0010_0000,
			Sunday = 0b_0100_0000,
		}

		static DaysOfWeek workDays = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday;
		static DaysOfWeek weekend = DaysOfWeek.Saturday | DaysOfWeek.Sunday;
		static DaysOfWeek allDays = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday | DaysOfWeek.Saturday | DaysOfWeek.Sunday;

		static DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				WriteLineCentr("Добро пожаловать!", 30);
				WriteLineCentr("Выберите чем займёмся:", 30);
				Console.WriteLine();
				Console.WriteLine("  1. Расчёт средней температуры");
				Console.WriteLine("  2. Определяем текущий месяц");
				Console.WriteLine("  3. Проверка числа на чётность");
				Console.WriteLine("  4. Распечатать чек");
				Console.WriteLine("  5. Сезоны года");
				Console.WriteLine("  6. Рабочие дни");
				Console.WriteLine();
				Console.WriteLine("  0. Выход");

				string line = Console.ReadLine();
				Console.Clear();
				switch (line)
				{
					case "1":
						AverageTemperature(); break;
					case "2":
						CurrentMonth(); break;
					case "3":
						ParityCheck(); break;
					case "4":
						PrintReceipt(); break;
					case "5":
						SeasonOfYear(); break;
					case "6":
						WorkDays(); break;

					case "0":
						return;

					default:
						break;
				}
			}
		}


		private static void AverageTemperature()
		{
			Console.WriteLine("Расчёт средней температуры за сутки");
			do
			{
				float min_temperature = ReadFloat("Введите минимальную температуру за сутки:");
				float max_temperature = ReadFloat("Введите максимальную температуру за сутки:");

				Console.WriteLine($"Средняя температура за сутки состовляла: {(min_temperature + max_temperature) / 2:0.0} градусов");

				Console.WriteLine();
				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}
		private static void CurrentMonth()
		{
			Console.WriteLine("Определяем текущий месяц");
			do
			{
				var month = ReadInt_MinMax("Введите порядковый номер текущего месяца (от 1 до 12):", 1, 12);
				Console.WriteLine($"Сейчас месяц {formatInfo.GetMonthName(month)}");

				Console.WriteLine();
				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}
		private static void ParityCheck()
		{
			Console.WriteLine("Проверка числа на чётность");
			do
			{
				int num = ReadInt($"Веедите число в диапозоне от {int.MinValue} до {int.MaxValue}:");
				Console.WriteLine($"Данное число было {(num % 2 == 0 ? "" : "не")}чётным.");

				Console.WriteLine();
				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}
		private static void PrintReceipt()
		{
			Console.WriteLine("Распечатка чека");
			do
			{
				Console.WriteLine();
				new ReceiptData("Денисова Г.", 139, 284).WriteConsole();
				Console.WriteLine();

				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}
		private static void SeasonOfYear()
		{
			Console.WriteLine("Сезон года");
			do
			{
				float min_temperature = ReadFloat("Введите минимальную температуру за сутки:");
				float max_temperature = ReadFloat("Введите максимальную температуру за сутки:");

				float average_temperature = (min_temperature + max_temperature) / 2;
				Console.WriteLine($"Средняя температура за сутки состовляла: {average_temperature:0.0} градусов");

				var month = ReadInt_MinMax("Введите порядковый номер текущего месяца (от 1 до 12):", 1, 12);
				switch (month)
				{
					case 1:
					case 2:
					case 12:
						if (average_temperature > 0)
							Console.WriteLine($"Дождливая зима. Месяц {formatInfo.GetMonthName(month)}");
						else
							Console.WriteLine($"Зима. Месяц {formatInfo.GetMonthName(month)}");
						break;

					case 3:
					case 4:
					case 5:
						Console.WriteLine($"Весна. Месяц {formatInfo.GetMonthName(month)}");
						break;

					case 6:
					case 7:
					case 8:
						Console.WriteLine($"Лето. Месяц {formatInfo.GetMonthName(month)}");
						break;

					case 9:
					case 10:
					case 11:
						Console.WriteLine($"Осень. Месяц {formatInfo.GetMonthName(month)}");
						break;

					default:
						Console.WriteLine($"Месяц {formatInfo.GetMonthName(month)}");
						break;
				}

				Console.WriteLine();
				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}
		private static void WorkDays()
		{
			Console.WriteLine("Рабочие дни");
			do
			{
				var random = new Random((int)DateTime.Now.Ticks);
				var office_list = new List<DaysOfWeek>();

				for (int i = 0; i < 10; i++)
					office_list.Add((DaysOfWeek)random.Next((int)DaysOfWeek.Monday, (int)allDays));

				//office_list.Add(DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday);
				//office_list.Add(allDays);

				for (int i = 0; i < office_list.Count; i++)
				{
					Console.WriteLine();
					Console.WriteLine($"Рабочие дни Оффиса {i + 1}: {GetDaysOfWeek_Locale(office_list[i])}");
					CheckWorkDays(office_list[i], $"Оффис {i + 1}");
				}

				Console.WriteLine();
				Console.WriteLine("Попробуем ещё? Тогда введите +");
			} while (Console.ReadLine() == "+");
		}


		private static void CheckWorkDays(DaysOfWeek days, string office)
		{
			if (days.HasFlag(allDays))
				Console.WriteLine($"{office} работает без выходных");
			else
			{
				if (days.HasFlag(workDays))
					Console.WriteLine($"{office} работает по всем будням");
				if (days.HasFlag(weekend))
					Console.WriteLine($"{office} работает в выходные");
			}
		}
		private static string GetDaysOfWeek_Locale(DaysOfWeek office1_workdays)
		{
			var off1 = office1_workdays.ToString().Split(", ");

			var list = new List<string>();
			foreach (string day in off1)
				list.Add(formatInfo.GetDayName((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day)));

			return string.Join(", ", list);
		}


		static void WriteLineCentr(string text, int max = 40)
		{
			int startPos = (max - text.Length) / 2;
			Console.SetCursorPosition(startPos, Console.CursorTop);
			Console.WriteLine($"{text}");
		}
		static void WriteLineRight(string text, int max = 40)
		{
			int startPos = max - text.Length;
			if (startPos - Console.CursorLeft < 4)
				Console.CursorTop++;

			Console.SetCursorPosition(startPos, Console.CursorTop);
			Console.WriteLine($"{text}");
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
		static int ReadInt_MinMax(string text, int min, int max)
		{
			int value;
			Console.WriteLine(text);
			while (!(int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max))
				Console.WriteLine($"Повторми... {text}");

			return value;
		}


		class ReceiptData
		{
			public string ShopName = "СУПЕРМАРКЕТ 'Семья'";
			public string Address = "пл. Кооперативная д.2";
			public long PN = 405375312140;

			public string Cashier;
			public int ChekID;
			public int Cashbox;

			public List<Goods> GoodsList = new List<Goods>();

			public struct Goods
			{
				public string Name;
				public int Code;
				public float Count;
				public float Price;

				public Goods(string name, int code, float count, float price)
				{
					Name = name;
					Code = code;
					Count = count;
					Price = price;
				}

				public void WriteConsole()
				{
					Console.WriteLine($"  {Count} x {Price:0.00}");
					Console.Write($"{Code} {Name}");
					WriteLineRight($"{Count * Price:0.00}");
				}
			}

			public ReceiptData(string cashier, int chekID, int cashbox)
			{
				Cashier = cashier;
				ChekID = chekID;
				Cashbox = cashbox;

				InitGoods();
			}

			public void InitGoods()
			{
				var random = new Random((int)DateTime.Now.Ticks);
				GoodsList.Add(new Goods("Ручка синяя", random.Next(1000, 9999), random.Next(2, 7), 2.5f));
				GoodsList.Add(new Goods("Простой карандаш", random.Next(1000, 9999), random.Next(2, 10), 1f));
				GoodsList.Add(new Goods("Стирательная резинка", random.Next(1000, 9999), random.Next(1, 3), 0.5f));
				GoodsList.Add(new Goods("Линейка", random.Next(1000, 9999), 1, 2f));
			}
			public void WriteConsole()
			{
				WriteLineCentr(ShopName);
				WriteLineCentr(Address);
				WriteLineCentr($"ПН {PN}");

				Console.WriteLine($"#Касир: {Cashier}");
				Console.WriteLine($"#Чек: #{ChekID}");
				Console.WriteLine($"#Касса: #{ChekID}");

				foreach (var good in GoodsList)
					good.WriteConsole();

				Console.WriteLine(new string('-', 40));
				Console.Write("СУММА:");
				WriteLineRight($"{GoodsList.Sum(x => x.Price * x.Count):0.00}");
				Console.WriteLine(new string('-', 40));

				WriteLineCentr($"{DateTime.Now:u}".TrimEnd('Z'));
				WriteLineCentr($"ФИСКАЛЬНЫЙ ЧЕК");
			}
		}
	}
}
