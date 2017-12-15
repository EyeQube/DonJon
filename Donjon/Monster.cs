using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{

      internal class Monster : Creature
    {
        private Monster(string name, string symbol)
            : base(name, symbol, ConsoleColor.DarkGreen) { }

        internal static Monster Troll() => new Monster("Troll", "T") { Health = 2 };

        internal static Monster Goblin() => new Monster("Goblin", "G");
       /* {
            return new Monster("Goblin", "G");
        } */


    }




}
