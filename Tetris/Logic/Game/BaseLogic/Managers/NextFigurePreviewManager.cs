using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Essential;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class NextFigurePreviewManager
    {
        private static IFigure preview;
        private static GameGraphic graphic;

        static NextFigurePreviewManager()
        {
            graphic = new GameGraphic();
        }

        internal static void Update(IFigure nextFigure, int[] positions)
        {
            ClearPreview();
            CreatePreview(nextFigure, positions);
            graphic.Draw(preview);
        }

        private static void ClearPreview()
        {
            if (preview != null)
            {
                preview.Color = Console.BackgroundColor;
                graphic.Draw(preview);
            }
        }

        private static void CreatePreview(IFigure nextFigure, int[] positions)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), true);

            preview.PositionX = positions[0];
            preview.PositionY = positions[1];
            preview.Color = nextFigure.Color;
        }
    }
}