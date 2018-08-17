using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    internal class S : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            //Exit from this method if button "S" is long pressed
            if (GameData.status == Status.Skip)
            {
                return;
            }

            figure.Color = Console.BackgroundColor;
            Graphic.Clear(figure);

            GameData.status = Status.Skip;

            GameData.figureCount--;
            GameData.points--;
        }
    }
}