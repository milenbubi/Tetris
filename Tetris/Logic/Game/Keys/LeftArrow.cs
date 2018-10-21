using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    internal class LeftArrow : HorizontalMove, IKey
    {
        public override void Action(IFigure figure)
        {
            xValue = -1;
            base.Action(figure);
        }
    }
}