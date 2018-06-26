using Battleships.Model.Enums;

namespace Battleships.Model.Interfaces
{
    /// <summary>
    /// Represents the required interface to handle a ship in battleships
    /// </summary>
    public interface IShip
    {
        bool IsDestroyed { get; }
        string Name { get; set; }
        ShipType Type { get; set; }
        int Width { get; set; }

        ShotType ProcessShot();
    }
}