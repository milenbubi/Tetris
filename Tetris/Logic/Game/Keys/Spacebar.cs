using Tetris.Logic.Figures;
using System.Collections.Generic;

namespace Tetris.Logic.Game.Keys
{
    internal class Spacebar : PressedKey, IKey
    {
        private Queue<int> tempFigureState;

        public override void Action(IFigure figure)
        {
            tempFigureState = new Queue<int>(figure.State);
            figure.Rotate();

            bool reachedBorder = Check.IsReachedBorder(figure, 0, 0);
            figure.State = tempFigureState;

            if (!reachedBorder)
            {
                Graphic.Clear(figure);
                figure.Rotate();
            }
        }
    }
}