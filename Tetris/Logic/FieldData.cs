using System;

namespace Tetris.Logic
{
    internal struct FieldData
    {
        internal const int InfoPanelWidth = 21;
        internal const int GameFieldWidth = 17;
        internal const int WindowWidth = InfoPanelWidth + GameFieldWidth;

        internal const int WindowHeight = 26;
        internal const int GameFieldHeight = WindowHeight - 1;

        internal static char BorderSymbol = '*';

        internal static ConsoleColor MessageColor = ConsoleColor.Yellow;
        internal static ConsoleColor ObstacleColor = ConsoleColor.Yellow;
        internal static ConsoleColor InfoPanelColor = ConsoleColor.White;
        internal static ConsoleColor BackgroundColor = ConsoleColor.Black;
        internal static ConsoleColor BorderSymbolColor = ConsoleColor.White;
    }
}