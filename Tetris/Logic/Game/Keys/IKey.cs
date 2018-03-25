using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.Keys
{
    public interface IKey
    {
        Checker Check { get; }
        GameGraphic Graphic { get; }
        void Action(IFigure figure);
    }
}