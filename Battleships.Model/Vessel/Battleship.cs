using Battleships.Model.Enums;

namespace Battleships.Model.Vessel
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 5;
            Type = ShipType.Battleship;
        }
    }
}
