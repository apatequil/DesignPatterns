using AbstractFactory.Meat.Interfaces;
using AbstractFactory.Meat;

namespace AbstractFactory.Factory
{
    public class SkilletFactory : IMeatCutFactory
    {
        public string Name { get => "Skillets"; }

        public IAverageCut GetAverageCut()
        {
            return new ShoulderPetiteTenderloin();
        }

        public ICheapCut GetCheapCut()
        {
            return new TopLoinSteak();
        }

        public IExpensiveCut GetExpensiveCut()
        {
            return new RoundTipSteak();
        }
    }
}