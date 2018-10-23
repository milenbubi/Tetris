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

        internal static void NewGameNotice(int seconds)
        {
            string newGameMessage = "New game after {0} seconds";

            Print(new string[] { String.Format(newGameMessage, seconds) });
        }

        internal static void GameOverNotice()
        {
            string[] finishMessage = new string[]
                 {
                "GAME OVER\n",
                "Press 'Q' to quit game",
                "or press any key to play new game"
                 };

            Print(finishMessage);

        }

        internal static void WinnerNotice()
        {
            string[] winMessage = new string[]
            {
                "  CONGRATULATION !!!\n",

                "YOU WIN THE GAME !!!",
                Environment.NewLine,
                Environment.NewLine,
                "  press any key to play new game\n",
                "or 'Q' to quit game"
            };

            Print(winMessage);
        }

        private static void Print(string[] message)
        {
            Console.CursorTop = (FieldData.WindowHeight - message.Length) / 2;

            foreach (var line in message)
            {
                Console.CursorLeft = (FieldData.WindowWidth - line.Length) / 2;
                Console.WriteLine(line);
            }
        }
    }
}