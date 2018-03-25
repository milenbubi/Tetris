using Tetris.Logic.Figures;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal const byte MaxLevelCount = 8;
        internal const byte FigureCountPerLevel = 6;

        internal const int StartSpeed = 265;
        internal const string logFile = "GameLog.txt";

        internal const int PointsPerLevel = 7;
        internal const int pointPerLine = 28;

        internal static byte level;
        internal static int points;
        internal static byte figureCount;

        internal static IFigure nextFigure;

        static GameData()
        {
            level = 1;
            points = 0;
            figureCount = 1;
            nextFigure = FigureFactory.GetRandomFigure();
        }
    }
}
