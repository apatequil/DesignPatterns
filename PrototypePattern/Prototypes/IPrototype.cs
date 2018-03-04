using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Prototypes
{
    public interface IPrototype
    {
        string Name { get; set; }
        IPrototype Clone();
    }
}
