using System;

namespace Tetris.Logic.Figures
{
    public class FigureElement
    {
        private const char figureSymbol = (char)3;

        internal FigureElement()
        {
            this.Symbol = figureSymbol;
        }

        internal FigureElement(ConsoleColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        internal ConsoleColor Color { get; set; }
        internal Char Symbol { get; private set; }

        public override string ToString()
        {
            Console.ForegroundColor = this.Color;
            return this.Symbol.ToString();
        }
    }
}