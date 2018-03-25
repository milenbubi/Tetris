using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    public class GameGraphic
    {
        private ConsoleColor tempColorHolder;
        private int[] elemCoords;

        public void Move(IFigure figure, sbyte xValue, sbyte yValue)
        {
            Clear(figure);
            SetNewPosition(figure, xValue, yValue);
            Draw(figure);
        }

        public void Clear(IFigure figure)
        {
            this.tempColorHolder = figure.Element.Color;

            figure.Element.Color = Console.BackgroundColor;
            Draw(figure);

            figure.Element.Color = tempColorHolder;
        }

        public void Draw(IFigure figure)
        {
            this.elemCoords = figure.ElementsCoordinates();

            for (int i = 0; i < elemCoords.Length; i += 2)
            {
                Console.SetCursorPosition(figure.PositionX + elemCoords[i]
                                        , figure.PositionY + elemCoords[i + 1]);
                Console.WriteLine(figure.Element);
            }
        }

        private void SetNewPosition(IFigure figure, sbyte xValue, sbyte yValue)
        {
            figure.PositionX += xValue;
            figure.PositionY += yValue;
        }
    }
}