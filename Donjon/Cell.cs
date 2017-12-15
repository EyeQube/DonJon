using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
     internal class Cell : IDrawable
    {
        private string symbol = ".";
        private ConsoleColor color = ConsoleColor.DarkGray;
        public Monster Monster { get; set; }

        public string Symbol => Monster?.Symbol ?? Items.FirstOrDefault()?.Symbol ?? symbol;


        public ConsoleColor Color
            => Monster?.Color
            ?? FirstItem?.Color
            ?? color;

        public Item FirstItem => Items.FirstOrDefault();
        public List<Item> Items { get; } = new List<Item>();
        /* {
get
{
return Monster?.Symbol ?? symbol;   
}
} */

    }
}