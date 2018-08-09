using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.Keys
{
    public interface IKey
    {
        void Action(IFigure figure);
    }
}