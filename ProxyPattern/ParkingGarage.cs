using System;

namespace ProxyPattern
{
    public class ParkingGarage : IParkingLot
    {
        private Parker _parker;
        private SurfaceLot _surfaceLot;
        public ParkingGarage(Parker parker)
        {
            _parker = parker;
            _surfaceLot = new SurfaceLot();
        }

        public void Park()
        {
            if(_parker.IsContractor)
            {
                Console.WriteLine("\nContractors are not allowed to park in the garage.");
                Console.WriteLine("> You were redirected to and parked in the surface lot.");
                _surfaceLot.Park();
            }
            else
            {
                Console.WriteLine($"> You parked in the garage.");
            }
        }
    }
}
