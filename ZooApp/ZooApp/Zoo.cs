using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp
{
    public class Zoo
    {
        public List<Animal> animalsList = new List<Animal> {
         new Animal (1, "Elephant" , false, 11),
         new Animal (2, "Lion" , true, 9),
         new Animal (3, "Monkey" , false, 7),
         new Animal (4, "Deer" , false, 7),
         new Animal (5, "Fox" , false, 5),
         new Animal (6,"Giraffe" , false, 10),
         new Animal (7, "Polar bear" , false, 9),
         new Animal (8,"Tiger" , false, 9),
         new Animal (9,"Jackal" , true, 5),
         new Animal (10, "Crocodile" , true, 10)
    };

        public void DisplayPrice(bool isAdult)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"№ Animal       Price");

            for (int i = 0; i < animalsList.Count; i++)
            {

                if (isAdult == true)
                {
                    string spase = Caligrafic(animalsList[i].name);
                    Console.WriteLine($"{i + 1} {animalsList[i].name} {spase} {animalsList[i].priceTicket}");
                }
                else if (isAdult == false && animalsList[i].isScary != true)
                {
                    string spase = Caligrafic(animalsList[i].name);
                    Console.WriteLine($"{i + 1} {animalsList[i].name} {spase} {animalsList[i].priceTicket}");
                }
            }
            Console.WriteLine("---------------------------");
        }

        public string Caligrafic(string name)
        {
            int result = 0;
            int lengthName = name.Length;
            int max = 0;
            for (int i = 0; i < animalsList.Count; i++)
            {
                if (animalsList[i].name.Length > max)
                {
                    max = animalsList[i].name.Length;
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
    }
}
