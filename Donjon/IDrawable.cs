using System;

namespace Donjon
{
    interface IDrawable
    {
        string Symbol { get; }
        ConsoleColor Color { get; }
    }
}