using AbstractFactory.Meat.Interfaces;

namespace AbstractFactory.Meat
{
    public class ChuckPotRoast : ICheapCut
    {
        public string Name
        {
            get => "Chuck 7-Bone Pot Roast";
        }
    }

    public class ShoulderSteak : ICheapCut
    {
        public string Name
        {
            get => "Shoulder Steak";
        }
    }

    public class TopLoinSteak : ICheapCut
    {
        public string Name
        {
            get => "TopLoinSteak";
        }
    }

    public class ShoulderPetiteTenderloin : IAverageCut
    {
        public string Name
        {
            get => "Shoulder Petite Tenderloin";
        }
    }

    public class ChuckEyeSteak : IAverageCut
    {
        public string Name
        {
            get => "Chuck Eye Steak";
        }
    }

    public class TriTipRoast : IAverageCut
    {
        public string Name
        {
            get => "Tri-Tip Roast";
        }
    }

    public class RoundTipSteak : IExpensiveCut
    {
        public string Name
        {
            get => "Round Tip Steak";
        }
    }

    public class TenderloinSteak : IExpensiveCut
    {
        public string Name
        {
            get => "Tenderloin Steak";
        }
    }

    public class TenderloinRoast : IExpensiveCut
    {
        public string Name
        {
            get => "Tenderloin Roast";
        }
    }
}
