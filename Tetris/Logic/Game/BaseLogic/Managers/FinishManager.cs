using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class FinishManager
    {
        internal static void EndOfGame()
        {
            Console.BufferHeight = 45;
            Console.BufferWidth = 150;
            Console.WindowHeight = 23;
            Console.WindowWidth = 75;

            Console.Clear();
            Console.CursorVisible = true;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            ScoreManager.UpdateScores();
            ScoreManager.DisplayScores();

            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}