using System;
using System.Collections.Generic;
using System.Linq;

namespace ProxyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Parking Access Proxy";
            var parkers = GenerateParkers();
            RefreshConsole(parkers);

            HandleParkers(parkers);

            Console.WriteLine("All parkers have parked. Press any key to exit.");
            Console.ReadKey();
        }

        public static void HandleParkers(Queue<Parker> parkers)
        {
            PrintQueue(parkers);
            int parkerCount = parkers.Count;
            Console.CursorTop = 4;
            while (parkers.Count > 0)
            {
                var parker = parkers.Dequeue();
                var parkerType = parker.IsContractor ? "Contractor" : "Employee";
                
                Console.WriteLine($"\nWould you like to park in the surface lot or parking garage?");
                Console.Write("Enter s or g:");
                bool validResponse = false;

                IParkingLot parkingLot = null;

                while(!validResponse)
                {
                    var enteredText = Console.ReadLine().Trim().ToLower();
                    if(!String.Equals(enteredText, "s", StringComparison.OrdinalIgnoreCase)
                        && !String.Equals(enteredText, "g", StringComparison.OrdinalIgnoreCase))
                    {
                        var currentPosition = Console.CursorTop;
                        RefreshConsole(parkers);
                        Console.SetCursorPosition(0, 7);
                        Console.Write("Invalid input. Please enter s or g:");
                    }
                    else
                    {
                        validResponse = true;

                        if(String.Equals(enteredText, "g", StringComparison.OrdinalIgnoreCase))
                        {
                            parkingLot = new ParkingGarage(parker);
                        }
                        else
                        {
                            parkingLot = new SurfaceLot();
                        }
                    }
                }

                parkingLot?.Park();

                parkerCount--;

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                RefreshConsole(parkers);
                Console.CursorTop = 4;
            }
        }

        private static Queue<Parker> GenerateParkers()
        {
            Random random = new Random(new Guid().GetHashCode());
            Queue<Parker> parkers = new Queue<Parker>();

            for(int i = 0; i < 20; i++)
            {
                parkers.Enqueue(new Parker { IsContractor = random.NextDouble() + 0.5 > 1 ? false : true });
            }

            return parkers;
        }

        private static void PrintHeader()
        {
            var headerLines = new List<string>();
            headerLines.Add(">Booting Parking Access Proxy");
            headerLines.Add(">Booting Successful");
            headerLines.Add("\n>Welcome to the Parking Access Proxy.");
            headerLines.Add(new String('=', Console.BufferWidth));

            Console.BackgroundColor = ConsoleColor.Blue;
            
            for(int x = 0; x < headerLines.Count; x++)
            {
                Console.Write(new String(' ', Console.BufferWidth));
            }

            Console.SetCursorPosition(0, 0);
            headerLines.ForEach(Console.WriteLine);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void PrintQueue(Queue<Parker> parkers)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;

            var queueWidth = 17;            
            var leftMargin = Console.BufferWidth - queueWidth;

            // Clear the old queue
            for (int i = 0; i < Console.LargestWindowHeight; i++)
            {
                Console.SetCursorPosition(leftMargin, i + 2);
                Console.Write("|               |");
            }

            // Print the queue
            Console.SetCursorPosition(leftMargin, 0);
            Console.Write("|     Queue     |");
            Console.SetCursorPosition(leftMargin, 1);
            Console.Write(new String('-', queueWidth));

            var listOfParkers = parkers.ToArray();
            for(int i = 0; i < listOfParkers.Length; i++)
            {
                // Shift single-digits right one to keep alignment with doubles
                var indexSpaceCount = i+1 < 10 ? 1 : 0;
                var index = new String(' ', indexSpaceCount) + $"{ i + 1}";
                var parkerType = listOfParkers[i].IsContractor ? "Contractor" : "Employee";
                var parkerString = $"{index}. {parkerType}";
                Console.SetCursorPosition(leftMargin+1, i+2);
                Console.Write($"{parkerString}");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void RefreshConsole(Queue<Parker> parkers)
        {
            Console.Clear();
            PrintHeader();
            PrintQueue(parkers);
            Console.SetWindowPosition(0, 0);
        }
    }
}
