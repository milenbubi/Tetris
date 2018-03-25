using System;
using System.Collections.Generic;
using Tetris.Logic.Figures;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal class FieldCellsManager
    {
        private static int fieldCellRows;
        private static int fieldCellsColumns;
        private static FigureElement horBorderElement;
        private static FigureElement vertBorderElement;
        private static List<FigureElement[]> fieldCells;

        static FieldCellsManager()
        {
            fieldCellRows = FieldData.GameFieldHeight;
            fieldCellsColumns = FieldData.GameFieldWidth;

            fieldCells = new List<FigureElement[]>(fieldCellRows);

            horBorderElement = new FigureElement(ConsoleColor.White, FieldData.HorizontalBorderSymbol);
            vertBorderElement = new FigureElement(ConsoleColor.White, FieldData.VerticalBorderSymbol);

            //Initialize the cell List
            for (int row = 0; row < fieldCellRows - 1; row++)
            {
                fieldCells.Add(new FigureElement[fieldCellsColumns]);
                Initialize(row);
            }

            //Initialize the top and bottom
            fieldCells.Insert(0, new FigureElement[fieldCellsColumns]);
            fieldCells.Add(new FigureElement[fieldCellsColumns]);
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
            fieldCells.Insert(1, new FigureElement[fieldCellsColumns]);
            Initialize(1);
        }

        //internal void aDrawRowsInRange(int from, int to)
        //{
        //    DrawRowsInRange(from, to);
        //}

        internal void DrawAllRows()
        {
            DrawRowsInRange(0, fieldCellRows - 1);
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
            for (int col = 1; col < fieldCellsColumns - 1; col++)
            {
                fieldCells[row][col] = new FigureElement(ConsoleColor.White, ' ');
            }

            //Vertical borders
            fieldCells[row][0] = vertBorderElement;
            fieldCells[row][fieldCellsColumns - 1] = vertBorderElement;
        }

        private static void InitializeHorizontalBorders()
        {
            for (int col = 0; col < fieldCellsColumns; col++)
            {
                fieldCells[0][col] = horBorderElement;
                fieldCells[fieldCellRows - 1][col] = horBorderElement;
            }
        }
    }
}