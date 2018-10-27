using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class FinishManager
    {
        internal static void EndOfGame()
        {
            Console.SetWindowSize(91, 28);
            Console.SetBufferSize(300, 200);

            Console.Clear();
            Console.ResetColor();
            Console.CursorVisible = true;

            ScoreManager.DisplayScores();
            Environment.Exit(0);
        }
    }
}