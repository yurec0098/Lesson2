using System;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать!");

            Console.WriteLine("Введите название магазина: ");
            var nameShop = Console.ReadLine();
            Console.WriteLine("Введите номер смены: ");
            var numSmena = Console.ReadLine();
            Console.WriteLine("Введите ФИО кассира: ");
            var nameWorker = Console.ReadLine();
            Console.WriteLine("Введите место расчетов: ");
            var Place = Console.ReadLine();
            int numStuff = ReadInt("Введите количество товаров: ");
            string[] Stuff = new string[numStuff]; //Создаем массив с количеством товаров.
            int[] Price = new int[numStuff]; //Создаем массив со стоимостью этих товаров.
            for (int i = 0; i < numStuff; i++) //Цикл, который заносит в массив названия и цену.
            {
                Console.WriteLine("Введите название товара: ");
                Stuff[i] = Console.ReadLine();
                Price[i] = ReadInt("Введите стоимость товара: ");
            }

            Console.WriteLine("Ваш чек: "); //Создание чека.
            Console.WriteLine(nameShop);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(numSmena);
            Console.WriteLine(nameWorker);
            Console.WriteLine(Place);
            Console.WriteLine("ТОВАР");


            for (int i = 0; i < numStuff; i++) //Цикл объявляющий товар и сумму.
            {
                Console.WriteLine(Stuff[i]);
                Console.WriteLine(Price[i]);
            }

            int FullPrice = 0;

            for (int i = 0; i < numStuff; i++) //Цикл обьявляющий сумму всех товаров.
            {
                FullPrice = FullPrice + Price[i];
            }

            Console.WriteLine("Итог: " + FullPrice);

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
