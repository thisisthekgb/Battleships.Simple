using System.Collections.Generic;
using System.Linq;

using Battleships.Model.Board;
using Battleships.Model.Vessel;
using Battleships.Model.Enums;
using Battleships.Model.Extensions;
using Battleships.Model.Interfaces;
using Battleships.Model.Strategies;

namespace Battleships.Model
{
    /// <summary>
    /// Represent the player having a number of ships to place on a gameboard as well
    /// as a board to capture shots made at an aopponent and their outcomes.
    /// </summary>
    public class Player : IShootingStrategy
    {
        public string Name { get; set; }
        private GameBoard GameBoard { get; set; }
        private ShootingBoard ShootingBoard { get; set; }
        private List<Ship> Ships { get; set; }

        public IShootingStrategy ShootingStrategy { get; set; }

        public Player()
        {
            // Each player has 1 Battleship & 2 Destroyers (currently)
            // TODO - Would be nice to have this as a configuration option
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Destroyer(),
                new Battleship(),
            };
            // Each player has a board where the ships are placed
            GameBoard = new GameBoard();
            // Each player has a board that keeps track of shots made at the opponents ships
            ShootingBoard = new ShootingBoard();

            // Set up the players shooting strategy..
            ShootingStrategy = new RandomShotStrategy(ShootingBoard); //TODO inject the shooting strategy !
        }

        /// <summary>
        /// Player has lost if all their ships are destroyed
        /// </summary>
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsDestroyed);
            }
        }

       
        /// <summary>
        /// Place the players ships onto the gameboard
        /// </summary>
        public void SetupGameBoard()
        {
            foreach (Ship ship in Ships)
            {
                GameBoard.PlaceShip(ship);
            }
        }

        /// <summary>
        /// Display the players boards
        /// </summary>
        public void DisplayBoards()
        {
            GameBoard.Display();
            ShootingBoard.Display();
        }

        /// <summary>
        /// Process shot by determingin if the shot either hit , missed or sunk a ship.
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        public ShotType ProcessShot(Coordinates coords)
        {
            var ship = GameBoard.GetShipAt(coords);

            if (ship == null)
            {
                return ShotType.Miss;
            }
            else 
            {
                return ship.ProcessShot();
            }
        }

        /// <summary>
        /// Show the shot result on the shooting board.
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="result"></param>
        public void ProcessShotResult(Coordinates coords, ShotType result)
        {
            var cell = ShootingBoard.Cells.At(coords.Row, coords.Column) as ShootingCell;
            if (cell == null) return;

            switch (result)
            {
                case ShotType.Hit:
                    {
                        cell.ShotType = ShotType.Hit;
                        break;
                    }

                case ShotType.Miss:
                    {
                        cell.ShotType = ShotType.Miss;
                        break;
                    }
                case ShotType.Sunk:
                    {
                        cell.ShotType = ShotType.Sunk;
                        break;
                    }
                default:
                    {
                        cell.ShotType = ShotType.Unknown;
                        break;
                    }
            }
        }

        /// <summary>
        /// Take a shot...
        /// </summary>
        /// <returns></returns>
        public Coordinates GetShot()
        {
            return ShootingStrategy.GetShot();
        }
    }
}
