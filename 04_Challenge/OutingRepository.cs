using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class OutingRepository
    {
        protected readonly List<Outing> _contentDirectory = new List<Outing>();
        public bool AddContentToOutingList(Outing content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        // Read all items
        public List<Outing> GetAllOutingInfo()
        {
            List<Outing> allMenuItems = new List<Outing>();
            foreach (Outing content in _contentDirectory)
            {
                allMenuItems.Add((Outing)content);
            }
            return _contentDirectory;
        }


       


    }
}
