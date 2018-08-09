using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.Keys
{
    internal abstract class PressedKey : IKey
    {
        protected InfoPanel infoPanel;
        protected FieldCells fieldCells;
        protected string message;

        protected PressedKey()
        {
            Check = new Checker();
            Graphic = new GameGraphic();

            infoPanel = new InfoPanel();
            fieldCells = new FieldCells();
        }

        protected Checker Check { get; }
        protected GameGraphic Graphic { get; }

        public abstract void Action(IFigure figure);
    }
}