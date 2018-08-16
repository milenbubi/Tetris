﻿namespace Tetris.Logic.Figures
{
    internal class Line : Figure, IFigure
    {
        internal Line() : base(2)
        {
            elemCoords[0] = new int[] { 0, -1, -1, -1, 1, -1 };
            elemCoords[1] = new int[] { 0, 0, 0, -1, 0, 1 };
        }
    }
}