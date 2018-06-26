using System;
using Battleships.Model.Board;
using Battleships.Model.Interfaces;
using System.Linq;

namespace Battleships.Model.Strategies
{
    public class RandomShotStrategy : IShootingStrategy
    {
        private ShootingBoard _board;

        public RandomShotStrategy(ShootingBoard board)
        {
            _board = board;
        }

        /// <summary>
        /// Get coordiates for a random shot at any cell that has not been shot at yet ?
        /// </summary>
        /// <returns></returns>
        public Coordinates GetShot()
        {
            var unhitCells = _board.GetUnhitCells().ToList();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var index = rand.Next(unhitCells.Count());
            return unhitCells[index].Coordinates;
        }

    }
}
