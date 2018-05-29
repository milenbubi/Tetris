using System;

namespace Tetris.Logic.Figures
{
    public class FigureElement
    {
        private const char figureSymbol = (char)3;

        public FigureElement()
        {
            this.Symbol = figureSymbol;
        }

        public FigureElement(ConsoleColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        public ConsoleColor Color { get; set; }
        public Char Symbol { get; private set; }

        public override string ToString()
        {
            Console.ForegroundColor = this.Color;
            return this.Symbol.ToString();
        }
    }
}