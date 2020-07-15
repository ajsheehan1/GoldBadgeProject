using System;
using System.Collections.Generic;
using _04_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_UnitTest
{
    [TestClass]
    public class OutingRepositoryTests 
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCoorectBool()
        {
            //Arrange
            Outing content = new Outing();
            OutingRepository repo = new OutingRepository();

            //Act
            bool addResult = repo.AddContentToOutingList(content);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllMenuContent_ShouldReturnAllContent()
        {
            //Arrange
            Outing content = new Outing();
            OutingRepository repo = new OutingRepository();
            repo.AddContentToOutingList(content);

            //Act
            List<Outing> outing = repo.GetAllOutingInfo();
            bool result = outing.Contains(content);

            //Assert
            Assert.IsTrue(result);

        }
    }
}
