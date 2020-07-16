using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class ProgramUI
    {
        protected readonly BadgeRepository badgeRepository = new BadgeRepository();

        public void Run()
        {
            SeedDictionary();
            
            StartMenu();
            
        }


        private void StartMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- KOMODO SECURITY ----");
                Console.WriteLine();
                
                Console.WriteLine("Hello Security Admin, what would you like to do? \n" +
                    " \n" +
                    "1. Add A Badge \n" +
                    "2. Edit a Badge \n" +
                    "3. List all Badges \n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        Console.Clear();
                        //We need to show all menu items
                        break;
                    case "2":
                        EditABadge();
                        Console.ReadLine();
                        Console.Clear();
                        // Edit a badge
                        break;
                    case "3":
                        PrintDictionary();
                        Console.ReadLine();
                        Console.Clear();
                        // List All Badges
                        break;
                    case "4":
                        // Exit 
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 3 \n" +
                            "To continue, press any key");
                        Console.ReadKey();
                        break;
                }

                Console.Clear(); 
            }

        }

        public void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("---- KOMODO SECURITY ----");
            Console.WriteLine();

            List<string> doorNames = new List<string>();
            
            Console.WriteLine("What is the BadgeID?");
            string badgeNumber = Console.ReadLine();
            // need to add 
            bool running = true;
            while (running)
            {
                Console.WriteLine("What room needs to be added?");
                string roomID = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Would you like to add another badge? (y/n)");
                string userInput = Console.ReadLine();
                if (userInput == "n")
                {
                    Console.WriteLine("Badge has been completed. Press any key to go back to the main menu.");
                    Console.ReadLine();
                    running = false;
                } 
                else
                {
                  
                 }

                doorNames.Add(roomID);
                
            }
            string roomsOnCard = string.Join(",", doorNames);
            badgeRepository.AddContentToDictionary(badgeNumber,roomsOnCard);
        }

        private void SeedDictionary()
        {
            
            List<string> itemOneList = new List<string>();
            itemOneList.Add("A7");
            string itemOne = "12345";
            string roomsOnCard = string.Join(",", itemOneList);

            
            List<string> itemTwoList = new List<string>();
            itemTwoList.Add("A1");
            itemTwoList.Add("A4");
            itemTwoList.Add("B1");
            itemTwoList.Add("B2");
            string itemTwo = "22345";
            string roomsOnCard2 = string.Join(",", itemTwoList);

            
            List<string> itemThreeList = new List<string>();
            itemThreeList.Add("A4");
            itemThreeList.Add("A5");
            string itemThree = "32345";
            string roomsOnCard3 = string.Join(",", itemThreeList);

            badgeRepository.AddContentToDictionary(itemOne, roomsOnCard);
            badgeRepository.AddContentToDictionary(itemTwo, roomsOnCard2);
            badgeRepository.AddContentToDictionary(itemThree, roomsOnCard3);
        }

        public void PrintDictionary()
        {
            Console.Clear();

            Console.WriteLine("---- KOMODO SECURITY ----");
            Console.WriteLine();


            var header = String.Format("{0,-20}{1,-20}",
                              "BadgeID", "RoomAccess" );
            Console.WriteLine(header);

            badgeRepository.PrintDictionary();
           
        }

        public void EditABadge()
        {

            Console.Clear();
            Console.WriteLine("---- KOMODO SECURITY ----");
            Console.WriteLine();

            
            //Need to delete, need to add

            badgeRepository.CallDictionaryValue();


        }
    }
}