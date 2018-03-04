using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    public class SurfaceLot : IParkingLot
    {
        public void Park()
        {
            Console.WriteLine("> You parked in the surface lot.");
        }
    }
}
