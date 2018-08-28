using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Providers;
using Tetris.Logic.Game.BaseLogic.Visualizers;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class FieldCellsManager
    {
        private static FigureElement obstacle;

        static FieldCellsManager()
        {
            obstacle = new FigureElement(FieldData.ObstacleColor);
        }

        internal static void AddFigure( IFigure figure)
        {
            int x;
            int y;
            int[] elemCoords = figure.ElementsCoordinates;

            for (int j = 0; j < elemCoords.Length; j += 2)
            {
                x = figure.PositionX + elemCoords[j];
                y = figure.PositionY + elemCoords[j + 1];

                Field.Cells[y][x] = figure.Element;
            }
        }

        internal static void AddNewObstacle()
        {
            int middle = FieldData.GameFieldHeight / 2 + 1;
            int bottom = FieldData.GameFieldHeight - 3;
            int lastColumn = FieldData.GameFieldWidth - 3;

            int x = RandomNumber.InRange(2, lastColumn);
            int y = RandomNumber.InRange(middle, bottom);

            Field.Cells[y][x] = obstacle;
        }
    }
}

