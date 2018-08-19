using System;

namespace Tetris.Logic.Figures
{
    public class FigureElement
    {
        private const char figureSymbol = (char)3;

        internal FigureElement(ConsoleColor color) : this(color, figureSymbol)
        {
        }

        internal FigureElement(ConsoleColor color, char symbol)
        {
            Color = color;
            Symbol = symbol;
        }

        internal ConsoleColor Color { get; set; }
        internal Char Symbol { get; private set; }

        public override string ToString()
        {
            Console.ForegroundColor = Color;
            return Symbol.ToString();
        }
    }
}