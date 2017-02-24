using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class StylistTest : IDisposable
    {
        [Fact]
        public void Test_DatabaseEmpty()
        {
            int result = Stylist.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ReturnTrueIfEqual()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Stylist Name");
            Stylist secondStylist = new Stylist("Stylist Name");

            //Assert
            Assert.Equal(firstStylist, secondStylist);

        }

        [Fact]
        public void Test_Save_SavesStylist()
        {
            // Arrange
            Stylist testStylist = new Stylist("Stylist Name");

            // Act
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            // Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_SaveAssignsIdToObject()
        {
            // Arrange
            Stylist testStylist = new Stylist("Stylist Name");
            testStylist.Save();

            // Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetStylistId();
            int testId = testStylist.GetStylistId();

            // Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_FindStylistId()
        {
            //Arrange
            Stylist testStylist = new Stylist("Stylist Name");
            testStylist.Save();

            //Act
            Stylist foundStylistId = Stylist.Find(testStylist.GetStylistId());

            //Assert
            Assert.Equal(testStylist, foundStylistId);
        }

        [Fact]
        public void Test_GetClients_RetrievesAllClientsWithStylist()
        {
            Stylist testStylist = new Stylist("Stylist Name");
            testStylist.Save();

            Client firstClient = new Client("Stylist Name", testStylist.GetStylistId());
            firstClient.Save();
            Client secondClient = new Client("Taco Del Mar", testStylist.GetStylistId());
            secondClient.Save();


            List<Client> testClientList = new List<Client> {firstClient, secondClient};
            List<Client> resultClientList = testStylist.GetClients();

            Assert.Equal(testClientList, resultClientList);
        }

        // [Fact]
        // public void Test_Update_UpdatesCategoryInDatabase()
        // {
        //     // Arrange
        //     string type = "Mexico";
        //     Stylist testStylist = new Stylist(type);
        //     testStylist.Save();
        //     string newType = "Mexican";
        //
        //     // Act
        //     testStylist.Update(newType);
        //
        //     string result = testStylist.GetStylistType();
        //
        //     // Assert
        //     Assert.Equal(newType, result);
        //
        // }
        //

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }

    }
}
