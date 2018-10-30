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

        internal const ConsoleColor MessageColor = ConsoleColor.Yellow;
        internal const ConsoleColor ObstacleColor = ConsoleColor.Yellow;
        internal const ConsoleColor InfoPanelColor = ConsoleColor.White;
        internal const ConsoleColor BackgroundColor = ConsoleColor.Black;
        internal const ConsoleColor BorderSymbolColor = ConsoleColor.White;

        internal static char BorderSymbol = '*';
    }
}