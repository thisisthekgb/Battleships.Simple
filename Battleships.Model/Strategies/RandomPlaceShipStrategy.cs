using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Model.Board;
using Battleships.Model.Interfaces;
using Battleships.Model.Extensions;

namespace Battleships.Model.Strategies
{
    /// <summary>
    /// Provide a random placement strategy for placing ships on board.
    /// </summary>
    public class RandomPlaceShipStrategy : IPlaceShipStrategy
    {
        public IEnumerable<Cell> WhereToPlaceShip(IShip ship, BoardBase board)
        {
            IEnumerable<Cell> shipLocation = null;

            // Seed the randome number generator..
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            // Select a random row/column and orientation 
            // If none of the proposed cells are occupied, place the ship

            while (true)    //TODO - what happens if we never find a place for the ship !
            {
                var startcolumn = rand.Next(1, board.BoardSize + 1);
                var startrow = rand.Next(1, board.BoardSize);
                var endrow = startrow;
                var endcolumn = startcolumn;

                bool horizontal = Convert.ToBoolean(rand.Next(2));  // 0 or 1 
                if (horizontal)
                {
                    endcolumn += ship.Width - 1;
                }
                else
                {
                    endrow += ship.Width - 1;
                }

                // TODO - make these rules for the game !
                // If we pass any specific rules for the board then continue to place the ship...
                // We cannot place ships beyond the boundaries of the board
                if (endrow > board.BoardSize || endcolumn > board.BoardSize)
                {
                    continue;
                }

                //Check if specified cells are occupied
                shipLocation = board.Cells.Range(startrow, startcolumn, endrow, endcolumn);
                if (shipLocation.Any(x => ((GameCell)x).IsOccupied))
                {
                    continue;
                }

                break;
            }
            return shipLocation;
        }
    }
}
