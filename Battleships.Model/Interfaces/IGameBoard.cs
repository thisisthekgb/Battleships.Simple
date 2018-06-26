using Battleships.Model.Vessel;
using Battleships.Model.Board;

namespace Battleships.Model.Interfaces
{
    public interface IGameBoard
    {
        /// <summary>
        /// Return ship at a specific coordinate
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        Ship GetShipAt(Coordinates coords);

        IPlaceShipStrategy placeShipsStrategy { get; set; }
    }
}