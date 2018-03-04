using AbstractFactory.Meat.Interfaces;
using AbstractFactory.Meat;
using System;

namespace AbstractFactory.Factory
{
    public class RoastFactory : IMeatCutFactory
    {
        public string Name { get => "Roasts"; }

        public IAverageCut GetAverageCut()
        {
            return new TriTipRoast();
        }

        public ICheapCut GetCheapCut()
        {
            return new ChuckPotRoast();
        }

        public IExpensiveCut GetExpensiveCut()
        {
            return new TenderloinRoast();
        }
    }
}
