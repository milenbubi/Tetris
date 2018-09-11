using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class NextFigurePreviewManager
    {
        private static int positionX;
        private static int positionY;
        private static IFigure preview;

        internal static GameGraphic Graphic => Container.Graphic;

        internal static void Update(IFigure nextFigure)
        {
            ClearPreview();
            CreatePreview(nextFigure);
            Graphic.Draw(preview);
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
                Graphic.Clear(preview);
            }
        }

        private static void CreatePreview(IFigure nextFigure)
        {
            preview = (IFigure)Activator.CreateInstance(nextFigure.GetType(), positionX, positionY);
            preview.Element.Color = nextFigure.Element.Color;
        }
    }
}