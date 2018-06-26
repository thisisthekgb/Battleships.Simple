using Battleships.Model.Board;

namespace Battleships.Model.Interfaces
{
    /// <summary>
    /// Represents the strategy used to fire shots at an opponents gameboard
    /// </summary>
    public interface IShootingStrategy
    {
        Coordinates GetShot();
    }
}
