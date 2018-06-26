using System;
using System.Collections.Generic;

using Battleships.Model.Interfaces;
using Battleships.Model.Board;
using System.Text.RegularExpressions;

namespace Battleships.Model.Strategies
{
    /// <summary>
    /// Provide a manual strategy for getting shot coords from player.
    /// </summary>
    public class ManualShotStrategy : IShootingStrategy
    {
        private Coordinates ConvertToCoordinates(string input)
        {
            var validColumns = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" }; // KGB -  make this auto as only works when board <= 10 !!
            var regex = new Regex(@"(?<col>([A-Z]|[a-z])+)(?<row>(\d)+)");
            var match = regex.Match(input);
            //var col = validColumns.IndexOf(match.Groups["col"].Value) + 1; // coords are not 0 based !
            var col = Convert.ToChar(match.Groups["col"].Value) % 32; // convert char to integer
            var row = int.Parse(match.Groups["row"].Value);

            return new Coordinates(row, col);
        }

        /// <summary>
        /// Get the coordinates of the players shot
        /// </summary>
        /// <returns></returns>
        public Coordinates GetShot()
        {
            Console.Write($"Enter shot coords :- ");
            var input = Console.ReadLine();
            Coordinates result = null;

            try
            {
                return result = ConvertToCoordinates(input);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid input");
            }
        }
    }
}
