using Battleships.Model.Enums;
using Battleships.Model.Interfaces;

namespace Battleships.Model.Vessel
{
    /// <summary>
    /// Represents a player's ship as placed on their Game Board.
    /// </summary>
    public abstract class Ship : IShip
    {
        public string Name { get; set; }
        public int Width { get; set; }
        private int Hits { get; set; }
        public ShipType Type { get; set; }

        /// <summary>
        /// The vessel is destroyed when the number of hits matches it size (length)
        /// </summary>
        public virtual bool IsDestroyed
        {
            get
            {
                return Hits >= Width;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsHit
        {
            get
            {
                return Hits > 0;
            }
        }

        /// <summary>
        /// A shot on an existing ship is a hit !
        /// </summary>
        public ShotType ProcessShot()
        {
            Hits++;
            return IsDestroyed ? ShotType.Sunk : ShotType.Hit;
        }
    }
}
