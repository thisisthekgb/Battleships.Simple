using System;
using System.Text.RegularExpressions;

namespace Battleships.Model.Board
{
    /// <summary>
    /// Represent coordinates of cell on board
    /// </summary>
    public class Coordinates
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        /// <summary>
        /// Convert row,col mto coordinates 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Convert string in format 'A1' to coordinates
        /// </summary>
        /// <param name="input"></param>
        public Coordinates(string input)
        {
            var regex = new Regex(@"(?<col>([A-Z]|[a-z])+)(?<row>(\d)+)");
            var match = regex.Match(input);

            Column = Convert.ToChar(match.Groups["col"].Value) % 32; // convert char to integer
            Row = int.Parse(match.Groups["row"].Value);
        }

        public override string ToString()
        {
            char column = (char)(Column + 64); // int to ASCII char value
            return $"{column}{Row}";
        }
    }
}
