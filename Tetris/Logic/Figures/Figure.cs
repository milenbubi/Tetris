using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Providers;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;

        internal Figure(int states, int[] coords)
        {
            PositionX = coords[0];
            PositionY = coords[1];

            Element = new FigureElement(RandomColor());

            elemCoords = new int[states][];

            State = new Queue<int>(Enumerable.Range(0, states));
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Queue<int> State { get; set; }

        public FigureElement Element { get; set; }

        public int[] ElementsCoordinates => elemCoords[State.Peek()];

        public ConsoleColor Color { get => Element.Color; set => Element.Color = value; }

        public void Rotate() => State.Enqueue(State.Dequeue());

        private ConsoleColor RandomColor()
        {
            ConsoleColor color;

            do
            {
                color = (ConsoleColor)RandomNumber.InRangeZeroTo(16);
            } while (color == Console.BackgroundColor);

            return color;
        }
    }
}