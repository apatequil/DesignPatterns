using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern
{
    public class AirTrafficMediator
    {
        private readonly List<Plane> _planes = new List<Plane>();

        public void RegisterPlane(Plane plane)
        {
            _planes.Add(plane);
        }

        public bool CanPlaneLand()
        {
            return !_planes.Any(plane => plane.IsLanding);
        }
    }
}
