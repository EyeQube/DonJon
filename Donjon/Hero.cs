using System;
using Lib;

namespace Donjon
{
     internal class Hero : Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ActionPoints { get; internal set; }
        public LimitedList<Item> Backpack { get; } = new LimitedList<Item>(6);

        public Hero() : base("Hero", "☻", ConsoleColor.White)
        {
            Health = 5;
        }
        

    }
}