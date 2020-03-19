// Dragsters
// 
// A simulation that takes 3 racers acceleration and plots them over time
// to see who will win and how fast


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dragracer
{
    internal class Program
    {

        // Main Program
        
        private static void Main(string[] args)

            // Initial Conditions
            // 
        {
            var dragsters = new List<Dragster>();
            var isRunning = true;
            var isRacing = true;
            var areRacers = false;
            var devtool = false;
            var elapsedtime = 0.0;

            do
            {
                // Selecting number of Racers (1-3)
                // Getting Racers

                Console.WriteLine("Dragsters");
                Console.WriteLine("----------------");
                Console.WriteLine("Open Stats Menu with (1337)");
                Console.Write("How many Dragsters (1-3)? >> ");
                while (areRacers == false)
                {
                    try
                    {
                        var numerofRacers = int.Parse(Console.ReadLine());
                        if (numerofRacers == 1 || numerofRacers == 2 || numerofRacers == 3)
                        {
                            foreach (var _ in Enumerable.Range(0, numerofRacers))
                            {                                
                                Console.Clear();
                                Console.WriteLine("Dragsters");
                                Console.WriteLine("----------------");
                                Console.Write("Racer's name >> ");
                                var name = Console.ReadLine();
                                Console.Write("What is {0}'s g-force >> ", name);
                                var acceleration = double.Parse(Console.ReadLine());
                                var player = new Dragster(name, acceleration);
                                dragsters.Add(player);
                            }
                            areRacers = true;
                            break;
                        }
                        if (numerofRacers == 1337)
                            {
                                if (devtool)
                                {
                                    devtool = false;
                                    Console.Clear();
                                    Console.WriteLine("Dragsters");
                                    Console.WriteLine("----------------");
                                    Console.WriteLine("Stats Menu De-Activated");
                                    Console.Write("How many Dragsters (1-3)? >> ");
                                }
                                else if (devtool == false)
                                {
                                    devtool = true;
                                    Console.Clear();
                                    Console.WriteLine("Dragsters");
                                    Console.WriteLine("----------------");
                                    Console.WriteLine("Stats Menu Activated");
                                    Console.Write("How many Dragsters (1-3)? >> ");
                                }
                            }
                        else
                            {
                                throw new Exception();
                            }                        
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Dragsters");
                        Console.WriteLine("----------------");
                        Console.Write("How many Dragsters (1-3)? >Try Again> ");
                    }
                }

                // Racers collected
                // intermin screen

                Console.Clear();
                Console.WriteLine("Dragsters");
                Console.WriteLine("----------------");
                foreach (Dragster player in dragsters)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Name: {0}", player.Name);
                    Console.WriteLine("Acceleration: {0}g's", player.Acceleration);
                    Console.WriteLine("");
                }
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Console.Clear();
               
                // Race Start
                // 

                do
                {
                    // Drawing Map

                    string Distance(int n)
                    {
                        return new String('-', n);
                    }
                    Console.Clear();
                    Console.WriteLine("Dragsters");
                    Console.WriteLine("----------------");
                    Console.WriteLine(
                        "|||||    |10       |20       |30       |40       |50       |60       |70       |80       |90       ||");
                    Console.WriteLine(
                        "|||||    |         |         |         |         |         |         |         |         |         ||");
                    foreach (Dragster player in dragsters)
                    {
                        Console.WriteLine("                                                                                                       {0}", player.Name);
                        Console.WriteLine(Distance(Convert.ToInt32(player.CalculateDistance(elapsedtime))) + ">");
                        Console.WriteLine("");
                    }
                    Console.WriteLine(
                        "|||||    |         |         |         |         |         |         |         |         |         || ");
                    Console.WriteLine(
                        "|||||    |10       |20       |30       |40       |50       |60       |70       |80       |90       ||");

                    //Debug

                    if (devtool)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Stats");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Time: {0}", Convert.ToInt32(elapsedtime));
                        foreach (Dragster player in dragsters)
                        {
                            Console.WriteLine("{0}'s distance: {1}", player.Name, Convert.ToInt32(player.CalculateDistance(elapsedtime)));
                            Console.WriteLine("{0}'s acceleration: {1}", player.Name, player.Acceleration);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Time: {0}", Convert.ToInt32(elapsedtime));
                        Console.WriteLine("");
                    }

                    // Win Conditions

                    try
                    {
                        foreach (var player in dragsters)
                        {
                            if (player.CalculateDistance(elapsedtime) >= 100)
                            {
                                Console.WriteLine("{0} Won!", player.Name);
                                isRacing = false;
                            }                           
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You broke it");
                    }

                    // Moving Forward (.1sec)

                    if (isRacing)
                    {
                        elapsedtime = elapsedtime + 0.1;
                        Thread.Sleep(100);
                    }
                } while (isRacing);

                //
                // End race

                Thread.Sleep(1500);

                // Replay?

                Console.WriteLine("");
                Console.Write("Play Again? (Y/N)  ((N))>> ");
                    var replay = Console.ReadLine();
                    if (replay.ToLower() == "y")
                    {
                        elapsedtime = 0;
                        isRacing = true;
                        Console.Write("Same players? (Y/N)  ((N))>> ");
                        var again = Console.ReadLine();

                        // Same players

                        if (again.ToLower() == "y")
                        {
                            areRacers = true;
                            Console.Clear();
                        }

                        // New Players

                        if (again.ToLower() == "n" || again.ToLower() == "")
                        {
                            areRacers = false;
                            dragsters.Clear();
                            Console.Clear();
                        }
                    }
                    if (replay.ToLower() == "n" || replay.ToLower() == "")
                    {
                        isRunning = false;
                        Console.Clear();
                        Console.WriteLine("");
                        Console.Write("Closing Simulation");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".");
                    }
            } while (isRunning);
            //
            // Closing
        }

        //
        // Program End


// Class for Dragsters

        internal class Dragster
        {
            // Constructor

            public Dragster(string name, double acceleration)
            {
                Name = name;
                if (acceleration >= 0)
                {
                    Acceleration = acceleration;
                }
                else
                {
                    throw new Exception("Acceleration Cannot be less than 0");
                }
            }

            // Variables
            public string Name { get; set; }
            public double Acceleration { get; set; }


            // Method
            public double CalculateDistance(double elapsedtime)
            {
                if (elapsedtime >= 0)
                {
                    var distance = .5 * Acceleration * elapsedtime * elapsedtime;
                    if (distance > 100) distance = 100;
                    return distance;
                }
                else
                {
                throw new Exception("Time Cannot be less than 0");
                }
            }
        }
    }
}
