using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    class ProgramUI
    {
        private readonly OutingRepository outingRepo = new OutingRepository();
        public void Run()
        {
            OutingContentList();
            StartMenu();
        }


        private void StartMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- KOMODO OUTINGS ----");
                Console.WriteLine();

                Console.WriteLine("Welcome to the outings summary page please select from the options below: \n" +
                    " \n" +
                    "1. Display All Outings \n" +
                    "2. Add an Outing \n" +
                    "3. Filter Cost By Outing \n" +
                    "4. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        DisplayAll();
                        Console.Clear();

                        break;
                    case "2":
                        AddOutingToTheList();
                        Console.Clear();

                        break;
                    case "3":
                        CostByOuting();
                        Console.Clear();
                        // we need to delete existing items
                        break;
                    case "4":
                        // Exit 
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4 \n" +
                            "To continue, press any key");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CostByOuting()
        {
            Console.WriteLine("---- KOMODO OUTINGS FILTERED VIEW----");
            Console.WriteLine();

            Console.WriteLine("Please select which event's cost data you would like to display:\n" +
                "1) Golf \n" +
                "2) Bowling \n" +
                "3) Amusement Park \n" +
                "4) Concert \n");
            string filteredViewInput ="";
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                filteredViewInput = "Golf";
            }
            else if (userInput == 2)
            {
                filteredViewInput = "Bowling";

            }
            else if (userInput == 3)
            {
                filteredViewInput = "Amusement Park";
            }
            else if (userInput == 4)
            {
                filteredViewInput = "Concert";
            }
            else
            {
                Console.WriteLine("Sorry, no menu item matches your selection.");
            }
            
            Console.Clear();

            Console.WriteLine("---- KOMODO OUTINGS FILTERED VIEW----");
            Console.WriteLine();

            var header = String.Format("{0,-15}{1,-10}{2,-15}{3,-15}{4,-15}",
                              "EventType", "Attendees", "DateOfEvent", "CostPerPerson", "TotalCost");
            Console.WriteLine(header);
            Console.WriteLine();

            decimal grandTotalCost = 0;
            int attendees = 0;
            decimal grandTotalCostPerPerson = 0;
            List<Outing> listofOutingItems = outingRepo.GetAllOutingInfo();

            foreach (Outing outing in listofOutingItems)
            {

                if (filteredViewInput == outing.TypeOfEvent.ToString())
                {

                    List<Outing> filteredList = new List<Outing>();
                    filteredList.Add(outing);

                    foreach (Outing content in filteredList)
                    {
                        DisplayFormat(content);
                        attendees = attendees + outing.NumberOfAttendees;
                        grandTotalCost = grandTotalCost + outing.TotalCost;
                    }
                    
                }
                else
                {
                    
                }
                
            }
            if (grandTotalCost > 0)
            {
                grandTotalCostPerPerson = grandTotalCost / attendees;
                string formattedGrandTotalPerPerson = String.Format("{0:C2}", grandTotalCostPerPerson);
                string formattedGrandTotal = String.Format("{0:C2}", grandTotalCost);
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine($"Grand Total:   {attendees}                      {formattedGrandTotalPerPerson}         {formattedGrandTotal}");
                
                
            }
            else
            {
                Console.WriteLine("Sorry, no results found, please try again.");
            }
            Console.ReadLine();
        }


        private void AddOutingToTheList()
        {
            Console.WriteLine("---- KOMODO OUTINGS ----");
            Console.WriteLine();

            Outing outing = new Outing();

            Console.WriteLine("Please select number that corresponds with the type of event:\n" +
                "1) Golf \n" +
                "2) Bowling \n" +
                "3) Amusement Park \n" +
                "4) Concert \n");
            string outingTypeInput = Console.ReadLine();
            int outingID = int.Parse(outingTypeInput);
            outing.TypeOfEvent = (EventType)outingID;
            Console.WriteLine();

            Console.WriteLine("How many attendees were there?");
            outing.NumberOfAttendees = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("What was the date of event? (YYYY, MM, DD)");
            outing.DateOfEvent = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("What was the total cost?");
            outing.TotalCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            outingRepo.AddContentToOutingList(outing);
        }
        private void DisplayAll()
        {
            Console.WriteLine("---- KOMODO OUTINGS ----");
            Console.WriteLine();

            var header = String.Format("{0,-15}{1,-10}{2,-15}{3,-15}{4,-15}",
                              "EventType", "Attendees", "DateOfEvent", "CostPerPerson", "TotalCost");
            Console.WriteLine(header);
            Console.WriteLine();

            List<Outing> listofOutingItems = outingRepo.GetAllOutingInfo();

            foreach (Outing content in listofOutingItems)
            {
                DisplayFormat(content);
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayFormat(Outing outing)
        {
            string totalCost = String.Format("{0:C2}", outing.TotalCost);
            string costPerPerson = String.Format("{0:C2}", outing.CostPerPerson);
            var outingInfo = String.Format("{0,-15}{1,-10}{2,-15}{3,-15}{4,-15}",
                              outing.TypeOfEvent, outing.NumberOfAttendees, outing.DateOfEvent.ToString("MM/dd/y"), costPerPerson, totalCost);
            Console.WriteLine(outingInfo);

        }

        private void OutingContentList()
        {
            Outing itemOne = new Outing(EventType.AmusementPark, 3000, new DateTime(2019, 06, 22), 50000m);
            Outing itemTwo = new Outing(EventType.Concert, 50, new DateTime(2019, 06, 30), 68.33m);
            Outing itemThree = new Outing(EventType.Concert, 600, new DateTime(2019, 08, 30), 10000m);

            outingRepo.AddContentToOutingList(itemOne);
            outingRepo.AddContentToOutingList(itemTwo);
            outingRepo.AddContentToOutingList(itemThree);

        }
    }
}
