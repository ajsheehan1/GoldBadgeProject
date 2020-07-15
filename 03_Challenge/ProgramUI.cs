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
            badgeRepository.PrintDictionary();
            StartMenu();
            
        }


        private void StartMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- KOMODO INSURANCE ----");
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
                        
                        Console.Clear();
                        // Edit a badge
                        break;
                    case "3":
                        badgeRepository.PrintDictionary();
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
            List<string> doorNames = new List<string>();
            Badge badgeNumber = new Badge();
            Console.WriteLine("What is the BadgeID?");
            badgeNumber.BadgeID = Console.ReadLine();
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
                    Console.Clear();
                 }
                doorNames.Add(roomID);
            }

            badgeRepository.AddContentToDictionary(badgeNumber,doorNames);
        }

        private void SeedDictionary()
        {
            Badge itemOne = new Badge();
            List<string> itemOneList = new List<string>();
            itemOneList.Add("A7");
            itemOne.BadgeID = "12345";


            Badge itemTwo = new Badge();
            List<string> itemTwoList = new List<string>();
            itemTwoList.Add("A1");
            itemTwoList.Add("A4");
            itemTwoList.Add("B1");
            itemTwoList.Add("B2");
            itemTwo.BadgeID = "22345";

            Badge itemThree = new Badge();
            List<string> itemThreeList = new List<string>();
            itemThreeList.Add("A4");
            itemThreeList.Add("A5");
            itemThree.BadgeID = "32345";

            badgeRepository.AddContentToDictionary(itemOne, itemOneList);
            badgeRepository.AddContentToDictionary(itemTwo, itemTwoList);
            badgeRepository.AddContentToDictionary(itemThree, itemThreeList);
        }

        /*public void PrintDictionary()
        {
            //List<KeyValuePair<BadgeNumber, List<string>>> allItemsInList = badgeRepository.PrintDictionary();

            var header = String.Format("{0,-9}{1,-12}",
                              "BadgeID", "Room Access");
            Console.WriteLine(header);

            foreach (KeyValuePair<BadgeNumber, List<string>> keyValue in )
            {

                Console.WriteLine("Key: {0}, Value: {1}",
               keyValue.Key.BadgeID, keyValue.Value);
            }

        }*/
    }
}