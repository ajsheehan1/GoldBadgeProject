using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public string DoorNames { get; set; }

        public Badge()
        {

        }
        public Badge(string badgeID, string doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
            
    }
    
}
