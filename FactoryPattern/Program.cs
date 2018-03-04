using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What console would you like to play?");
                var consoleToPlay = Console.ReadLine();

                var console = ConsoleFactory.GetConsole(consoleToPlay);

                console.Play();

                Console.WriteLine();
            }
        }

        public interface IConsole
        {
            void Play();
        }

        public class NintendoSwitch : IConsole
        {
            public void Play()
            {
                Console.WriteLine("Playing The Legend of Zelda: Breath of the Wild");
                Console.ReadKey();
            }
        }

        public class NintendoWii : IConsole
        {
            public void Play()
            {
                Console.WriteLine("Playing Super Mario Galaxy");
                Console.ReadKey();
            }
        }

        public class PlayStation : IConsole
        {
            public void Play()
            {
                Console.WriteLine("Playing Uncharted");
                Console.ReadKey();
            }
        }

        public class Xbox : IConsole
        {
            public void Play()
            {
                Console.WriteLine("Playing Halo 2");
                Console.ReadKey();
            }
        }

        public class ConsoleFactory
        {
            public static IConsole GetConsole(string consoleName)
            {
                if (consoleName == null)
                {
                    return null;
                }
                if (consoleName == "Nintendo Switch")
                {
                    return new NintendoSwitch();
                }
                if (consoleName == "Nintendo Wii")
                {
                    return new NintendoWii();
                }
                if (consoleName == "Playstation")
                {
                    return new PlayStation();
                }
                if (consoleName == "Xbox")
                {
                    return new Xbox();
                }

                throw new Exception("Console Does Not Exist");
            }
        }
    }
}
