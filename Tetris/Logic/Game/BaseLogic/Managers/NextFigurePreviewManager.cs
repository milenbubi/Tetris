using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class NextFigurePreviewManager
    {
        private static int positionX;
        private static int positionY;
        private static IFigure preview;
        private static GameGraphic graphic;

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

        internal static void SetPreviewPosition(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

        private static void ClearPreview()
        {
            if (preview != null)
            {
                preview.Element.Color = FieldData.BackgroundColor;
                graphic.Draw(preview);
            }
        }

        private static void CreatePreview(IFigure nextFigure)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), positionX, positionY);
            preview.Element.Color = nextFigure.Element.Color;
        }
    }
}