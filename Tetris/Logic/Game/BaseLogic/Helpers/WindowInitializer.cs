using System;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    internal class WindowInitializer
    {
        private FieldCellsManager fieldCells;

        internal WindowInitializer()
        {
            this.fieldCells = new FieldCellsManager();
        }

        internal void SetUpWindow()
        {
            int windowWidth = FieldData.GameFieldWidth + FieldData.InfoPanelWidth;

            Console.BufferWidth = Console.WindowWidth = windowWidth;
            Console.BufferHeight = Console.WindowHeight = FieldData.WindowHeight;
            Console.Title = "TETRIS by ffilip";

            DrawGameField();
        }

        internal void ShowWelcomeMessage()
        {
            string[] words = { "Press", "any key", "to play !!!" };
            PrintWelcomeMessage(words);

            Console.ReadKey(true);

            Console.ForegroundColor = Console.BackgroundColor;
            PrintWelcomeMessage(words);
        }

        private void DrawGameField()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            fieldCells.DrawAllRows();
        }

        private void PrintWelcomeMessage(string[] words)
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