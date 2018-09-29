using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class GameInitializeManager
    {
        private static string[] welcomeMessage;

        static GameInitializeManager()
        {
            welcomeMessage = new[]
            {
                "Press 'M'",
                "for Main Menu",
                string.Empty,
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
            Console.CursorTop = (FieldData.WindowHeight - welcomeMessage.Length) / 2;

            if (!showMessage)
            {
                Console.ForegroundColor = FieldData.BackgroundColor;
            }

            foreach (var text in welcomeMessage)
            {
                Console.CursorLeft = (FieldData.GameFieldWidth - text.Length) / 2;
                Console.WriteLine(text);
            }
        }
    }
}