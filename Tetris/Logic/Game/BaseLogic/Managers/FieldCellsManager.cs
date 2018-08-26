﻿using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class FieldCellsManager
    {
        private static FigureElement obstacle;

        static FieldCellsManager()
        {
            obstacle = new FigureElement(FieldData.ObstacleColor);
        }

        internal static void AddFigure(FieldCells fieldCells, IFigure figure)
        {
            int x;
            int y;
            int[] elemCoords = figure.ElementsCoordinates;

            for (int j = 0; j < elemCoords.Length; j += 2)
            {
                x = figure.PositionX + elemCoords[j];
                y = figure.PositionY + elemCoords[j + 1];

                fieldCells[y][x] = figure.Element;
            }
        }

        internal static void AddNewObstacle(FieldCells fieldCells)
        {
            int middle = FieldData.GameFieldHeight / 2;
            int bottom = FieldData.GameFieldHeight - 3;
            int lastColumn = FieldData.GameFieldWidth - 3;


            //TODO  waiting for new method in Random Provider
            Random random = new Random((int)DateTime.Now.Ticks);

            int x = random.Next(2, lastColumn);
            int y = random.Next(middle + 1, bottom);

            fieldCells[y][x] = obstacle;
        }
    }
}
