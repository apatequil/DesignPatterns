using AbstractFactory.Factory;
using System;

namespace AbstractFactory
{
    public static class MeatWrangler
    {
        public static void PrintMeatCuts<T>() where T : IMeatCutFactory, new()
        {
            var factory = new T();

            var cheapMeat = factory.GetCheapCut();
            var averageMeat = factory.GetAverageCut();
            var expensiveMeat = factory.GetExpensiveCut();

            Console.WriteLine($"Meats for {factory.Name}:");
            Console.WriteLine($"\tCheaper:\t{cheapMeat.Name}");
            Console.WriteLine($"\tAverage:\t{averageMeat.Name}");
            Console.WriteLine($"\tExpensive:\t{expensiveMeat.Name}\n");
        }
    }
}
