using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FacadeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var partyPlanner = new PartyPlannerFacade();

            partyPlanner.PlanParty(75, true, new DateTime(2017, 8, 9, 20, 0, 0));
            Console.ReadKey();
        }

        private class PartyPlannerFacade
        {
            private readonly CateringService _cateringService;
            private readonly EventSpaceBooker _eventSpaceBooker;
            private readonly InvitationSender _invitationSender;

            public PartyPlannerFacade()
            {
                _cateringService = new CateringService();
                _eventSpaceBooker = new EventSpaceBooker();
                _invitationSender = new InvitationSender();
            }

            public void PlanParty(int numberOfGuests, bool alcohol, DateTime partyTime)
            {
                _cateringService.OrderFood(numberOfGuests, alcohol);
                var eventSpace = _eventSpaceBooker.BookEventSpace(numberOfGuests);
                _invitationSender.SendInvitations(numberOfGuests, eventSpace, partyTime);
            }
        }

        private class CateringService
        {
            public void OrderFood(int numberOfGuests, bool alcohol)
            {
                Console.WriteLine($"Ordering food for {numberOfGuests} guests...");

                if (alcohol)
                {
                    Console.WriteLine($"Ordering alcohol for {numberOfGuests} guests...");
                }
            }
        }

        private class EventSpaceBooker
        {
            public string BookEventSpace(int numberOfGuests)
            {
                Console.WriteLine($"Booking event space for {numberOfGuests} guests...");

                if (numberOfGuests < 3)
                {
                    Console.WriteLine("Phone Booth Booked!");
                    return "Phone Booth";
                }
                if (numberOfGuests >= 3 && numberOfGuests < 50)
                {
                    Console.WriteLine("Hotel Suite Booked!");
                    return "Hotel Suite";
                }
                if (numberOfGuests >= 50 && numberOfGuests < 300)
                {
                    Console.WriteLine("Banquet Hall Booked!");
                    return "Banquet Hall";
                }
                if (numberOfGuests >= 300)
                {
                    Console.WriteLine("Airline Hangar Booked!");
                    return "Airline Hangar";
                }

                throw new Exception("COULD NOT FIND EVENT SPACE.");
            }
        }

        private class InvitationSender
        {
            public void SendInvitations(int numberOfGuests, string eventSpace, DateTime partyTime)
            {
                Console.WriteLine($"Inviting {numberOfGuests} guests to {eventSpace} at {partyTime}!");
            }
        }
    }
}
