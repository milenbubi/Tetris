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
            this.Check = new Checker();
            this.Graphic = new GameGraphic();

            this.infoPanel = new InfoPanel();
            this.fieldCells = new FieldCells();
        }

        public Checker Check { get; }
        public GameGraphic Graphic { get; }

        public abstract void Action(IFigure figure);
    }
}