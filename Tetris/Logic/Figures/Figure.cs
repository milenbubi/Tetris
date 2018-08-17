﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Figures
{
    public abstract class Figure : IFigure
    {
        protected int[][] elemCoords;

        internal Figure(int states)
        {
            PositionX = FieldData.GameFieldWidth / 2;
            PositionY = 2;

            Element = new FigureElement() { Color = GetRandomColor() };

            elemCoords = new int[states][];

            State = new Queue<int>(Enumerable.Range(0, states));
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Queue<int> State { get; set; }

        public FigureElement Element { get; set; }

        public int[] ElementsCoordinates => elemCoords[State.Peek()];

        public ConsoleColor Color { get => Element.Color; set => Element.Color = value; }

        public void Rotate()
        {
            State.Enqueue(State.Dequeue());
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