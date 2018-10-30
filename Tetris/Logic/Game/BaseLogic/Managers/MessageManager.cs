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

        internal static void PrintInGameField(string[] message, ConsoleColor color)
        {
            SetConsoleProperties(message.Length, color);
            Print(FieldData.GameFieldWidth, message);
        }

        private static void SetConsoleProperties(int messageLength, ConsoleColor color = FieldData.MessageColor)
        {
            Console.ForegroundColor = color;
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