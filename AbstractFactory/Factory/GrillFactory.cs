using AbstractFactory.Meat.Interfaces;
using AbstractFactory.Meat;

namespace AbstractFactory.Factory
{
    public class GrillFactory : IMeatCutFactory
    {
        public string Name { get => "Grills"; }

        public IAverageCut GetAverageCut()
        {
            return new ChuckEyeSteak();
        }

        public ICheapCut GetCheapCut()
        {
            return new ShoulderSteak();
        }

        public IExpensiveCut GetExpensiveCut()
        {
            return new RoundTipSteak();
        }
    }
}
