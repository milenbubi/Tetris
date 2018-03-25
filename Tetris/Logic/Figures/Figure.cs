using System;
using System.Collections.Generic;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;

        public Figure(int states)
        {
            this.PositionX = FieldData.GameFieldWidth / 2;
            this.PositionY = 2;

            this.Element = new FigureElement();
            this.Element.Color = GetRandomColor();

            this.elemCoords = new int[states][];
            this.State = new Queue<int>(states);

            for (int i = 0; i < states; i++)
            {
                this.State.Enqueue(i);
            }
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Queue<int> State { get; set; }

        public FigureElement Element { get; set; }

        public void Rotate()
        {
            this.State.Enqueue(
                  this.State.Dequeue());
        }

        public int[] ElementsCoordinates()
        {
            int pos = this.State.Peek();
            return this.elemCoords[pos];
        }

        private ConsoleColor GetRandomColor()
        {
            int seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(seed);
            ConsoleColor color;

            do
            {
                color = (ConsoleColor)rand.Next(16);
            } while (color == Console.BackgroundColor);

            return color;
        }
    }
}