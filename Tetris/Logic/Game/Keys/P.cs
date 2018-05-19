using System;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.Keys
{
    internal class P : PressedKey, IKey
    {
        string resumeGame = "Resume game  -  press any key\n";
        string cancelGame = "Cancel game  -  press C\n";

        public override void Action(IFigure figure)
        {
            ShowPauseWindow();

            string decision = Console.ReadKey(true).Key.ToString();

            if (decision.ToLower() == "c")
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

            Console.WriteLine("Your score: {0}\n", GameData.points);

            ScoreManager.DisplayScores();

            message = string.Format("\n{0}{1}", resumeGame, cancelGame);
            Console.WriteLine(message);
        }
    }
}