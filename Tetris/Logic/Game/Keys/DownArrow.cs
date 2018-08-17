using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.Keys
{
    internal class DownArrow : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            while (!Check.IsReachedBorder(figure, 0, 1))
            {
                Graphic.Move(figure, 0, 1);
            }
        }
    }
}
