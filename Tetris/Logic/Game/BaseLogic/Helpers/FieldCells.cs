using System;
using Tetris.Logic.Figures;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Helpers

{
    internal class FieldCells
    {
        private static int fieldRows;
        private static int fieldColumns;
        private static FigureElement horBorderElement;
        private static FigureElement vertBorderElement;
        private static List<FigureElement[]> fieldCells;

        static FieldCells()
        {
            fieldRows = FieldData.GameFieldHeight;
            fieldColumns = FieldData.GameFieldWidth;

            fieldCells = new List<FigureElement[]>(fieldRows);

            horBorderElement = new FigureElement(ConsoleColor.White, FieldData.HorizontalBorderSymbol);
            vertBorderElement = new FigureElement(ConsoleColor.White, FieldData.VerticalBorderSymbol);

            //Initialize the cell List
            for (int row = 0; row < fieldRows - 1; row++)
            {
                fieldCells.Add(new FigureElement[fieldColumns]);
                Initialize(row);
            }

            //Initialize the top and bottom
            fieldCells.Insert(0, new FigureElement[fieldColumns]);
            fieldCells.Add(new FigureElement[fieldColumns]);
            InitializeHorizontalBorders();
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
            fieldCells[row][0] = vertBorderElement;
            fieldCells[row][fieldColumns - 1] = vertBorderElement;
        }

        private static void InitializeHorizontalBorders()
        {
            for (int col = 0; col < fieldColumns; col++)
            {
                fieldCells[0][col] = horBorderElement;
                fieldCells[fieldRows - 1][col] = horBorderElement;
            }
        }
    }
}