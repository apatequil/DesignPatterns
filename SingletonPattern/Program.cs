using System;
using System.Threading;

using SingletonPattern.Singletons;

namespace SingletonPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Beginning Singleton Test:");

            TestNaiveSingleton();

            Console.ReadLine();
        }

        private static void TestNaiveSingleton()
        {
            // Request an instance of the single to begin. This will check if one
            // already exists and return that. If one doesn't exist, it will create
            // one and return the new instance
            var instance = Singleton.Instance;
            
            instance.PrintSummary();

            // Just to prove that it won't create additional instances of our Singleton
            // and therefore defeat the purpose, we'll grab an instance 10 more times
            // and output the final creation and retrieval stats
            Console.WriteLine("\nNow we'll request the instance 10 more times to prove it will only ever use the first instance.\n");
            
            for(int i = 0; i < 10; i++)
            {
                instance = Singleton.Instance;
            }
            
            instance.PrintSummary();
        }

        private static void Sleep()
        {
            Thread.Sleep(50);
        }
    }
}
