using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp
{
    public class Visitor
    {
        public bool isAdult;
        public List<Animal> myListAnimals;
        public int priceFood = 5;
        public int countFood;

        public Visitor()
        {
            myListAnimals = new List<Animal>();
        }

        public void CountTickets()
        {
            int result = 0;
            Console.WriteLine();
            Console.WriteLine("Your choise:");
            Console.WriteLine("________________________");
            Console.WriteLine("|-----------ZOO---------");
            Console.WriteLine("|_______________________");
            for (int i = 0; i < myListAnimals.Count; i++)
            {
                string spase = Caligrafic(myListAnimals[i].name);

                Console.WriteLine($"| {myListAnimals[i].id} {myListAnimals[i].name} {spase} {myListAnimals[i].priceTicket}\t");
                result += myListAnimals[i].priceTicket;
            }

            if (countFood != 0)
            {
                Console.WriteLine($"| Food_____{countFood}x{priceFood}={countFood * priceFood}\t");
            }
            Console.WriteLine("|_______________________");
            Console.WriteLine($"| TOTAL_______{result + (countFood * priceFood)}\t");
            Console.WriteLine("|_______________________");
        }


        public string Caligrafic(string name)
        {
            int result = 0;
            int lengthName = name.Length;
            int max = 0;
            for (int i = 0; i < myListAnimals.Count; i++)
            {
                if (myListAnimals[i].name.Length > max)
                {
                    max = myListAnimals[i].name.Length;
                }
            }
            result = max - lengthName + 2;
            string spase = "";
            for (int i = 0; i < result; i++)
            {
                spase += " ";
            }
            return spase;
        }

        public bool CheckEquals(int ID)
        {
            bool equals = false;
            int count = 0;
            for (int i = 0; i < myListAnimals.Count; i++)
            {
                if (myListAnimals[i].id == ID)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                equals = true;
            }
            return equals;
        }
    }
}
