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
        private BoardBase CurrentBoard { get; set; }

        /// <summary>
        /// Are row column out of bounds of board
        /// </summary>
        /// <param name="endrow"></param>
        /// <param name="endcolumn"></param>
        /// <returns></returns>
        private bool IsOutOfBounds(int endrow, int endcolumn)
        {
            return (endrow > CurrentBoard.BoardSize || endcolumn > CurrentBoard.BoardSize);
        }

        /// <summary>
        /// Are any of the cells within the range of cells occupied.
        /// </summary>
        /// <param name="startrow"></param>
        /// <param name="startcolumn"></param>
        /// <param name="endrow"></param>
        /// <param name="endcolumn"></param>
        /// <returns></returns>
        private bool IsOccupied(int startrow, int startcolumn, int endrow, int endcolumn)
        {
            var shipLocation = CurrentBoard.Cells.Range(startrow, startcolumn, endrow, endcolumn);
            return (shipLocation.Any(x => ((GameCell)x).IsOccupied));
        }

        public IEnumerable<Cell> WhereToPlaceShip(IShip ship, BoardBase board)
        {
            CurrentBoard = board;

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

                // Check that the strategy hasnt broken any game rules...
                // TODO - MAKE THESE RULES OF THE GAME THAT ALL STRATEGIES SHOULD CHECK !
                if (IsOutOfBounds(endrow,endcolumn)) continue;
                if (IsOccupied(startrow, startcolumn, endrow, endcolumn)) continue;

                // Return the ship location
                shipLocation = CurrentBoard.Cells.Range(startrow, startcolumn, endrow, endcolumn);

                break;
            }
            return shipLocation;
        }
    }
}
