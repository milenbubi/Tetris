using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.Keys
{
    internal class M : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            Menu.Show();
        }
    }
}