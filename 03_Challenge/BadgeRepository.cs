using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class BadgeRepository
    {

        protected readonly Dictionary<string, string> badgeDict = new Dictionary<string, string>();

        public bool AddContentToDictionary(string badgeID, string roomNames)
        {
            int startingCount = badgeDict.Count;
            badgeDict.Add(badgeID, roomNames);
            bool wasAdded = (badgeDict.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public void PrintDictionary()
        {


            foreach (KeyValuePair<string, string> pair in badgeDict)
            {

                var badges = string.Join(",", pair.Value);
                string output = string.Format("{0,-20}{1,-20}", pair.Key, badges);
                Console.WriteLine(output);

            }
        }

        public void CallDictionaryValue()
        {
            PrintDictionary();

            Console.WriteLine("Please enter the badge ID you would like to edit:");
            string userInput = Console.ReadLine();

            if (badgeDict.TryGetValue(userInput, out string value))
            {

                Console.WriteLine("You have selected: Badge ID = {0} Rooms = {1}.", userInput, value);
                List<string> badgeList = value.Split(',').ToList();


                Console.WriteLine("Please select (1) to delete a room on this card and (2) to add a room to this card: ");
                string nextUserInput = Console.ReadLine();

                // Delete
                switch (nextUserInput)
                {
                    case "1":

                        //delete a room

                        Console.WriteLine("What room would you like to remove?");
                        string deleteRoom = Console.ReadLine();
                        badgeList.Remove(deleteRoom);
                        Console.WriteLine($"{deleteRoom} successfully removed.");
                        string updatedValue = string.Join(",", badgeList);
                        badgeDict[userInput] = updatedValue;

                        break;
                    case "2":
                        Console.WriteLine("What room would you like to add?");
                        string addRoom = Console.ReadLine();
                        badgeList.Add(addRoom);
                        Console.WriteLine($"{addRoom} successfully added.");
                        string addedValue = string.Join(",", badgeList);
                        badgeDict[userInput] = addedValue;


                        // Add a room
                        break;



                }




            }






        }
    }
}
