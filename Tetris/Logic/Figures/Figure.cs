using System;
using System.Collections.Generic;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;
        private int positionY = 2;
        private int positionX = FieldData.GameFieldWidth / 2;

        public Figure(int states)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;

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
            int position = this.State.Peek();
            return this.elemCoords[position];
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