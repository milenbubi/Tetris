using System;
using Tetris.Logic.Figures;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Game.BaseLogic.Helpers

{
    public class FieldCells
    {
        private static int fieldRows;
        private static int fieldColumns;
        private static FigureElement BorderElement;
        private static List<FigureElement[]> fieldCells;

        static FieldCells()
        {
            fieldRows = FieldData.GameFieldHeight;
            fieldColumns = FieldData.GameFieldWidth;

            BorderElement = new FigureElement(FieldData.BorderSymbolColor, FieldData.BorderSymbol);
            BorderElement = new FigureElement(FieldData.BorderSymbolColor, FieldData.BorderSymbol);
        }

        internal FigureElement[] this[int index]
        {
            get
            {
                return fieldCells[index];
            }

        }

        internal void Remove(int readyLine)
        {
            fieldCells.RemoveAt(readyLine);
        }

        internal void InsertNewRow()
        {
            fieldCells.Insert(1, new FigureElement[fieldColumns]);
            Initialize(1);
        }

        internal void DrawAllRows()
        {
            DrawRowsInRange(0, fieldRows - 1);
        }

        internal void DrawRowsInRange(int from, int to)
        {
            for (int row = from; row <= to; row++)
            {
                Console.SetCursorPosition(0, row);
                foreach (var item in fieldCells[row])
                {
                    Console.Write(string.Join("", item));
                }
            }
        }

        private static void Initialize(int row)
        {
            for (int col = 1; col < fieldColumns - 1; col++)
            {
                fieldCells[row][col] = new FigureElement(ConsoleColor.White, ' ');
            }

            //Vertical borders
            fieldCells[row][0] = BorderElement;
            fieldCells[row][fieldColumns - 1] = BorderElement;
        }

        internal static void ResetCells()
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
    }
}