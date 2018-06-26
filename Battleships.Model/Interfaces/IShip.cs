using Battleships.Model.Enums;

namespace Battleships.Model.Interfaces
{
    public interface IShip
    {
        bool IsDestroyed { get; }
        string Name { get; set; }
        ShipType Type { get; set; }
        int Width { get; set; }

        ShotType ProcessShot();
    }
}