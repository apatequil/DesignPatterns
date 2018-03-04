using FlyweightPattern.Interface;
using System;

namespace FlyweightPattern.Flyweights
{
    public abstract class BaseCharacter : ICharacter
    {
        protected readonly char _character;
        public virtual char Character
        {
            get { return _character; }
        }

        public void WriteCharacter(int left, int top, ConsoleColor fontColor)
        {
            var restoreColor = Console.ForegroundColor;
            var restoreLeft = Console.CursorLeft;
            var restoreTop = Console.CursorTop;

            // Use extrinsic information
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = fontColor;

            // Use intrinsic information
            Console.Write(Character);


            // Return the console to the original state
            //Console.SetCursorPosition(restoreLeft, restoreTop);
            Console.ForegroundColor = restoreColor;

        }
    }
}
