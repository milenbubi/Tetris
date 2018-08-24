using System;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Essentials
{
    internal static class InfoPanel
    {
        private static int horPosition;
        private static int lastRow;

        static InfoPanel()
        {
            horPosition = FieldData.GameFieldWidth + 3;
            lastRow = FieldData.WindowHeight;

            int x = FieldData.GameFieldWidth + FieldData.InfoPanelWidth / 2;
            int y = 6;

            NextFigurePreviewManager.SetPreviewPosition(x, y);
        }

        internal static void Update()
        {
            //Next figure preview
            CursorPosition(3);
            Console.WriteLine("Next Figure:");
            NextFigurePreviewManager.Update(GameData.nextFigure);

            //Current level
            CursorPosition(lastRow - 4);
            Console.Write("Level - ");
            Console.Write(GameData.level + " / " + GameData.LevelsCount);

            //Figure count per current level
            CursorPosition(lastRow - 7);
            Console.Write("Figure - ");
            Console.Write(GameData.figureCount + " / " + GameData.FiguresPerLevel);

            //Current points
            CursorPosition(lastRow - 10);
            Console.Write("Points - ");
            Console.Write("{0:d5}", GameData.points);
        }

        private static void CursorPosition(int vertPosition)
        {
            Console.ForegroundColor = FieldData.InfoPanelColor;
            Console.SetCursorPosition(horPosition, vertPosition);
        }
    }
}