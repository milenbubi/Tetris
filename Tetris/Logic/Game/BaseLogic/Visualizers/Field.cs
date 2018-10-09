using System;
using System.Linq;
using Tetris.Logic.Figures;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Visualizers
{
    internal class Field
    {
        private static readonly int fieldRows;
        private static readonly int fieldColumns;
        private static readonly FigureElement BorderElement;

        static Field()
        {
            fieldRows = FieldData.GameFieldHeight;
            fieldColumns = FieldData.GameFieldWidth;

            BorderElement = new FigureElement(FieldData.BorderSymbolColor, FieldData.BorderSymbol);
        }

        internal static IList<FigureElement[]> Cells { get; set; }

        internal static void ReDrawFieldOnReadyLine(int readyLine)
        {
            //Removing ready line, insert and initializing a new empty row
            Cells.RemoveAt(readyLine);
            Cells.Insert(1, new FigureElement[fieldColumns]);
            Initialize(1);

            //Redrawing game field
            DrawRowsInRange(2, readyLine);
        }

        internal static void DrawAllRows() => DrawRowsInRange(0, fieldRows - 1);

        internal static void ResetCells()
        {
            Cells = new List<FigureElement[]>(fieldRows);

            //Initialize the cell List
            for (int row = 0; row < fieldRows - 2; row++)
            {
                Cells.Add(new FigureElement[fieldColumns]);
                Initialize(row);
            }

            //Initialize the top and bottom
            FigureElement[] horizontalBorder = Enumerable
                .Repeat(BorderElement, fieldColumns)
                .ToArray();

            Cells.Insert(0, horizontalBorder);
            Cells.Add(horizontalBorder);
        }

        private static void Initialize(int row)
        {
            for (int col = 1; col < fieldColumns - 1; col++)
            {
                Cells[row][col] = new FigureElement(FieldData.BackgroundColor, ' ');
            }

            //Vertical borders
            Cells[row][0] = BorderElement;
            Cells[row][fieldColumns - 1] = BorderElement;
        }

        private static void DrawRowsInRange(int from, int to)
        {
            for (int row = from; row <= to; row++)
            {
                Console.SetCursorPosition(0, row);

                foreach (var item in Cells[row])
                {
                    Console.Write(item);
                }
            }
        }
    }
}