using System;
using Tetris.Logic.Game.BaseLogic.Helpers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class GameInitializeManager
    {
        private static FieldCells fieldCells;

        static GameInitializeManager()
        {
            fieldCells = new FieldCells();
        }

        internal static void SetUpWindow()
        {
            int windowWidth = FieldData.GameFieldWidth + FieldData.InfoPanelWidth;

            Console.BufferWidth = Console.WindowWidth = windowWidth;
            Console.BufferHeight = Console.WindowHeight = FieldData.WindowHeight;
            Console.Title = "TETRIS by ffilip";

            DrawGameField();
        }

        internal static void ShowWelcomeMessage()
        {
            string[] words = { "Press", "any key", "to play !!!" };
            PrintWelcomeMessage(words);

            Console.ReadKey(true);

            Console.ForegroundColor = Console.BackgroundColor;
            PrintWelcomeMessage(words);
        }

        private static void DrawGameField()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            fieldCells.DrawAllRows();
        }

        private static void PrintWelcomeMessage(string[] words)
        {
            int messageRow = FieldData.WindowHeight / 2 - 2;

            for (int i = 0; i < words.Length; i++)
            {
                int wordLength = words[i].Length;
                int messageCol = (FieldData.GameFieldWidth - wordLength) / 2;

                Console.SetCursorPosition(messageCol, messageRow++);
                Console.Write(words[i]);
            }
        }
    }
}