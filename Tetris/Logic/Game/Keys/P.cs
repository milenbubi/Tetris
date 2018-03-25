using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.Keys
{
    class P : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            ShowSomeInfoAboutGame();
            ScoreManager.DisplayScores();
            Console.ReadKey(true);

            Console.Clear();
            infoPanel.Update();
            fieldCells.DrawAllRows();

            //TODO да показва нек'ви опции за резултати, класиране, да пита искаш ли рестарт или край и т.н. ...
        }

        private void ShowSomeInfoAboutGame()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Your score: {0}", GameData.pointPerLine);
            Console.WriteLine();
          //  Console.ForegroundColor = ConsoleColor.White;
        }
    }
}