using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace BridgePattern
{
    public class BridgePatternExample
    {
        public static void RunExample()
        {
            // Construct a new refined bridge.
            var bridge = new AbstractBridge(new Bridge1());

            bridge.CallMethod1();
            bridge.CallMethod2();

            // You can change functionality by using a different bridge. This
            // won't require modifications from *both* sides of the fence.
            bridge.bridge = new Bridge2();

            bridge.CallMethod1();
            bridge.CallMethod2();

            Console.ReadKey();
        }
    }

    public interface IBridge
    {
        void Function1();
        void Function2();
    }

    public class Bridge1 : IBridge
    {
        public void Function1()
        {
            Console.WriteLine("Bridge1.Function1");
        }

        public void Function2()
        {
            Console.WriteLine("Bridge1.Function2");
        }
    }

    public class Bridge2 : IBridge
    {
        public void Function1()
        {
            Console.WriteLine("Bridge2.Function1");
        }

        public void Function2()
        {
            Console.WriteLine("Bridge2.Function2");
        }
    }

    public interface IAbstractBridge
    {
        void CallMethod1();
        void CallMethod2();
    }

    public class AbstractBridge : IAbstractBridge
    {
        public IBridge bridge;

        public AbstractBridge(IBridge bridge)
        {
            this.bridge = bridge;
        }

        public void CallMethod1()
        {
            this.bridge.Function1();
        }

        public void CallMethod2()
        {
            this.bridge.Function2();
        }
    }
}