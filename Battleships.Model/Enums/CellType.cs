using System.ComponentModel;

namespace Battleships.Model.Enums
{
    /// <summary>
    /// Represents the stats of the board cell
    /// </summary>
    public enum CellType
    {
        [Description(".")]
        Unoccupied,
        [Description("*")]
        Occupied
    }
}
