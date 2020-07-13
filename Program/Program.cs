using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

            //Create a Menu Class with properties, constructors, and fields.
            //Create a MenuRepository Class that has methods needed.
            //Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
            //Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
            
            ProgramUI start = new ProgramUI();
            start.Run();
            
        }
    }
}
