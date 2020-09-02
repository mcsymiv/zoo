using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp
{
    public class TicketWindow
    {
        public Zoo zoo = new Zoo();
        public List<Visitor> visitorsList = new List<Visitor>();

        public void Start()
        {
            ShowCountVisitors();
            Visitor visitor = new Visitor();
            visitor.isAdult = AskAge();
            zoo.DisplayPrice(visitor.isAdult);
            AskAnimalList(visitor);
        }
        public void AskAnimalList(Visitor visitor)
        {
            CheckListVisitor(visitor);

            Console.WriteLine();
            Console.WriteLine("Okey...you chiose animal:");
            for (int i = 0; i < visitor.myListAnimals.Count; i++)
            {
                Console.WriteLine($"{visitor.myListAnimals[i].id}-{visitor.myListAnimals[i].name}");
            }
            Console.WriteLine();

            bool takeFood = AskFood();

            if (takeFood == true)
            {
                if (visitor.myListAnimals.Count == 1)
                {
                    visitor.countFood = 1;
                }
                else
                {
                    PortionsFood(visitor);
                }
            }
            else
            {
                visitor.countFood = 0;
            }

            AgreeForPrice(visitor);
        }

        public void CheckListVisitor(Visitor visitor)
        {
            {
                visitor.myListAnimals.Clear();
                List<int> tmplist;
                bool isValid;
                do
                {
                    isValid = true;
                    Console.WriteLine("Choise, please, numbers animals");
                    string allAnimals = Console.ReadLine();
                    string[] tmpArr = allAnimals.Split(new char[] { ' ', ',' });

                    tmplist = new List<int>();

                    for (int i = 0; i < tmpArr.Length; i++)
                    {
                        if (int.TryParse(tmpArr[i], out int numberAnimal) == true)
                        {
                            if (tmplist.Contains(numberAnimal) == false)
                            {
                                if (numberAnimal > 0 && numberAnimal <= 10)
                                {
                                    if (visitor.isAdult == false && zoo.animalsList[numberAnimal - 1].isScary == true)
                                    {
                                        Console.WriteLine($"O...you choise-{zoo.animalsList[numberAnimal - 1].id}." +
                                            $" {zoo.animalsList[numberAnimal - 1].name}");
                                        Console.WriteLine("This animal is not for kids");
                                        Console.WriteLine();
                                        isValid = false;
                                    }
                                    else
                                    {
                                        tmplist.Add(numberAnimal);
                                    }
                                }
                                else
                                {
                                    isValid = false;
                                }
                            }
                            else
                            {
                                isValid = false;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }

                    if (isValid == false)
                    {
                        Console.WriteLine("You put wrong number");
                    }
                } while (isValid == false);

                for (int i = 0; i < tmplist.Count; i++)
                {
                    visitor.myListAnimals.Add(zoo.animalsList[tmplist[i] - 1]);
                }
            }
        }

        public int ShowCountVisitors()
        {
            if (visitorsList.Count < 5)
            {
                Console.WriteLine($"--The zoo welcomes you--!");
                Console.WriteLine($"Now in zoo {visitorsList.Count} visitors.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Now in zoo {visitorsList.Count} visitors.");
                Console.WriteLine("Sorry zoo is full");
                Console.WriteLine("We do not sell tickets now. you have to wait for someone to come out");
            }
            return visitorsList.Count;
        }

        public bool AskAge()
        {
            bool isAdult = false;
            int age;
            for (; ; )
            {
                Console.WriteLine("Good day. Tell me the age of the person for whom this ticket?");
                if (int.TryParse(Console.ReadLine(), out age) == true)
                {
                    if (age > 7)
                    {
                        isAdult = true;
                        break;
                    }
                    else if (age >= 0 && age <= 7)
                    {
                        isAdult = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You put wrong number");
                    }
                }
                else
                {
                    Console.WriteLine("You put wrong number");
                }
            }
            return isAdult;
        }

        public bool AskFood()
        {
            bool takeFood = false;
            for (; ; )
            {
                Console.WriteLine("Do you take food for animals?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                string haveFood = Console.ReadLine();
                if (haveFood == "1" || haveFood.ToLower() == "yes")
                {
                    takeFood = true;
                    break;
                }
                else if (haveFood == "2" || haveFood.ToLower() == "no")
                {
                    takeFood = false;
                    break;
                }
                else
                {
                    Console.WriteLine("You put wrong number");
                }
            }
            return takeFood;
        }

        public void PortionsFood(Visitor visitor)
        {
            int portions;

            Console.WriteLine();
            for (; ; )
            {
                Console.WriteLine("How many portions of food for animals do you want? ");
                if (int.TryParse(Console.ReadLine(), out portions) == true)
                {
                    if (portions <= visitor.myListAnimals.Count && portions > 0)
                    {
                        break;
                    }
                    else if (portions > visitor.myListAnimals.Count)
                    {
                        Console.WriteLine("There are more portions than animals");
                    }
                    else
                    {
                        Console.WriteLine("You put wrong number");
                    }
                }
                else
                {
                    Console.WriteLine("You put wrong number");
                }
            }
            visitor.countFood = portions;
        }

        public void AgreeForPrice(Visitor visitor)
        {
            string choise = "";
            visitor.CountTickets();

            for (; ; )
            {
                Console.WriteLine("Do you agree with this choise?");
                Console.WriteLine("1. Yes.I buy this ticket");
                Console.WriteLine("2. No. I want chage");
                Console.WriteLine("3. No. It's very expensive, i won't go");
                choise = Console.ReadLine();
                if (choise == "1")
                {
                    if (visitorsList.Count < 6)
                    {
                        visitorsList.Add(visitor);
                        Console.WriteLine("Thank you. Take your ticket!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately now you can't go to the zoo.\n " +
                            "There are already 5 visitors at the zoo");
                    }

                }
                else if (choise == "2")
                {
                    Console.Clear();
                    zoo.DisplayPrice(visitor.isAdult);
                    Console.WriteLine("Ok. Make, please, new choise");
                    AskAnimalList(visitor);
                    break;

                }
                else if (choise == "3")
                {
                    Console.WriteLine("Good buy");
                    Start();
                    break;
                }
                else
                {
                    Console.WriteLine("You put wrong number");
                }
            }
        }
    }
}

