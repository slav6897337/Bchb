using System;
using System.Collections.Generic;
using System.Text;

namespace Bchb
{
    class BchbFlag
    {
        private int floor;
        private int entrance;
        private int apartment;

        public int Floor
        {
            get => this.floor;

            set
            {
                this.floor = value >= 3 ? value :
                throw new ArgumentException($"Floor = {value} must be more 3");
            }
        }

        public int Entrance
        {
            get
            {
                return this.entrance;
            }

            set
            {
                this.entrance =
                value <= this.floor &&
                value > 3 &&
                value % this.floor == 0 ?
                value : throw new ArgumentException($"Entrance = {value} must be more 3, less floor and multiples floor");
            }
        }

        public int Apartment
        {
            get
            {
                return this.apartment;
            }

            set
            {
                this.apartment =
                value > this.entrance &&
                value % this.entrance == 0 ?
                value : throw new ArgumentException($"Apartment = {value} must be more 3 and multiples entrance");
            }
        }

        public BchbFlag()
        {
            this.floor = 3;
            this.entrance = 3;
            this.apartment = 9;
        }

        public BchbFlag(int floor, int entrance, int apartment)
        {
            this.floor = floor >= 3 ? floor : throw new ArgumentException($"Floor = {floor} must be more 3");

            this.entrance =
            entrance <= floor &&
            entrance > 3 &&
            entrance % floor == 0 ?
            floor : throw new ArgumentException($"Entrance = {entrance} must be more 3, less floor and multiples floor");

            this.apartment =
            apartment > entrance &&
            apartment % entrance == 0 ?
            apartment : throw new ArgumentException($"Apartment = {apartment} must be more 3 and multiples entrance {entrance}");
        }

        public void GetLight()
        {
            bool color = false;
            string light;
            int counter = 0;
            int counterFloor = 0;
            int apartmentOnFloor = this.apartment / this.floor;
            int tempFloor = this.floor;
            while (tempFloor % 3 != 0)
            {
                tempFloor--;
                counterFloor++;
                counter += apartmentOnFloor;
            }

            int temp = (this.apartment + 1 - counter) / 3;
            if (counter > 1)
            {
                Console.WriteLine($"Нижние этажи не должны включать свет, а это квартиры с  1 по {counter}");
            }

            for (; counter < this.apartment; counter++)
            {
                if (counter == temp)
                {
                    color = !color;
                    temp += temp;
                }

                light = color ? "красный" : "белый";
                Console.WriteLine($"Квартира номер {counter + 1} должна включить {light} свет");
            }
        }

        public void PrintFlag()
        {
            int apartmentOnFloor = this.apartment / this.floor;
            int tempFloor = this.floor;
            bool color = false;
            int counter = 0;
            while (tempFloor % 3 != 0)
            {
                tempFloor--;
                counter++;
            }

            int countFloor = tempFloor / 3;
            Console.WriteLine("Так будет выглядеть дом ночью: \n\n");

            for (int i = 0; i < tempFloor; i++)
            {
                if (i == countFloor)
                {
                    countFloor += countFloor;
                    color = !color;
                }

                Console.Write("\t ");

                for (int j = 1; j <= apartmentOnFloor; j++)
                {
                    if (!color)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" ");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }

                Console.WriteLine(" \n");
            }

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(" \n");
            }
        }
    }
}
