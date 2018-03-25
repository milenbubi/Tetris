using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.Keys
{
    class F : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Are you sure? Exit?  Y/N");
            string decision = Console.ReadKey(true).Key.ToString();

            if (decision.ToLower() == "y")
            {
                FinishManager.EndOfGame();
            }
            else
            {
                Console.Clear();
                infoPanel.Update();
                fieldCells.DrawAllRows();
            }
        }
    }
}
