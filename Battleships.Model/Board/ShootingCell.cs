using Battleships.Model.Enums;

namespace Battleships.Model.Board
{
    /// <summary>
    /// Represents a single cell on the board.
    /// </summary>
    public class ShootingCell : Cell
    {
        public ShotType ShotType { get; set; }

        /// <summary>
        /// Return whether the cell has been show at yet 
        /// </summary>
        public bool HasNotBeenShotAt
        {
            get
            {
                return ShotType.Equals(ShotType.Unknown);
            }
        }
    }
}
