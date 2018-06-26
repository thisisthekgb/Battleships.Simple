using Battleships.Model.Enums;

namespace Battleships.Model.Vessel
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 4;
            Type = ShipType.Destroyer;
        }
    }
}
