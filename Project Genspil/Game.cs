using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genspil
{
    class Game
    {

        // Field
        // private string name;
        // Property
        public string Name { get; set; }
        public string Genre { get; private set; }
        public int Players { get; private set; }
        public int Age { get; private set; }
        public double Price { get; private set; }
        public char Condition { get; private set; }
        public bool Requested { get; private set; } //efterspørgsel
        public int Stockstatus { get; private set; }

        
        public Game(string name, string genre, int players, int age, double price, char condition, bool requested, int stockstatus)
        {
            Name = name;
            Genre = genre;
            Players = players;
            Age = age;
            Price = price;
            Condition = condition;
            Requested = requested;
            Stockstatus = stockstatus + 1;
            //year = _year;
 
        }


        public void getData()
        {
            Console.WriteLine($"the game is " + Name);
        }

        public void setName(string name)
        {
            Name = name;
        }

    }
}
