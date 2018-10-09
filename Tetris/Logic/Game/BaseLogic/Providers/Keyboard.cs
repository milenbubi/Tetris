using System;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class Keyboard
    {
        internal static bool KeyIsPressed => Console.KeyAvailable;

        internal static void PressAnyKey() => Console.ReadKey(true);

        internal static string ReadKey() => Console.ReadKey(true).Key.ToString();
    }
}