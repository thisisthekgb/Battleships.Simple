
using Battleships.Model.Game;
using System;

namespace BattleshipsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            Console.WriteLine("Welcome to a simple game of Battleships");
            Console.WriteLine("When prompted, enter coordinates in the form 'A5'");
            Console.WriteLine("Where 'A' is the column and '5' is the row you wish to shoot at.");
            Console.WriteLine();
            Console.Write("First enter your name to play against the computer :- ");
            var playerName = Console.ReadLine();

            new Game(playerName).SetupSimpleGameVersusComputer().PlayToEnd();
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
