using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class NextFigurePreviewManager
    {
        private static IFigure preview;
        private static GameGraphic graphic;
        private static int positionX;
        private static int positionY;

        static NextFigurePreviewManager()
        {
            graphic = new GameGraphic();
        }

        internal static void Update(IFigure nextFigure)
        {
            ClearPreview();
            CreatePreview(nextFigure);
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

        private static void CreatePreview(IFigure nextFigure)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), true);

            preview.PositionX = positionX;
            preview.PositionY = positionY;
            preview.Color = nextFigure.Color;
        }

        internal static void SetUpPreviewPosition(int[] positions)
        {
            positionX = positions[0];
            positionY = positions[1];
        }
    }
}