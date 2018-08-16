using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    class NextFigurePreviewManager
    {
        private readonly int previewPositionX;
        private readonly int previewPositionY;

        private IFigure preview;
        private GameGraphic graphic;

        internal NextFigurePreviewManager()
        {
            previewPositionX = FieldData.GameFieldWidth + (FieldData.InfoPanelWidth / 2);
            previewPositionY = 6;
            graphic = new GameGraphic();
        }

        internal void Update(IFigure nextFigure)
        {
            ClearPreview();
            CreatePreview(nextFigure);
            graphic.Draw(preview);

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ClearPreview()
        {
            if (preview != null)
            {
                preview.Element.Color = Console.BackgroundColor;
                graphic.Draw(preview);
            }
        }

        private void CreatePreview(IFigure nextFigure)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), true);

            preview.PositionX = previewPositionX;
            preview.PositionY = previewPositionY;
            preview.Element.Color = nextFigure.Element.Color;
        }
    }
}