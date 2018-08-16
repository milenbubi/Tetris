using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal class NextFigurePreviewManager
    {
        private int nextFigureOriginalPositionX;
        private int nextFigureOriginalPositionY;

        private readonly int nextFigureInfoPanelPositionX;
        private readonly int nextFigureInfoPanelPositionY;

        private IFigure previousFigure;
        private GameGraphic graphic;

        internal NextFigurePreviewManager()
        {
            nextFigureInfoPanelPositionX = FieldData.GameFieldWidth + (FieldData.InfoPanelWidth / 2);
            nextFigureInfoPanelPositionY = 6;
            graphic = new GameGraphic();
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
            previousFigure = (IFigure)Activator.CreateInstance(nextFigure.GetType(), true);

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
