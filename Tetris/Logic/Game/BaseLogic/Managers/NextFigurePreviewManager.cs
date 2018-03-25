using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal class NextFigurePreviewManager
    {
        private int nextFigureOriginalPositionX;
        private int nextFigureOriginalPositionY;

        private int nextFigureInfoPanelPositionX;
        private int nextFigureInfoPanelPositionY;

        private IFigure previousFigure;
        private GameGraphic graphic;

        internal NextFigurePreviewManager()
        {
            int positionX = FieldData.GameFieldWidth + (FieldData.InfoPanelWidth / 2);
            this.nextFigureInfoPanelPositionX = positionX;
            this.nextFigureInfoPanelPositionY = 5;
            this.graphic = new GameGraphic();
        }

        internal void Update(IFigure nextFigure)
        {
            if (previousFigure != null)
            {
                previousFigure.Element.Color = Console.BackgroundColor;
                graphic.Draw(previousFigure);
            }

            SetPreviewCoordinatesToNextFigure(nextFigure);
            graphic.Draw(nextFigure);
            Console.ForegroundColor = ConsoleColor.White;

            CloneNextFigureAsPrevious(nextFigure);
            GivingBackOriginalCoordinatesToNextFigure(nextFigure);
        }

        private void SetPreviewCoordinatesToNextFigure(IFigure nextFigure)
        {
            nextFigureOriginalPositionX = nextFigure.PositionX;
            nextFigureOriginalPositionY = nextFigure.PositionY;

            nextFigure.PositionX = nextFigureInfoPanelPositionX;
            nextFigure.PositionY = nextFigureInfoPanelPositionY;
        }

        private void CloneNextFigureAsPrevious(IFigure nextFigure)
        {
            Type type = nextFigure.GetType();
            previousFigure = (IFigure)Activator.CreateInstance(type);

            previousFigure.PositionX = nextFigureInfoPanelPositionX;
            previousFigure.PositionY = nextFigureInfoPanelPositionY;
        }

        private void GivingBackOriginalCoordinatesToNextFigure(IFigure nextFigure)
        {
            nextFigure.PositionX = nextFigureOriginalPositionX;
            nextFigure.PositionY = nextFigureOriginalPositionY;
        }
    }
}
