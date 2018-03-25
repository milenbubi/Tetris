using Tetris.Logic.Figures;

namespace Tetris.Logic.Game
{
    public interface IKeyController
    {
        void Action( IFigure figure, string keyClassName);
    }
}