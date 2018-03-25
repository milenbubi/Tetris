using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    class S : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            try
            {
                figure.Element.Color = Console.BackgroundColor;
                Graphic.Clear(figure);
            }
            catch (NullReferenceException)
            {
                return;
            }

            figure.Element = null;

            GameData.points--;
            GameData.figureCount--;
        }
    }
}