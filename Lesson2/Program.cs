using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

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

		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");

			var office1_workdays = DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday;
			var office2_workdays = allDays;

			CheckWorkDays(office1_workdays, "Оффис 1");
			Console.WriteLine($"Рабочие дни Оффиса 1: {GetDaysOfWeek_Locale(office1_workdays)}\n");


			CheckWorkDays(office2_workdays, "Оффис 2");
			Console.WriteLine($"Рабочие дни Оффиса 2: {GetDaysOfWeek_Locale(office2_workdays)}\n");
		}

		private static void CheckWorkDays(DaysOfWeek days, string office)
		{
			if ((days & workDays) == workDays)
				Console.WriteLine($"{office} работает по всем будням");
			if ((days & weekend) == weekend)
				Console.WriteLine($"{office} работает в выходные");
		}

		private static string GetDaysOfWeek_Locale(DaysOfWeek office1_workdays)
		{
			DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
			var off1 = office1_workdays.ToString().Split(", ");

			var list = new List<string>();
			foreach (string day in off1)
				list.Add(formatInfo.GetDayName((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day)));

			return string.Join(", ", list);
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
