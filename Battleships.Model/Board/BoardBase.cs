using System;
using System.Collections.Generic;

using Battleships.Model.Extensions;

namespace Battleships.Model.Board
{

    abstract public class BoardBase
    {
        private const int BoardSizeDefault = 10;    // TODO start at 10 but make it configuratble later
        public const int BoardSizeMin = 5;          // define a min size of the board

        public List<Cell> Cells { get; set; }

        public int BoardSize { get; private set; }

        public string Name { get; set; }

        public BoardBase(int size = BoardSizeDefault)
        {
            BoardSize = size;

            if (BoardSize <= BoardSizeMin)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Board size is too small!");
            }

            InitialiseBoard();
        }

        /// <summary>
        /// Clear the board...
        /// </summary>
        private void InitialiseBoard()
        {
            Cells = new List<Cell>();
            for (int row = 1; row <= BoardSize; row++)
            {
                for (int col = 1; col <= BoardSize; col++)
                {
                    AddCell(row, col);
                }
            }
        }

        public abstract void AddCell(int row, int col);

        /// <summary>
        /// Display the board
        /// TODO - THIS NEED TO BE OVERRIDEN FOR NON CONSOLE OR DELEGATE IT !
        /// </summary>
        public abstract void Display();

    }
}
