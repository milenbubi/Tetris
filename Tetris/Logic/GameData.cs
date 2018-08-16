using Tetris.Logic.Figures;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal const byte LevelsCount = 8;
        internal const byte FiguresPerLevel = 6;

        internal const int PointsPerLevel = 7;
        internal const int PointPerLine = 28;

        internal const int StartSpeed = 355;
        internal const string LogFile = "GameLog.ini";

        internal static byte level;
        internal static int points;
        internal static byte figureCount;

        internal static Status status;
        internal static IFigure nextFigure;

        internal static void ResetData()
        {
            level = 1;
            points = 0;
            figureCount = 1;

            status = Status.Play;
            nextFigure = FigureFactory.GetRandomFigure();
        }
    }
}