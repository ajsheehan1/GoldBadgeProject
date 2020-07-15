using System;
using System.Collections.Generic;
using System.Linq;
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
            List<KeyValuePair<Badge, List<string>>> allItemsInList = badgeDict.ToList();
            /*foreach (KeyValuePair<BadgeNumber, List<string>> keyValue in badgeDict)
            {

                allMenuItems.Add((Menu)menu);
                Console.WriteLine("Key: {0}, Value: {1}",
               keyValue.Key.BadgeID, keyValue.Value);
            }*/

        }
    }

}

