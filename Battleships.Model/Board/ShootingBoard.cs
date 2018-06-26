
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

        //public List<Coordinates> GetHitNeighbors()
        //{
        //    List<Panel> panels = new List<Panel>();
        //    var hits = Panels.Where(x => x.OccupationType == OccupationType.Hit);
        //    foreach(var hit in hits)
        //    {
        //        panels.AddRange(GetNeighbors(hit.Coordinates).ToList());
        //    }
        //    return panels.Distinct().Where(x => x.OccupationType == OccupationType.Empty).Select(x => x.Coordinates).ToList();
        //}

        //public List<Panel> GetNeighbors(Coordinates coordinates)
        //{
        //    int row = coordinates.Row;
        //    int column = coordinates.Column;
        //    List<Panel> panels = new List<Panel>();
        //    if (column > 1)
        //    {
        //        panels.Add(Panels.At(row, column - 1));
        //    }
        //    if (row > 1)
        //    {
        //        panels.Add(Panels.At(row - 1, column));
        //    }
        //    if (row < 10)
        //    {
        //        panels.Add(Panels.At(row + 1, column));
        //    }
        //    if (column < 10)
        //    {
        //        panels.Add(Panels.At(row, column + 1));
        //    }
        //    return panels;
        //}

        public override void AddCell(int row, int col)
        {
            Cells.Add(new ShootingCell()
            {
                Coordinates = new Coordinates(row,col),
                ShotType = ShotType.Unknown
            });
        }

        public override void Display()
        {
            for (int row = 1; row <= BoardSize; row++)
            {
                for (int col = 1; col <= BoardSize; col++)
                {
                    var cell = Cells.At(row, col) as ShootingCell;
                    Console.Write(cell.ShotType.Description());
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

    }
}
