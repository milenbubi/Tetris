using System;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    class S : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            //Exit from method if button "S" is long pressed
            if (GameData.status == Status.Skip)
            {
                return;
            }

            figure.Element.Color = Console.BackgroundColor;
            Graphic.Clear(figure);

            GameData.status = Status.Skip;
        }
    }
}