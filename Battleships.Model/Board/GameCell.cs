using Battleships.Model.Enums;
using Battleships.Model.Vessel;

namespace Battleships.Model.Board
{
    /// <summary>
    /// Represents a single cell on the board.
    /// </summary>
    public class GameCell : Cell
    {
        public Ship Ship { get; set; }

        /// <summary>
        /// A cell occupation state is either occupied and has the ship type or not !
        /// </summary>
        public ShipType OccupiedState
        {
            get
            {
                return IsOccupied ? Ship.Type : ShipType.None;
            }
        }

        /// <summary>
        /// Cell is occupied when it has a ship
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return Ship != null;
            }
        }
    }
}
