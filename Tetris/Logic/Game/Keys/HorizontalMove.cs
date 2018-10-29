using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    internal abstract class HorizontalMove : PressedKey, IKey
    {
        protected sbyte xValue;

        public override void Action(IFigure figure)
        {
            if (!Check.IsReachedBorder(figure, xValue, 0))
            {
                Graphic.Move(figure, xValue, 0);
            }
        }
    }
}