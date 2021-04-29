using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lesson2
{
	class Program
	{
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
				WriteLineRight($"{GoodsList.Sum(x=>x.Price * x.Count):0.00}");
				Console.WriteLine(new string('-', 40));

				WriteLineCentr($"{DateTime.Now:u}".TrimEnd('Z'));
				WriteLineCentr($"ФИСКАЛЬНЫЙ ЧЕК");
			}
		}

		static void Main(string[] args)
		{
			new ReceiptData("Денисова Г.", 139, 284).WriteConsole();
			Console.ReadLine();
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
	}
}
