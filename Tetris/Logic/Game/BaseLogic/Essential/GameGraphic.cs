using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.BaseLogic.Essential
{
    internal class GameGraphic
    {
        private int[] elemCoords;
        private ConsoleColor tempColorHolder;

        internal void Move(IFigure figure, sbyte xValue, sbyte yValue)
        {
            Clear(figure);
            SetNewPosition(figure, xValue, yValue);
            Draw(figure);
        }

        internal void Clear(IFigure figure)
        {
            tempColorHolder = figure.Element.Color;

            figure.Element.Color = Console.BackgroundColor;
            Draw(figure);
            figure.Element.Color = tempColorHolder;
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

        private void SetNewPosition(IFigure figure, sbyte xValue, sbyte yValue)
        {
            figure.PositionX += xValue;
            figure.PositionY += yValue;
        }
    }
}