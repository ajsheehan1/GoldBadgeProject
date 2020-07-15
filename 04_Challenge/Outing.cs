using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerPerson {
            get
            {
                decimal CostPerPerson = TotalCost / NumberOfAttendees;
                return CostPerPerson;
            }
        }

        public Outing() { }

        public Outing(EventType typeOfEvent, int numberOfAttendees, DateTime dateOfEvent, decimal totalCost)
        {
            TypeOfEvent = typeOfEvent;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            TotalCost = totalCost;


        }

        

        
    }
}
