using FlyweightPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public class Program
    {
        private static string Message = "No message entered".ToUpper();
        private static List<ConsoleColor> Colors = new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Yellow };

        public static void Main(string[] args)
        {
            // yeah, yeah, I know
            while (true)
            {
                Console.WriteLine("\nEnter a message:");

                var message = Console.ReadLine();
                Console.Clear();
                if (message != null && message.Equals("bye", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (string.IsNullOrEmpty(message))
                {
                    message = Message;
                }

                Console.Write($"Message entered: {message}\n");
                Console.Write($"Message with colors and character positions: ");
                PrintMessageRandomColors(message);
                Console.WriteLine("\n\n");
                DisplayOptimizationStatistics(message);
            }
        }

        private static void PrintMessageRandomColors(string message)
        {
            Random rnd = new Random();
            int x = 0;
            int y = 2;

            message.ToList().ForEach(c => {
                if(c == ' ')
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(c);
                }
                else
                {
                    CharacterFactory.GetOrAddCharacter(c).WriteCharacter(x, y, Colors[rnd.Next(3)]);
                }

                x++;
                if(x > 50)
                {
                    y++;
                    x = 0;
                }

                });
        }

        private static void DisplayOptimizationStatistics(string message)
        {
            Dictionary<char,int> characterCounts = new Dictionary<char, int>();
            foreach (var characterCount in message.GroupBy(c => c).Select(c => new { character = c.Key, characterCount = c.Count()}))
            {
                characterCounts.Add(characterCount.character, characterCount.characterCount);
            }

            var colorSize = sizeof(ConsoleColor);
            var positionSize = sizeof(int) + sizeof(int);

            var messageSize = message.Length;

            var unoptimizedSize = message.Length + (message.Length * colorSize) + (message.Length * positionSize);
            var optimizedSize = characterCounts.Count + colorSize + positionSize;

            Console.WriteLine($"Without Flyweight:");
            Console.WriteLine($"\tCharacter Count: {messageSize}");
            // color size + position size + 1 (for the character)
            Console.WriteLine($"\tIntrinsic Size Per Character: {colorSize + positionSize + 1} bytes");
            Console.WriteLine($"\t\tColor Size: {colorSize} bytes");
            Console.WriteLine($"\t\tPosition Size: {positionSize} bytes");
            Console.WriteLine($"\t\tCharacter Size: 1 byte");
            Console.WriteLine($"Total (<character count> * (<color size> + <position size>)): {unoptimizedSize} bytes");

            Console.WriteLine($"\nWith Flyweight:");
            Console.WriteLine($"\tCharacter Count: {characterCounts.Count}");
            // distinct character count + color size + position size
            Console.WriteLine($"\tIntrinsic Size Per Character: {1} byte");
            Console.WriteLine($"\tColor Size: {colorSize} bytes");
            Console.WriteLine($"\tPosition Size: {positionSize} bytes");
            Console.WriteLine($"Total (<distinct character count> + <color size> + <position size>): {optimizedSize} bytes");
        }
    }
}
