using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.Keys
{
    internal abstract class PressedKey : IKey
    {
        protected InfoPanel infoPanel;
        protected FieldCellsManager fieldCells;

        protected PressedKey()
        {
            this.Check = new Checker();
            this.Graphic = new GameGraphic();

            this.infoPanel = new InfoPanel();
            this.fieldCells = new FieldCellsManager();
        }

        public Checker Check { get; }
        public GameGraphic Graphic { get; }

        public abstract void Action(IFigure figure);
    }
}