using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    class S : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            //Escape method on long pressed button
            if (GameData.status==Status.Skip)
            {
                return;
            }

            figure.Element.Color = Console.BackgroundColor;
            Graphic.Clear(figure);

            GameData.status=Status.Skip;

            GameData.points--;
            GameData.figureCount--;
        }
    }
}