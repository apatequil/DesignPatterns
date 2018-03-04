using System;

namespace MediatorPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mediator = new AirTrafficMediator();

            var plane1 = new Plane(1, mediator);
            var plane2 = new Plane(2, mediator);

            mediator.RegisterPlane(plane1);
            mediator.RegisterPlane(plane2);

            Console.WriteLine("Attempting to land plane 1...");
            if (plane1.CanLand())
            {
                plane1.Landing();
                Console.ReadLine();
            }

            Console.WriteLine("Attempting to land plane 2...");
            if (plane2.CanLand())
            {
                plane2.Landing();
                Console.ReadLine();
            }

            plane1.Landed();
            Console.ReadLine();

            Console.WriteLine("Attempting to land plane 2...");
            if (plane2.CanLand())
            {
                plane2.Landing();
                plane2.Landed();
            }

            Console.ReadLine();
        }
    }
}
