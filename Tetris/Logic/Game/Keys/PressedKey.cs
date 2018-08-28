using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.Keys
{
    internal abstract class PressedKey : IKey
    {
        internal static Checker Check => Container.Check;

        internal static GameGraphic Graphic => Container.Graphic;

        public abstract void Action(IFigure figure);
    }
}