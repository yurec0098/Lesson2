using System;
using System.IO;

namespace Lesson2
{
	class Program
	{
        struct Goods
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

                if (Console.CursorLeft > 28)
                    Console.CursorTop++;

                Console.SetCursorPosition(30, Console.CursorTop);
                Console.WriteLine($"{Count * Price:0.00}");
			}
		}

		static void Main(string[] args)
		{
            var random = new Random((int)DateTime.Now.Ticks);
			Console.WriteLine("Добро пожаловать!");


            var prod = new Goods("Печенье 'Днипро'", random.Next(1000, 9999), 10.6f, 11);
            prod.WriteConsole();
            prod.WriteConsole();
            prod.WriteConsole();


            Console.ReadLine();
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
