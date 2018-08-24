using Tetris.Logic.Figures;
using System.Linq;
using Tetris.Logic.Game.BaseLogic.Visualizers;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Essentials
{
    internal class Checker
    {
        private FieldCells fieldCells;

        internal Checker()
        {
            fieldCells = new FieldCells();
        }

        internal bool IsFinished(IFigure figure)
        {

            if (IsReachedBorder(figure, 0, 1))
            {
                FieldCellsManager.AddFigure(fieldCells, figure);

                CheckForReadyLine(figure);
                return true;
            }

            return false;
        }

        internal bool IsReachedBorder(IFigure figure, sbyte xValue = 0, sbyte yValue = 0)
        {
            int x = figure.PositionX + xValue;
            int y = figure.PositionY + yValue;
            int[] elemCoords = figure.ElementsCoordinates;

            for (int i = 0; i < elemCoords.Length; i += 2)
            {
                if (fieldCells
                   [y + elemCoords[i + 1]]
                   [x + elemCoords[i]]
                   .Symbol != ' ')
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckForReadyLine(IFigure figure)
        {
            //That row says the maximum size of figure must be 3(Three) cells, no more. I decided so!
            int approximateRow = figure.PositionY + 1;

            while (approximateRow >= (figure.PositionY - 1))
            {
                //Checks if approximate row is out of range
                if (approximateRow > (FieldData.GameFieldHeight - 2))
                {
                    approximateRow--;
                    continue;
                }

                //Checks if approximate row is ready
                if (fieldCells[approximateRow].All(e => e.Symbol != ' '))
                {
                    fieldCells.ReDrawFieldOnReadyLine(approximateRow);
                    GameData.points += GameData.PointPerLine;
                    continue;
                }

                approximateRow--;
            }
        }
    }
}