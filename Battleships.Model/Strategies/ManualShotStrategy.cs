using System;

using Battleships.Model.Interfaces;
using Battleships.Model.Board;

namespace Battleships.Model.Strategies
{
    /// <summary>
    /// Provide a manual strategy for getting shot coords from player.
    /// </summary>
    public class ManualShotStrategy : IShootingStrategy
    {
        /// <summary>
        /// Get the coordinates of the players shot
        /// </summary>
        /// <returns></returns>
        public Coordinates GetShot()
        {
            while(true)
            {
                try
                {
                    Console.Write($"Enter shot coords :- ");
                    var input = Console.ReadLine();
                    return new Coordinates(input);
                }
                catch 
                {
                    Console.WriteLine("Invalid input...try again !");
                }
            }
        }
    }
}
