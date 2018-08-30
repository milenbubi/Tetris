using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Providers;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;

        internal Figure(int states, int x, int y)
        {
            PositionX = x;
            PositionY = y;

            Element = new FigureElement(RandomColor());

            elemCoords = new int[states][];

            State = new Queue<int>(Enumerable.Range(0, states));
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Queue<int> State { get; set; }

        public FigureElement Element { get; set; }

        public int[] ElementsCoordinates => elemCoords[State.Peek()];

        public void Rotate() => State.Enqueue(State.Dequeue());

        private ConsoleColor RandomColor()
        {
            ConsoleColor color;

            do
            {
                color = (ConsoleColor)RandomNumber.ZeroBasedRange(16);
            } while (color == FieldData.BackgroundColor);

            return color;
        }
    }
}