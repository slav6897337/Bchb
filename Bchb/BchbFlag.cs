using System;
using System.Collections.Generic;
using System.Text;

namespace Bchb
{
    class BchbFlag
    {
        private int floor;
        public int Floor
        {
            get => floor;
          
            set
            {
                floor = value >= 3 ? value :
                throw new ArgumentException($"Floor = {value} must be more 3");
            }
        }
        private int entrance;
        public int Entrance
        { 
            get
            {
                return entrance;
            }
            set
            {
               entrance = 
               value <= floor &&
               value > 3 &&
               value % floor == 0 ? 
               value : throw new ArgumentException($"Entrance = {value} must be more 3, less floor and multiples floor");
            } 
        }
        private int apartment;
        public int Apartment
        { 
            get
            {
                return apartment;
            }

            set
            {
                apartment = 
                value > entrance &&
                value % entrance == 0 ? 
                value : throw new ArgumentException($"Apartment = {value} must be more 3 and multiples entrance");
            }
        }

        public BchbFlag() 
        {
            floor = 3;
            entrance = 3;
            apartment = 9;        
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
            int apartmentOnFloor = apartment / floor;
            int tempFloor = floor;
            while (tempFloor % 3 != 0)
            {
                tempFloor--;
                counterFloor++;
                counter += apartmentOnFloor;                
            }

            int temp = (apartment + 1 - counter) / 3;
            if (counter > 1)
            {
                Console.WriteLine($"Нижние этажи не должны включать свет, а это квартиры с  1 по {counter}");

            }
            for (; counter < apartment; counter++)
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
            int apartmentOnFloor = apartment / floor;
            int tempFloor = floor;
            bool color = false;
            int counter = 0;
            while (tempFloor % 3 != 0)
            {
                tempFloor--; ;
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
