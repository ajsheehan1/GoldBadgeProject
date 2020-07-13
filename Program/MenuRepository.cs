using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
   public class MenuRepository
    {
        protected readonly List<Menu> _contentDirectory = new List<Menu>();

        //CRUD 
        //CREATE new tiems
        // (READ) Show list of all 
        // DELETE items

        //CREATE
        public bool AddContentToMenu(Menu content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }


        // Read all items
        public List<Menu> GetAllMenuContent()
        {
            List<Menu> allMenuItems = new List<Menu>();
            foreach (Menu menu in _contentDirectory)
            {
                allMenuItems.Add((Menu)menu);
            }
            return _contentDirectory;
        }


        //DELETE ITEMS
        public bool DeleteMenuItems(Menu exisitingMenuItems)
        {
            bool deleteItem = _contentDirectory.Remove(exisitingMenuItems);
            return deleteItem;
            
        }



    }
}
