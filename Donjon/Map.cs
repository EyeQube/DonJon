using Donjon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
    internal class Map
    {
        private Cell[,] cells;
        private int Width { get; set; }
        private int Height { get; set; }
        public Hero Hero { get; set; }


        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        public Cell Cell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[x, y];
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    IDrawable drawable = Cell(x, y);
                    if (x == Hero.X && y == Hero.Y)
                    {
                        drawable = Hero;
                    }
                    Console.ForegroundColor = drawable.Color;
                    Console.Write(" " + drawable.Symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        internal List<Cell> AdjacentCells(int x, int y)
        {
            var aCells = new List<Cell> {
                Cell(x-1, y),
                Cell(x,   y-1),
                Cell(x+1, y),
                Cell(x,   y+1)
            };
            return aCells.Where(c => c != null).ToList();
        }

        internal void Cleanup()
        {
            foreach (var cell in cells)
            {
                var monster = cell.Monster;
                if (monster != null && monster.Health <= 0)
                {
                    cell.Monster = null;
                }
            }
        }
    }
}