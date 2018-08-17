using System;
using System.Collections.Generic;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    internal class Spacebar : PressedKey, IKey
    {
        private Queue<int> tempFigureState;

        public override void Action(IFigure figure)
        {
            tempFigureState = new Queue<int>(figure.State);
            figure.Rotate();

            try
            {
                if (Check.IsReachedBorder(figure, 0, 0))
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            finally
            {
                figure.State = tempFigureState;
            }

            Graphic.Clear(figure);
            figure.Rotate();
        }
    }
}