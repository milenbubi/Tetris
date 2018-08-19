using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class GameInitializeManager
    {
        private static string[] welcomeMessage;

        static GameInitializeManager()
        {
            welcomeMessage = new string[]
            {
                "Press \"M\"",
                "for Main Menu",
                 new string('\n',2),
                "or",
                "any key",
                "to play !!!"
            };
        }

        internal static void SetUpWindow()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = FieldData.BackgroundColor;

            Console.Clear();
            Console.Title = "TETRIS by ffilip";

            Console.BufferWidth = Console.WindowWidth = FieldData.WindowWidth;
            Console.BufferHeight = Console.WindowHeight = FieldData.WindowHeight;
        }

        internal static void ShowWelcomeMessage(bool showMessage = true)
        {
            Console.ForegroundColor = FieldData.MessageColor;

            if (!showMessage)
            {
                Console.ForegroundColor = Console.BackgroundColor;
            }

            PrintMessage(welcomeMessage);
        }

        private static void PrintMessage(string[] welcome)
        {
            int messageRow = (FieldData.WindowHeight - welcome.Length) / 2;

            foreach (var text in welcome)
            {
                int messageCol = (FieldData.GameFieldWidth - text.Length) / 2;

                Console.SetCursorPosition(messageCol, messageRow++);
                Console.Write(text);
            }
        }
    }
}