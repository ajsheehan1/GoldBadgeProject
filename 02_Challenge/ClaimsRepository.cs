using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimsRepository
    {
        //CRUD
        //(Read)See All claims
        //(Update) Take Care of Next Claim
        //(Create) Enter a new claim
        public readonly Queue<Claim> directory = new Queue<Claim>();
       

        //add Claims
        public bool AddClaimsToQueue(Claim claim)
        {
            int startingCount = directory.Count;
            directory.Enqueue(claim);
            bool wasAdded = (directory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //show all claims
        public Queue<Claim> GetAllClaimContent()
        {
            Queue<Claim> allClaimItems = new Queue<Claim>();
            foreach (Claim content in directory)
            {
                allClaimItems.Enqueue((Claim)content);
            }
            return directory;
        }


        //"Take Care of Next Claim" (Aka delete)
        public bool DeleteClaimItems()
        {
            int startingCount = directory.Count;
            directory.Dequeue();
            bool wasDeleted = (directory.Count < startingCount) ? true : false;
            return wasDeleted;
        }

    }
}
