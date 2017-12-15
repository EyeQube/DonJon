using System;
using System.Collections.Generic;
using System.Linq;


namespace Donjon
{
    internal class Game
    {
        private bool playing = true;
        private readonly Hero hero = new Hero();
        private Map map;
        private List<string> log = new List<string>();

        public Game()
        {
        }

        public void Start()
        {
            Console.Clear();
            Initialize();
            Play();
        }

        private void Play()
        {
            do
            {
                hero.ActionPoints = 2;
                Draw();
                while (hero.ActionPoints > 0)
                {
                    PlayerAction();
                    Draw();
                }
                GameAction();
            } while (playing);
            // Game Over
            Draw();
        }

        private void GameAction()
        {
            map.Cleanup();
            var adjacentCells = map.AdjacentCells(hero.X, hero.Y);
            foreach (var cell in adjacentCells)
            {
                var monster = cell.Monster;
                if (monster != null)
                {
                    var result = monster.Attack(hero);
                    log.AddRange(result);
                    if (hero.Health <= 0)
                    {
                        playing = false;
                        return;
                    }
                }
            }
        }

        private void PlayerAction()
        {
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Move(y: -1);
                    break;
                case ConsoleKey.DownArrow:
                    Move(y: +1);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(x: -1);
                    break;
                case ConsoleKey.RightArrow:
                    Move(x: +1);
                    break;
                case ConsoleKey.Q:
                    hero.ActionPoints = 0;
                    playing = false;
                    break;
                case ConsoleKey.P:
                    Pickup();
                    break;
                case ConsoleKey.I:
                    Inventory();
                    break;

            }
        }

        private void Pickup()
        {
            var cell = map.Cell(hero.X, hero.Y);
            var item = cell.FirstItem;
            if (item != null)
            {
                var added = hero.Backpack.Add(item);
                if (added)
                {
                    log.Add($"You pick up the {item.Name}.");
                    cell.Items.Remove(item);
                }
                else
                {
                    log.Add("Your backpack is full!");
                }
            }
        }

        private void Inventory()
        {
            log.Add("Inventory:");
            if (hero.Backpack.Count() > 0)
            {
                foreach (var item in hero.Backpack)
                {
                    log.Add("  " + item.Name);
                }
            }
            else
            {
                log.Add("  You carry nothing.");
            }
        }

        private void Move(int x = 0, int y = 0)
        {
            var targetX = hero.X + x;
            var targetY = hero.Y + y;
            var targetCell = map.Cell(targetX, targetY);
            if (targetCell == null) return;

            var monster = targetCell.Monster;
            if (monster != null)
            {
                hero.ActionPoints = 0;
                var result = hero.Attack(monster);
                log.AddRange(result);
                return;
            }
            hero.ActionPoints -= 1;

            hero.X = targetX;
            hero.Y = targetY;

            var items = map.Cell(targetX, targetY).Items;
            if (items.Count > 0)
            {
                var itemNames = items.Select(i => i.Name);
                string contents = "You see " + string.Join(", ", itemNames);
                log.Add(contents);
            }
        }

        private void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            map.Draw();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("HP: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('♥', hero.Health).PadRight(5));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"AP: {hero.ActionPoints}");
            Console.WriteLine($"  Dmg: {hero.Damage}");
            Console.ResetColor();

            if (log.Count > 10) log.RemoveRange(0, log.Count - 10);
            foreach (var line in log) Console.WriteLine(line.PadRight(50));
        }

        private void Initialize()
        {
            map = new Map(10, 10);
            map.Hero = hero;

            map.Cell(4, 6).Monster = Monster.Troll();
            map.Cell(6, 7).Monster = Monster.Goblin();
            map.Cell(4, 9).Monster = Monster.Goblin();

            map.Cell(3, 5).Items.Add(Item.Coin());
            map.Cell(6, 7).Items.Add(Item.Coin());
            map.Cell(8, 5).Items.Add(Item.Coin());
            map.Cell(2, 9).Items.Add(Item.Sock());

            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
    }
}