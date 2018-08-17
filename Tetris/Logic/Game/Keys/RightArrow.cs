using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.Keys
{
    internal class RightArrow : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            if (Check.IsReachedBorder(figure, 1, 0))
            {
                return;
            }

            Graphic.Move(figure, 1, 0);
        }
    }
}