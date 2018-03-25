using Tetris.Logic.Figures;
using Tetris.Logic.Game.BaseLogic.Managers;

namespace Tetris.Logic.Game.BaseLogic.Helpers
{
    public class Checker
    {
        private FieldCellsManager fieldCells;
        private int[] elementsCoordinates;

        public Checker()
        {
            this.fieldCells = new FieldCellsManager();
        }

        internal bool IsFinished(IFigure figure)
        {
            if (figure.Element == null)
            {
                return true;
            }

            int x;
            int y;
            elementsCoordinates = figure.ElementsCoordinates();

            if (IsReachedBorder(figure, 0, 1))
            {
                for (int j = 0; j < elementsCoordinates.Length; j += 2)
                {
                    x = figure.PositionX + elementsCoordinates[j];
                    y = figure.PositionY + elementsCoordinates[j + 1];

                    fieldCells[y][x] = figure.Element;
                }

                CheckForReadyLine(figure);
                return true;
            }
            return false;
        }

        internal bool IsReachedBorder(IFigure figure, sbyte xValue, sbyte yValue)
        {
            int x = figure.PositionX + xValue;
            int y = figure.PositionY + yValue;
            elementsCoordinates = figure.ElementsCoordinates();

            for (int i = 0; i < elementsCoordinates.Length; i += 2)
            {
                if (fieldCells
                   [y + elementsCoordinates[i + 1]]
                   [x + elementsCoordinates[i]]
                   .Symbol != ' ')
                {
                    return true;
                }
            }
            return false;
        }

        internal void CheckForReadyLine(IFigure figure)
        {
            //That row says the maximum size of figure must be 3(Nine) cells, no more. I decided so!
            int approximateRow = figure.PositionY + 1;
            bool isReadyLine;

            while (approximateRow >= (figure.PositionY - 1))
            {
                isReadyLine = true;

                //Checks if approximate row is out of range
                if (approximateRow > (FieldData.WindowHeight - 3) || approximateRow <= 1)
                {
                    approximateRow -= 1;
                    continue;
                }

                //Checks if approximate row is not filled
                for (int col = 1; col < fieldCells[approximateRow].Length - 1; col++)
                {
                    if (fieldCells[approximateRow][col].Symbol == ' ')
                    {
                        isReadyLine = false;
                        break;
                    }
                }

                if (isReadyLine)
                {
                    ReDrawFieldOnReadyLine(figure, approximateRow);
                    GameData.points += GameData.pointPerLine;
                    continue;
                }
                approximateRow -= 1;
            }
        }

        private void ReDrawFieldOnReadyLine(IFigure figure, int readyLine)
        {
            //Премахване на готова линия, вмъкване и инициализиране на нов празен ред
            fieldCells.Remove(readyLine);
            fieldCells.InsertNewRow();

            //Redrawing game field
            fieldCells.DrawRowsInRange(2, readyLine);
        }
    }
}
