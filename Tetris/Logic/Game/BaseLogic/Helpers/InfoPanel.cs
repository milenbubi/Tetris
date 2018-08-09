using System;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    internal class InfoPanel
    {
        private int horPosition;
        private int vertPosition;

        internal InfoPanel()
        {
            this.horPosition = FieldData.GameFieldWidth + 4;
            this.vertPosition = FieldData.WindowHeight / 2;
            this.Preview = new NextFigurePreviewManager();
        }

        private NextFigurePreviewManager Preview { get; }

        internal void Update()
        {
            Console.ForegroundColor = FieldData.InfoPanelColor;

            //Next figure preview
            CursorPosition(-10);
            Console.WriteLine("Next Figure:");
            Preview.Update(GameData.nextFigure);

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

        private void CursorPosition(int deviation)
        {
            Console.SetCursorPosition(horPosition, vertPosition + deviation);
        }
    }
}