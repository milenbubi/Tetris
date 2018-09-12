using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal const int LevelsCount = 7;
        internal const int FiguresPerLevel = 56;

        internal const int PointPerLine = 28;
        internal const int PointsPerLevel = 7;

        internal const int StartSpeed = 355;
        internal const string LogFile = "GameLog.ini";

        internal static int speed;
        internal static int points;
        internal static int level;
        internal static int figureCount;

        internal static Status status;
        internal static IFigure nextFigure;

        internal static void ResetData()
        {
            level = 1;
            points = 0;
            figureCount = 1;
            speed = StartSpeed;

            status = Status.Play;
            nextFigure = NewFigure();
        }

        internal static IFigure NewFigure()
        {
            return FigureFactory.GetRandomFigure(FieldData.GameFieldWidth / 2, 2);
        }
    }
}