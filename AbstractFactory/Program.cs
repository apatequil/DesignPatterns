using AbstractFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        public static void Main(string[] args)
        {
            MeatWrangler.PrintMeatCuts<GrillFactory>();
            MeatWrangler.PrintMeatCuts<RoastFactory>();
            MeatWrangler.PrintMeatCuts<SkilletFactory>();


            Console.ReadLine();
        }
    }
}
