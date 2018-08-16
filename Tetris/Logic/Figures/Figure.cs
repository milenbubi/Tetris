using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;
        private const int positionY = 2;
        private const int positionX = FieldData.GameFieldWidth / 2;

        internal Figure(int states)
        {
            PositionX = positionX;
            PositionY = positionY;

            Element = new FigureElement();
            Element.Color = GetRandomColor();

            elemCoords = new int[states][];

            State = new Queue<int>(Enumerable.Range(0, states));
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Queue<int> State { get; set; }

        public FigureElement Element { get; set; }

        public void Rotate()
        {
            State.Enqueue(State.Dequeue());
        }

        public int[] ElementsCoordinates()
        {
            int position = State.Peek();
            return elemCoords[position];
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