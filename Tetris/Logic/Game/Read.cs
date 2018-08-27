using System;

namespace Tetris.Logic.Game
{
    internal static class Read
    {
        internal static string Key => Console.ReadKey(true).Key.ToString();
    }
}