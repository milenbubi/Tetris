using System;

namespace Tetris.Logic
{
    internal struct FieldData
    {
        internal const int InfoPanelWidth = 21;
        internal const int GameFieldWidth = 17;

        internal const int WindowWidth = InfoPanelWidth + GameFieldWidth;

        internal const int WindowHeight = 26;
        internal const int GameFieldHeight = 25;

        internal const char BorderSymbol = '*';
        internal const ConsoleColor BorderSymbolColor = ConsoleColor.White;

        internal const ConsoleColor MessageColor = ConsoleColor.Yellow;
        internal const ConsoleColor InfoPanelColor = ConsoleColor.White;
        internal const ConsoleColor BackgroundColor = ConsoleColor.Black;
    }
}