using System;
using System.Collections.Generic;

namespace Donjon
{
    abstract class Creature : Entity
    {
        
        public int Health { get; protected set; } = 1;
        public int Damage { get; private set; } = 1;

        protected Creature(string name, string symbol, ConsoleColor color)
            : base(name, symbol, color)
        {
            
        }

        public List<string> Attack(Creature opponent)
        {
            var log = new List<string>()
            {
                $"The {Name} attacks the {opponent.Name} ({opponent.Health} hp) for {Damage} damage." 
            };
            opponent.Health -= Damage;
            if (opponent.Health <= 0) log.Add($"The {opponent.Name} is dead.");
            return log;
        }

    }
}