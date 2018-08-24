using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.BaseLogic.Visualizers
{
    internal class GameGraphic
    {
        private int[] elemCoords;
        private ConsoleColor tempColorHolder;

        internal void Move(IFigure figure, sbyte x, sbyte y)
        {
            Clear(figure);
            SetNewPosition(figure, x, y);
            Draw(figure);
        }

        internal void Clear(IFigure figure)
        {
            tempColorHolder = figure.Color;

            figure.Color = FieldData.BackgroundColor;
            Draw(figure);
            figure.Color = tempColorHolder;
        }

        internal void Draw(IFigure figure)
        {
            elemCoords = figure.ElementsCoordinates;

            for (int i = 0; i < elemCoords.Length; i += 2)
            {
                Console.SetCursorPosition(figure.PositionX + elemCoords[i],
                                          figure.PositionY + elemCoords[i + 1]);

                Console.Write(figure.Element);
            }
        }

        private void SetNewPosition(IFigure figure, sbyte x, sbyte y)
        {
            figure.PositionX += x;
            figure.PositionY += y;
        }
    }
}