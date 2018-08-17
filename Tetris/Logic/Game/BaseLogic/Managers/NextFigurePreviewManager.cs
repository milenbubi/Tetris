using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Essential;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class NextFigurePreviewManager
    {
        private static readonly int previewPositionX;
        private static readonly int previewPositionY;

        private static IFigure preview;
        private static GameGraphic graphic;

        static NextFigurePreviewManager()
        {
            previewPositionX = FieldData.GameFieldWidth + (FieldData.InfoPanelWidth / 2);
            previewPositionY = 6;
            graphic = new GameGraphic();
        }

        internal static void Update(IFigure nextFigure)
        {
            ClearPreview();
            CreatePreview(nextFigure);
            graphic.Draw(preview);

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ClearPreview()
        {
            if (preview != null)
            {
                preview.Color = Console.BackgroundColor;
                graphic.Draw(preview);
            }
        }

        private static void CreatePreview(IFigure nextFigure)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), true);

            preview.PositionX = previewPositionX;
            preview.PositionY = previewPositionY;
            preview.Color = nextFigure.Color;
        }
    }
}