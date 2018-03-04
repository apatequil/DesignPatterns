using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Meat.Interfaces
{
    public interface ICheapCut
    {
        string Name { get; }
    }

    public interface IAverageCut
    {
        string Name { get; }
    }

    public interface IExpensiveCut
    {
        string Name { get; }
    }
}
