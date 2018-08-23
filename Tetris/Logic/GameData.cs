using Tetris.Logic.Figures;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal static byte LevelsCount = 6;
        internal static byte FiguresPerLevel = 1;

        internal static int PointPerLine = 28;
        internal static int PointsPerLevel = 7;

        internal static int StartSpeed = 355;
        internal static string LogFile = "GameLog.ini";

        internal static int points;
        internal static byte level;
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