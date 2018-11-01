using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class MessageManager
    {
        internal static void PrintOnWholeWindow(params string[] message)
        {
            Console.Clear();
            SetConsoleProperties(message.Length);
            Print(FieldData.WindowWidth, message);
        }

        internal static void PrintInGameField(string[] message, bool showMessage)
        {
            SetConsoleProperties(message.Length, showMessage);
            Print(FieldData.GameFieldWidth, message);
        }

        private static void SetConsoleProperties(int messageLength, bool showMessage = true)
        {
            Console.ForegroundColor = showMessage ? FieldData.MessageColor : FieldData.BackgroundColor;
            Console.CursorTop = (FieldData.WindowHeight - messageLength) / 2;
        }

        private static void Print(int width, params string[] message)
        {
            foreach (string line in message)
            {
                Console.CursorLeft = (width - line.Length) / 2;
                Console.WriteLine(line);
            }
        }
    }
}