using Battleships.Model.Board;
using System.Collections.Generic;

namespace Battleships.Model.Interfaces
{
    public interface IPlaceShipStrategy
    {
        /// <summary>
        /// Returns cell locations of where to place a ship on the gameboard
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="board"></param>
        IEnumerable<Cell> WhereToPlaceShip(IShip ship, BoardBase board);
    }
}
