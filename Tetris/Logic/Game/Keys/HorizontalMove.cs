using Tetris.Logic.Figures;
using System.Threading.Tasks;

namespace Tetris.Logic.Game.Keys
{
    internal abstract class HorizontalMove : PressedKey, IKey
    {
        protected sbyte xValue;

        public override void Action(IFigure figure)
        {
            if (!Check.IsReachedBorder(figure, xValue, 0))
            {
                //Smoothing the left/right moving
                Task.Delay(12).Wait();

                Graphic.Move(figure, xValue, 0);
            }
        }
    }
}