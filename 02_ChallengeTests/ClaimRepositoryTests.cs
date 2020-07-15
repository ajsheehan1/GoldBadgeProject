using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using _02_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ChallengeTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {

        [TestMethod]
        public void AddToClaimMenu_ShouldGetCoorectBool()
        {
            //Arrange
            _02_Challenge.Claim content = new _02_Challenge.Claim();
            ClaimsRepository repo = new ClaimsRepository();

            //Act
            bool addResult = repo.AddClaimsToQueue(content);

            //Assert
            Assert.IsTrue(addResult);

        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnAllClaims()
        {
            //Arrange
            _02_Challenge.Claim content = new _02_Challenge.Claim();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddClaimsToQueue(content);

            //Act
            Queue<_02_Challenge.Claim> claim = repo.GetAllClaimContent();
            bool thereIsSomethingHere = claim.Contains(content);

            //Assert
            Assert.IsTrue(thereIsSomethingHere);

        }
        [TestMethod]
        public void DeleteMenuContent_ShouldDeleteSelectedContent()
        {
            //Arrange
            _02_Challenge.Claim content = new _02_Challenge.Claim(4,ClaimType.Car,"Turrible accident",400.44, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddClaimsToQueue(content);

            //Act
            bool removeResult = repo.DeleteClaimItems();

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}

