using System;
using Tetris.Logic.Figures;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Game.BaseLogic.Essential
{
    internal class FieldCells
    {
        private static readonly int fieldRows;
        private static readonly int fieldColumns;
        private static readonly FigureElement BorderElement;
        private static List<FigureElement[]> fieldCells;

        static FieldCells()
        {
            fieldRows = FieldData.GameFieldHeight;
            fieldColumns = FieldData.GameFieldWidth;

            BorderElement = new FigureElement(FieldData.BorderSymbolColor, FieldData.BorderSymbol);
        }

        internal FigureElement[] this[int index] => fieldCells[index];

        internal int Count => fieldCells.Count;

        internal void DrawAllRows() => DrawRowsInRange(0, fieldRows - 1);

        internal void ResetCells()
        {
            fieldCells = new List<FigureElement[]>(fieldRows);

            //Initialize the cell List
            for (int row = 0; row < fieldRows - 2; row++)
            {
                fieldCells.Add(new FigureElement[fieldColumns]);
                Initialize(row);
            }

            //Initialize the top and bottom
            FigureElement[] horizontalBorder = Enumerable
                .Repeat(BorderElement, fieldColumns)
                .ToArray();

            fieldCells.Insert(0, horizontalBorder);
            fieldCells.Add(horizontalBorder);
        }

        internal void ReDrawFieldOnReadyLine(int readyLine)
        {
            //Removing ready line, insert and initializing a new empty row
            fieldCells.RemoveAt(readyLine);
            fieldCells.Insert(1, new FigureElement[fieldColumns]);
            Initialize(1);

            //Redrawing game field
            DrawRowsInRange(2, readyLine);
        }

        private void Initialize(int row)
        {
            for (int col = 1; col < fieldColumns - 1; col++)
            {
                fieldCells[row][col] = new FigureElement(FieldData.BackgroundColor, ' ');
            }

            //Vertical borders
            fieldCells[row][0] = BorderElement;
            fieldCells[row][fieldColumns - 1] = BorderElement;
        }

        private void DrawRowsInRange(int from, int to)
        {
            for (int row = from; row <= to; row++)
            {
                Console.SetCursorPosition(0, row);
                foreach (var item in fieldCells[row])
                {
                    Console.Write(item);
                }
            }
        }
    }
}