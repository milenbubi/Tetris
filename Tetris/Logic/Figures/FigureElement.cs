using System;

namespace Tetris.Logic.Figures
{
    public class FigureElement
    {
        private char symbol=(char)3;

        public FigureElement()
        {
            this.Symbol = symbol;
        }

        public FigureElement(ConsoleColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        public ConsoleColor Color { get; set; }
        public Char Symbol { get; set; }

        public override string ToString()
        {
            Console.ForegroundColor = this.Color;
            return this.Symbol.ToString();
        }
    }

}
