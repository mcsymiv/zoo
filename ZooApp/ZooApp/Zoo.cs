using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp
{
    public class Zoo
    {
        public int id;
        public string name;
        public bool isScary;
        public int priceTicket;

        public Animal(int id, string name, bool isScary, int priceTicket)
        {
            this.id = id;
            this.name = name;
            this.isScary = isScary;
            this.priceTicket = priceTicket;
        }
    }
}
