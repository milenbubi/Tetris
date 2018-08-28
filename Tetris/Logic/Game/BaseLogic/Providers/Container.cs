using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class Container
    {
        static Container()
        {
            Check = new Checker();
            Graphic = new GameGraphic();
        }

        internal static Checker Check { get; }

        internal static GameGraphic Graphic { get; }
    }
}
