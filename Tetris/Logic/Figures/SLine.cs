﻿namespace Tetris.Logic.Figures
{
    public class SLine : Figure, IFigure
    {
        public SLine(int x, int y) : base(2, x, y)
        {
            elemCoords[0] = new[] { 0, 0, 0, -1, 1, -1, -1, 0 };
            elemCoords[1] = new[] { 0, 0, 0, -1, 1, 0, 1, 1 };
        }
    }
}