using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class ProgramUI
    {
        private readonly MenuRepository menuRepo = new MenuRepository();


        public void Run()
        {
            MenuContentList();
            StartMenu();
        }


        private void StartMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- KOMODO CAFE MENU REPOSITORY ----");
                Console.WriteLine();

                Console.WriteLine("Welcome to the menu platform. Please enter what you would like to do with the menu: \n" +
                    " \n" +
                    "1. Show All Menu Items \n" +
                    "2. Add New Menu Item \n" +
                    "3. Delete Existing Menu Item\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        ShowMenu();
                        Console.Clear();
                        //We need to show all menu items
                        break;
                    case "2":
                        NewMenuItem();
                        Console.Clear();
                        // We add a new item
                        break;
                    case "3":
                        DeleteMenuItems();
                        Console.Clear();
                        // we need to delete existing items
                        break;
                    case "4":
                        // Exit 
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4 \n" +
                            "To continue, press any key");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("---- KOMODO CAFE MENU REPOSITORY ----");
            Console.WriteLine();

            List<Menu> listOfMenuItems = menuRepo.GetAllMenuContent();

            foreach (Menu menu in listOfMenuItems)
            {
                DisplayItems(menu);
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void NewMenuItem()
        {
            Console.Clear();
            Menu content = new Menu();

            Console.WriteLine("---- KOMODO CAFE MENU REPOSITORY ----");
            Console.WriteLine();

            Console.WriteLine("What is the meal number?");
            content.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the meal name?");
            content.MealName = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Please enter a description of the meal: ");
            content.Description = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please give the list of ingredients: ");
            content.ListOfIngredients = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is the price of the new item?");
            content.Price = Convert.ToDecimal(Console.ReadLine());

            menuRepo.AddContentToMenu(content);

        }

        private void DeleteMenuItems()
        {
            Console.Clear();

            Console.WriteLine("---- KOMODO CAFE MENU REPOSITORY ----");
            Console.WriteLine();

            
            List<Menu> menuList = menuRepo.GetAllMenuContent();

            foreach (Menu menu in menuList)
            {
                DisplayItems(menu);
                Console.WriteLine();
            }

            Console.WriteLine("Please select the item you would like to remove");
            Console.WriteLine();

            int selectedContentID = int.Parse(Console.ReadLine());
            int pickIndex = selectedContentID - 1;
            if (pickIndex >= 0 && pickIndex < menuList.Count)
            {
                Menu verifiedSelection = menuList[pickIndex];
                if (menuRepo.DeleteMenuItems(verifiedSelection))
                {
                    Console.WriteLine($"{verifiedSelection.MealName} - Menu Item {verifiedSelection.MealNumber} - successfully removed.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please re-select.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, no menu item matches your selection.");
               
            }
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey();
        }

        private void MenuContentList()
        {
            Menu menuItemOne = new Menu(1, "Double cheeseburger", "Classic double cheeseburger made medium well to order. Can change upon request.", "Two ground beef patties, sesame seed bun, ketchup, mustard, two slices of cheese.", 3.99m);

            Menu menuItemTwo = new Menu(2, "Veggie burger", "Burger for all the vegetarians", "Veggie pattie, sesame seed bun, ketchup, mustard, and cheese (or no cheese)", 5.99m);

            Menu menuItemThree = new Menu(3, "The AJ Special", "Amazing stuffed burger (bacon, pepper jack, and/or jalapeno available) with delicious bacon jam.", "Sesame seed bun, 1/2 pount ground beef pattie, bacon bits, jalapeno bits, pepper jack cheese, and bacon jam.", 10.99m);

            menuRepo.AddContentToMenu(menuItemOne);
            menuRepo.AddContentToMenu(menuItemTwo);
            menuRepo.AddContentToMenu(menuItemThree);
        }

        private void DisplayItems(Menu menu)
        {

            string convertDollars = String.Format("Price:               {0:C2}.", menu.Price);
                  Console.WriteLine($"Item Number:         {menu.MealNumber} \n" +
                                    $"Meal Name:           {menu.MealName} \n" +
                                    $"Meal Description:    {menu.Description} \n" +
                                    $"List of Ingredients: {menu.ListOfIngredients}");
                                    Console.WriteLine(convertDollars);
        }
    }

}
