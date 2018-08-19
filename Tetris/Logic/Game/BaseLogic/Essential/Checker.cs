﻿using Tetris.Logic.Figures;
using System.Linq;

namespace Tetris.Logic.Game.BaseLogic.Essential
{
    internal class Checker
    {
        private FieldCells fieldCells;
        private int[] elementsCoordinates;

        internal Checker()
        {
            fieldCells = new FieldCells();
        }

        internal bool IsFinished(IFigure figure)
        {
            int x;
            int y;
            elementsCoordinates = figure.ElementsCoordinates;

            if (IsReachedBorder(figure, 0, 1))
            {
                for (int j = 0; j < elementsCoordinates.Length; j += 2)
                {
                    x = figure.PositionX + elementsCoordinates[j];
                    y = figure.PositionY + elementsCoordinates[j + 1];

                    fieldCells[y][x] = figure.Element;
                }

                CheckForReadyLine(figure);
                return true;
            }
            return false;
        }

        internal bool IsReachedBorder(IFigure figure, sbyte xValue = 0, sbyte yValue = 0)
        {
            int x = figure.PositionX + xValue;
            int y = figure.PositionY + yValue;
            elementsCoordinates = figure.ElementsCoordinates;

            for (int i = 0; i < elementsCoordinates.Length; i += 2)
            {
                if (fieldCells
                   [y + elementsCoordinates[i + 1]]
                   [x + elementsCoordinates[i]]
                   .Symbol != ' ')
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckForReadyLine(IFigure figure)
        {
            //That row says the maximum size of figure must be 3(Three) cells, no more. I decided so!
            int approximateRow = figure.PositionY + 1;

            while (approximateRow >= (figure.PositionY - 1))
            {
                //Checks if approximate row is out of range
                if (approximateRow > (fieldCells.Count - 2) || approximateRow <= 1)
                {
                    approximateRow -= 1;
                    continue;
                }

                //Checks if approximate row is ready
                if (fieldCells[approximateRow].All(e => e.Symbol != ' '))
                {
                    fieldCells.ReDrawFieldOnReadyLine(approximateRow);
                    GameData.points += GameData.PointPerLine;
                    continue;
                }

                approximateRow -= 1;
            }
        }
    }
}