/// <summary>
/// The project.
/// </summary>

namespace Bchb
{
    using System;

    class Program
    {
        private static void Main(string[] args)
        {
            int f, e, a;
            Console.WriteLine("Введите количество этажей в доме");
            while (!int.TryParse(Console.ReadLine(), out f))
            {
                Console.WriteLine("Вы ввели неверное значение");
            }

            Console.WriteLine("Введите количество подъездов");
            while (!int.TryParse(Console.ReadLine(), out e))
            {
                Console.WriteLine("Вы ввели неверное значение");
            }

            Console.WriteLine("Введите количество квартир");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Вы ввели неверное значение");
            }

            Console.WriteLine(" ");
            var dom1 = new BchbFlag();
            dom1.Floor = f;
            dom1.Entrance = e;
            dom1.Apartment = a;
            dom1.GetLight();
            dom1.PrintFlag();
            Console.ReadKey();
        }
    }
}