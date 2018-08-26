using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal static int LevelsCount = 5;
        internal static int FiguresPerLevel = 3;

        internal static int PointPerLine = 28;
        internal static int PointsPerLevel = 7;

        internal static int StartSpeed = 355;
        internal static string LogFile = "GameLog.ini";

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