
using System.Collections.Generic;
using System.Linq;

using Battleships.Model.Enums;
using Battleships.Model.Extensions;
using System;

namespace Battleships.Model.Board
{
    /// <summary>
    /// The shooting board represents the collection of cells
    /// showing where the player has 'fired' any shots on the opposing 
    /// players board.
    /// </summary>
    public class ShootingBoard : BoardBase
    {

        /// <summary>
        ///  Get all cells that have not been shot at yet.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cell> GetUnhitCells()
        {
             return Cells.Where(x => ((ShootingCell)x).HasNotBeenShotAt).Select(x => x) ;
        }

        public override void AddCell(int row, int col)
        {
            Cells.Add(new ShootingCell()
            {
                Coordinates = new Coordinates(row,col),
                ShotType = ShotType.Unknown
            });
        }

        /// <summary>
        /// Display the board
        /// TODO - remove this as delegate !!
        /// </summary>
        public override void Display()
        {
            for (int row = 1; row <= BoardSize; row++)
            {
                if (row == 1)
                {
                    Console.Write("    ");
                    for (int col = 1; col <= BoardSize; col++)
                    {
                        char column = (char)(col + 64);
                        Console.Write($"{column} ");
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                Console.Write($"{row,3} ");
                for (int col = 1; col <= BoardSize; col++)
                {
                    var cell = Cells.At(row, col) as ShootingCell;
                    Console.Write($"{cell.ShotType.Description()} ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

    }
}
