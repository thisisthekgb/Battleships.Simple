using System.Linq;
using System;

using Battleships.Model.Extensions;
using Battleships.Model.Vessel;
using Battleships.Model.Interfaces;
using Battleships.Model.Strategies;

namespace Battleships.Model.Board
{
    /// <summary>
    /// Represents a players board where their ships can be placed).
    /// </summary>
    public class GameBoard : BoardBase, IGameBoard
    {
        public IPlaceShipStrategy placeShipsStrategy { get; set; }

        public GameBoard() : this(new RandomPlaceShipStrategy()) //TODO - inject the strategy required !
        {
            
        }

        public GameBoard(IPlaceShipStrategy strategy)
        {
            placeShipsStrategy = strategy;
        }

        public override void AddCell(int row, int col)
        {
            Cells.Add(new GameCell()
            {
                Coordinates = new Coordinates(row,col),
                Ship = null
            });
        }

    /// <summary>
        /// Locate a ship at specified coordinates
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        public Ship GetShipAt(Coordinates coords)
        {
            var cell = Cells.Range(coords.Row, coords.Column, coords.Row, coords.Column).FirstOrDefault() as GameCell;
            return cell != null ? cell.Ship : null;
        }

        /// <summary>
        /// Place ship on board 
        /// </summary>
        /// <param name="ships"></param>
        public void PlaceShip(Ship ship)
        {
            // Locate a place for the ship
            var shipLocation = placeShipsStrategy.WhereToPlaceShip(ship,this);

            // Assign the ship to the cells location
            shipLocation.ToList().ForEach(cell => ((GameCell)cell).Ship = ship);

        }

        /// <summary>
        /// Display the board
        /// TODO - remove this as delegate !!
        /// </summary>
        public override void Display()
        {
            for (int row = 1; row <= BoardSize; row++)
            {
                if (row == 1)
                {
                    Console.Write("    ");
                    for (int col = 1; col <= BoardSize; col++)
                    {
                        char column = (char)(col + 64);
                        Console.Write($"{column} ");
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                Console.Write($"{row,3} ");

                for (int col = 1; col <= BoardSize; col++)
                {
                    var cell = Cells.At(row, col) as GameCell;
                    Console.Write($"{cell.OccupiedState.Description()} ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

    }
}
