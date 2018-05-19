using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.Keys
{
    class F : PressedKey, IKey
    {
        public override void Action(IFigure figure)
        {
            ShowPauseWindow();

            string decision = Console.ReadKey(true).Key.ToString();

            if (decision.ToLower() == "y")
            {
                FinishManager.EndOfGame();
            }

            else
            {
                BackToGame();
            }
        }

        protected override void ShowPauseWindow()
        {
            base.ShowPauseWindow();

            message = "Are you sure? Exit?  Y/N";
            Console.WriteLine(message);
        }
    }
}