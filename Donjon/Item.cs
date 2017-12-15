using System;

namespace Donjon
{
    internal class Item : Entity
    {
        public Item(string name, string symbol, ConsoleColor color) : base(name, symbol, color)
        {

        }

        internal static Item Coin() => new Item("Coin", "c", ConsoleColor.Yellow);
        internal static Item Sock() => new Item("Dirty sock", "s", ConsoleColor.Gray);
    }
}