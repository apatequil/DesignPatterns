using AbstractFactory.Meat.Interfaces;

namespace AbstractFactory.Factory
{
    public interface IMeatCutFactory // <- Abstract Factory
    {
        string Name { get; }
        ICheapCut GetCheapCut();
        IAverageCut GetAverageCut();
        IExpensiveCut GetExpensiveCut();
    }
}
