using System;
using Battleships.Model.Strategies;

namespace Battleships.Model.Game
{
    /// <summary>
    /// The game consists of a simple version of the game Battleships.
    /// A single human player plays a one sided game of Battleships against ships placed by the computer.
    /// The board game is a 10x10 grid of cells with several ships on the grid at random places with the 
    /// following sizes :-
    /// 
    /// 1 x Battleship (5 squares)
    /// 2 x Destroyers (4 squares)
    /// 
    /// The player enters coordinates of the form "A5" where A is the column and '5' is the row to specifiy
    /// a cell to target.
    /// 
    /// Shots result in its, misses or sinks. The game ends when all ships are sunk.
    /// 
    /// </summary>
    public class Game
    {
        // Just set a single player against the computer..
        public Player Player { get; set; }
        public Player Computer { get; set; }

        public Game()
        {
            Player = new Player("Kgb"); 
            Computer = new Player("Mighty Computer");

            Player.SetupGameBoard();
            Computer.SetupGameBoard();

            // Override the default random shooting strategy for the player...
            Player.ShootingStrategy = new ManualShotStrategy();
        }

        /// <summary>
        /// Set up a round where the player goes first followed by the computer...
        /// </summary>
        public void PlayRound()
        {
            Console.WriteLine($"Here are your game and shooting boards...");

            Player.DisplayBoards();

            var coordinates = Player.GetShot();
            var result = Computer.ProcessShot(coordinates);
            Console.WriteLine($"{Computer.Name} says '{result}'");
            Player.ProcessShotResult(coordinates, result);

            if (Computer.HasLost)
            {
                Console.WriteLine($"Congratulations '{Player.Name}' has won the game!");
                Console.WriteLine($"Here are the '{Computer.Name}' boards");
                Computer.DisplayBoards();
            }
            else
            {
                coordinates = Computer.GetShot();
                Console.WriteLine($"{Computer.Name} tried a shot at '{coordinates}'");
                result = Player.ProcessShot(coordinates);
                Console.WriteLine($"{Player.Name} says '{result}'");
                Computer.ProcessShotResult(coordinates, result);

                if (Player.HasLost)
                {
                    Console.WriteLine($"Congratulations '{Computer.Name}' has won the game!");
                    Console.WriteLine($"Here are the '{Player.Name}' boards");
                    Player.DisplayBoards();
                }
            }

        }

        public void PlayToEnd()
        {
            while (!Player.HasLost && !Computer.HasLost)
            {
                PlayRound();
            }

            Console.Write("Press any key to exit...");
            Console.ReadLine(); 
        }

        
    }
}
