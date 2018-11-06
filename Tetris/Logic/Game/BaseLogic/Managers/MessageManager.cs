using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class MessageManager
    {
        internal static void PrintOnWholeWindow(string[] message)
        {
            Console.Clear();
            SetMessageStyle(message.Length, true);
            Print(FieldData.WindowWidth, message);
        }

        internal static void PrintInGameField(string[] message, bool showMessage)
        {
            SetMessageStyle(message.Length, showMessage);
            Print(FieldData.GameFieldWidth, message);
        }

        private static void SetMessageStyle(int messageLength, bool showMessage)
        {
            Console.ForegroundColor = showMessage ? FieldData.MessageColor : FieldData.BackgroundColor;
            Console.CursorTop = (FieldData.WindowHeight - messageLength) / 2;
        }

        private static void Print(int printWidth, string[] message)
        {
            foreach (string line in message)
            {
                Console.CursorLeft = (printWidth - line.Length) / 2;
                Console.WriteLine(line);
            }
        }
    }
}