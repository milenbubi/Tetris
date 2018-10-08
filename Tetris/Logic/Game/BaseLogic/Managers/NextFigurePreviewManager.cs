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

        internal static GameGraphic Graphic => Container.GameGraphic;

        internal static void Update()
        {
            ClearPreview();
            CreatePreview();
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

        private static void CreatePreview()
        {
            preview = (IFigure)Activator.CreateInstance(GameData.nextFigure.GetType(), positionX, positionY);
            preview.Element.Color = GameData.nextFigure.Element.Color;
        }
    }
}