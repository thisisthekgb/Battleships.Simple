using System.ComponentModel;

namespace Battleships.Model.Enums
{
    public enum ShipType
    {
        [Description("B")]
        Battleship,

        [Description("D")]
        Destroyer,

        [Description(".")]
        None
    }

}
