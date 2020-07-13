using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

namespace _01_UnitTest
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCoorectBool()
        {
            //Arrange
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();

            //Act
            bool addResult = repo.AddContentToMenu(content);

            //Assert
            Assert.IsTrue(addResult);
           
        }

        [TestMethod]
        public void GetAllMenuContent_ShouldReturnAllContent()
        {
            //Arrange
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddContentToMenu(content);

            //Act
            List<Menu> menus = repo.GetAllMenuContent();
            bool thereIsSomethingHere = menus.Contains(content);

            //Assert
            Assert.IsTrue(thereIsSomethingHere);

        }

        [TestMethod]
        public void DeleteMenuContent_ShouldDeleteSelectedContent()
        {
            //Arrange
            Menu content = new Menu(1, "burger", "burger", "burger", 4.99m);
            MenuRepository repo = new MenuRepository();
            repo.AddContentToMenu(content);

            //Act
            bool removeResult = repo.DeleteMenuItems(content);

            //Assert
            Assert.IsTrue(removeResult);
                
        }
    }
}
