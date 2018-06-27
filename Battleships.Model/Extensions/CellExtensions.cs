using System.Collections.Generic;
using System.Linq;

using Battleships.Model.Board;

namespace Battleships.Model.Extensions
{
    public static class CellExtensions
    {
        /// <summary>
        /// Return cell at specified coordinates
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Cell At(this IEnumerable<Cell> cells, int row, int column)
        {
            return cells.Where(cell => cell.Coordinates.Row == row && cell.Coordinates.Column == column).FirstOrDefault();
        }

        /// <summary>
        /// Return range of cells that fall between start and end rows/columns inclusive.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public static IEnumerable<Cell> Range(this IEnumerable<Cell> cells, int startRow, int startColumn, int endRow, int endColumn)
        {
            return cells.Where(cell => cell.Coordinates.Row >= startRow 
                                     && cell.Coordinates.Column >= startColumn 
                                     && cell.Coordinates.Row <= endRow 
                                     && cell.Coordinates.Column <= endColumn).ToList();
        }
    }
}
