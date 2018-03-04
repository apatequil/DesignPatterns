using System;
using System.Collections.Generic;
using System.Diagnostics;
using PrototypePattern.Prototypes;

namespace PrototypePattern
{
    public enum StrategyType { Traditional = 1, Prototype = 2, Exit = 3 }

    public class Program
    {
        private static bool isRunning = true;
        private static int objectCount = 3;
        private static List<IPrototype> myObjects = new List<IPrototype>();

        public static void Main(string[] args)
        {
            ApplicationLoop();
        }

        private static void CreateObjects(StrategyType strategyType)
        {
            PrintString($"Creating 3 objects ", includeNewLine: false);

            if (strategyType == StrategyType.Traditional)
            {
                PrintString("traditionally");
            }
            else
            {
                PrintString("with prototypes");
            }

            Stopwatch overallTimer = new Stopwatch();
            overallTimer.Start();

            // Print out ui skeleton
            for(int i = 1; i <= objectCount; i++)
            {
                PrintString($" Object {i}: ");
            }

            // Reset the cursor to the first object
            Console.SetCursorPosition(11, Console.CursorTop - 3);

            // Create the objects
            for (int i = 0; i < objectCount; i++)
            {
                Console.Write("Creating...");
                // Time each object's creation
                Stopwatch sw = new Stopwatch();
                sw.Start();

                if(strategyType == StrategyType.Prototype && myObjects.Count > 0)
                {
                    myObjects.Add(myObjects[0].Clone());
                    myObjects[i].Name = $"Object {i + 1}";
                }
                else
                {
                    myObjects.Add(new MyObject($"Object {i + 1}"));
                }
                
                sw.Stop();
                Console.SetCursorPosition(11, Console.CursorTop);
                PrintString($"Object {i+1} created in {sw.Elapsed.TotalMilliseconds} ms", ConsoleColor.Yellow, false);
                
                // Move cursor to next line
                Console.SetCursorPosition(11, Console.CursorTop + 1);
            }
            
            overallTimer.Stop();
            PrintString($"\n {objectCount} objects created in {overallTimer.Elapsed.TotalMilliseconds} milliseconds\n", ConsoleColor.Green);
            
            myObjects.Clear();
        }

        private static void ApplicationLoop()
        {
            while(isRunning)
            {
                var strategyType = GetStrategyType();

                if(strategyType == StrategyType.Exit)
                {
                    isRunning = false;
                }
                else
                {
                    CreateObjects(strategyType);
                }
            }
        }

        private static StrategyType GetStrategyType()
        {
            var input = default(int);
            // Get run mode from user along with time to create an object
            PrintString("Which type of strategy would you like to run?\n");
            PrintString(" 1) Traditional Creation");
            PrintString(" 2) Prototype Creation");
            PrintString(" 3) Exit");

            bool validInput = false;
            while (!validInput)
            {
                PrintString("\nEnter number: ", includeNewLine: false);
                validInput = int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= 3;
                if (!validInput)
                {
                    PrintString("Invalid Input", ConsoleColor.Red);
                }
            }

            // The user has selected a valid choice, return the type chosen
            return (StrategyType)input;
            //switch(input)
            //{
            //    case 1:
            //        return StrategyType.Traditional;
            //    case 2:
            //        return StrategyType.Prototype;
            //    default:
            //        return StrategyType.Exit;
            //}
        }

        private static void PrintString(string output, ConsoleColor color = ConsoleColor.White, bool includeNewLine = true)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(output);

            if (includeNewLine)
            {
                Console.WriteLine();
            }

            // Revert to original color for future prints
            Console.ForegroundColor = originalColor;
        }
    }
}
