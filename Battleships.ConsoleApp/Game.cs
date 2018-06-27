using System;
using Battleships.Model.Strategies;
using System.Collections.Generic;
using System.Linq;

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
        private const string TheComputer = "Mighty Computer";

        private List<Player> Players;
        private Player player1;
        private Player player2;
        private string _singlePlayerName;

        public Game(string playerName)
        {
            _singlePlayerName = playerName;
        }

        /// <summary>
        /// Set up a game against the computer
        /// </summary>
        public Game SetupSimpleGameVersusComputer()
        {
            player1 = new Player()
            {
                Name = _singlePlayerName,
                ShootingStrategy = new ManualShotStrategy() // override the shooting strategy to nbe manual !
            };

            //TODO - Note shootingStrategy for the computer is currently random its needs a bit of intelligence
            player2 = new Player()
            {
                Name = TheComputer
            };

            Players = new List<Player>
            {
                player1,
                player2
            };

            Players.ForEach(player => player.SetupGameBoard());
            return this;
        }

        /// <summary>
        /// Set up a round where player1 goes first followed by player2
        /// </summary>
        private bool PlayRound()
        {
            bool gameOn = true;
            Console.WriteLine($"Here are your game and shooting boards...");

            player1.DisplayBoards();

            var coordinates = player1.GetShot();
            var shotResult = player2.ProcessShot(coordinates);
            Console.WriteLine($"{player2.Name} says '{shotResult}'");
            player1.ProcessShotResult(coordinates, shotResult);

            if (player2.HasLost)
            {
                Console.WriteLine($"Congratulations '{player1}' has won the game!");
                Console.WriteLine($"Here are the '{player2}' boards");
                player2.DisplayBoards();
                gameOn = false;
            }
            else
            {
                coordinates = player2.GetShot();
                Console.WriteLine($"{player2} tried a shot at '{coordinates}'");
                shotResult = player1.ProcessShot(coordinates);
                Console.WriteLine($"{player1} says '{shotResult}'");
                player2.ProcessShotResult(coordinates, shotResult);

                if (player1.HasLost)
                {
                    Console.WriteLine($"Congratulations '{player2}' has won the game!");
                    Console.WriteLine($"Here are the '{player1}' boards");
                    player1.DisplayBoards();
                    gameOn = false;
                }
            }
            return gameOn;
        }

        /// <summary>
        /// Play a game between 'player1 and the computer
        /// </summary>
        public void PlayToEnd()
        {
            var gameOn = true;
            while (gameOn && player1 != null && player2 != null)
            {
                gameOn = PlayRound();
            }

            Console.Write("Press any key to exit...");
            Console.ReadLine(); 
        }

        
    }
}
