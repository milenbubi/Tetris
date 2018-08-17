using System;
using System.Collections.Generic;

namespace Tetris.Logic.Figures
{
    public interface IFigure
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        Queue<int> State { get; set; }
        FigureElement Element { get; set; }
        ConsoleColor Color { get; set; }

        int[] ElementsCoordinates { get; }
        void Rotate();
    }
}
