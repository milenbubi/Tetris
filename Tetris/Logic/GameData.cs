using System.Timers;
using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;

namespace Tetris.Logic
{
    internal struct GameData
    {
        internal const int LevelsCount = 8;
        internal const int FiguresPerLevel = 56;

        internal const int PointPerLine = 28;
        internal const int PointsPerLevel = 7;

        internal const int StartSpeed = 450;
        internal const string LogFile = "GameLog.ini";

        internal static int speed;
        internal static int points;
        internal static int level;
        internal static int figureCount;

        internal static Status status;
        internal static IFigure nextFigure;
        internal static Timer speedDelay;

        internal static void ResetData()
        {
            level = 1;
            points = 0;
            figureCount = 1;
            speed = StartSpeed;

            status = Status.Play;
            nextFigure = NewFigure();
            speedDelay = new Timer();
            speedDelay.AutoReset = false;
        }

        internal static IFigure NewFigure()
        {
            return FigureFactory.GetRandomFigure(FieldData.GameFieldWidth / 2, 2);
        }
    }
}