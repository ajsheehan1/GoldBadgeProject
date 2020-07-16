using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class BadgeRepository
    {

        protected readonly Dictionary<Badge, List<string>> badgeDict = new Dictionary<Badge, List<string>>();

        public bool AddContentToDictionary(Badge badgeID, List<string> roomNames)
        {
            int startingCount = badgeDict.Count;
            badgeDict.Add(badgeID, roomNames);
            bool wasAdded = (badgeDict.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public void PrintDictionary()
        {

            
            foreach (KeyValuePair<Badge, List<string>> pair in badgeDict)
            {

                var badges = string.Join(",", pair.Value);
                string output = string.Format("{0,-20}{1,-20}", pair.Key.BadgeID, badges);
                Console.WriteLine(output);
                
            }
        }

        public void FixThisName()
        {
            Badge badgeNumber = new Badge();
            Console.WriteLine();
            Console.WriteLine("Please select the badge number you would like to edit.");
            badgeNumber.BadgeID = Console.ReadLine();

            badgeDict.TryGetValue(badgeNumber, out List<string> value);
            Console.WriteLine(value);
            

            
        }

    }
}

