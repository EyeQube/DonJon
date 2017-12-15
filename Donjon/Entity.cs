using System;

namespace Donjon
{
    abstract class Entity : IDrawable
    {
        public string Symbol { get; set; }
        public ConsoleColor Color { get; }
        public string Name { get; private set; }

        protected Entity(string name, string symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Name = name;
            Color = color;
        }
    }
}