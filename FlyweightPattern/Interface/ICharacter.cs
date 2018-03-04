using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.Interface
{
    public interface ICharacter
    {
        char Character { get; }

        void WriteCharacter(int left, int top, ConsoleColor fontColor);
    }
}
