using Tetris.Logic.Game.BaseLogic.Essentials;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class Container
    {
        static Container()
        {
            Checker = new Checker();
            GameGraphic = new GameGraphic();
        }

        internal static Checker Checker { get; }

        internal static GameGraphic GameGraphic { get; }
    }
}
