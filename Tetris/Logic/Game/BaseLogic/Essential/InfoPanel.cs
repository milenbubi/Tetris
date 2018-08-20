using System;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Essential
{
    internal static class InfoPanel
    {
        private static int horPosition;
        private static int vertPosition;
        private static int[] positions;

        static InfoPanel()
        {
            horPosition = FieldData.GameFieldWidth + 4;
            vertPosition = FieldData.WindowHeight / 2;

            positions = new int[]
            {
                FieldData.GameFieldWidth + FieldData.InfoPanelWidth / 2,
                vertPosition - 7
            };
        }

        internal static void Update()
        {
            Console.ForegroundColor = FieldData.InfoPanelColor;

            //Next figure preview
            CursorPosition(-10);
            Console.WriteLine("Next Figure:");
            NextFigurePreviewManager.Update(GameData.nextFigure, positions);
            Console.ForegroundColor = FieldData.InfoPanelColor;

            //Current level
            CursorPosition(3);
            Console.Write("Level - ");
            Console.WriteLine(GameData.level + " / " + GameData.LevelsCount);

            //Figure count per current level
            CursorPosition(6);
            Console.Write("Figure - ");
            Console.WriteLine(GameData.figureCount + " / " + GameData.FiguresPerLevel);

            //Current points
            CursorPosition(9);
            Console.Write("Points - ");
            Console.WriteLine("{0:d5}", GameData.points);
        }

        private static void CursorPosition(int deviation)
        {
            Console.SetCursorPosition(horPosition, vertPosition + deviation);
        }
    }
}