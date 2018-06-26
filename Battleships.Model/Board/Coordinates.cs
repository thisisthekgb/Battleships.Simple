namespace Battleships.Model.Board
{
    /// <summary>
    /// Represent coordinates of cell on board
    /// </summary>
    public class Coordinates
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"Col:{Column} Row:{Row}";
        }
    }
}
