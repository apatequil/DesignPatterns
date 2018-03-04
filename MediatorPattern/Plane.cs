using System;

namespace MediatorPattern
{
    public class Plane
    {
        private int Id { get; }
        private readonly AirTrafficMediator _airTrafficMediator;
        public bool IsLanding { get; private set; }

        public Plane(int id, AirTrafficMediator airTrafficMediator)
        {
            Id = id;
            _airTrafficMediator = airTrafficMediator;
        }

        public bool CanLand()
        {
            var canLand = _airTrafficMediator.CanPlaneLand();
            Console.WriteLine(canLand ? $"Plane {Id} can land." : $"Plane {Id} cannot land.");

            return canLand;
        }

        public void Landing()
        {
            IsLanding = true;
            Console.WriteLine($"Plane {Id} Landing...");
        }

        public void Landed()
        {
            IsLanding = false;
            Console.WriteLine($"Plane {Id} Landed.");
        }
    }
}
