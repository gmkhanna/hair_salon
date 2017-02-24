using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_DBEmpty()
        {
            //Arrange, //Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_OverrideTrueIfSameName()
        {
            //Arrange
            Client userInput1 = new Client("Client Name", 1);
            Client userInput2 = new Client("Client Name", 1);

            //Act
            userInput1.Save();
            userInput2.Save();

            //Assert
            Assert.Equal(userInput2, userInput1);
        }

        [Fact]
        public void Test_Save_SaveObjectToDB()
        {
            //Arrange
            Client userInput = new Client("Client Name", 1);
            userInput.Save();

            //Act
            List<Client> testInput = new List<Client>{userInput};
            List<Client> result = Client.GetAll();

            //Assert
            Assert.Equal(result, testInput);
        }


        [Fact]
        public void Test_Save_SaveAssignstoID()
        {
            //Arrange
            Client userInput = new Client("Client Name", 1);
            userInput.Save();
            Client savedInput = Client.GetAll()[0];

            //Act
            int testInput = userInput.GetID();
            int result = savedInput.GetID();

            //Assert
            Assert.Equal(result, testInput);
        }

        [Fact]
        public void Test_Find_FindsSpecId()
        {
            //Arrange
            Client testInput = new Client("Client Name", 1);
            testInput.Save();

            //Act
            Client result = Client.Find(testInput.GetID());

            //Assert
            Assert.Equal(testInput, result);
        }

        [Fact]
        public void Test_Update_UpdateClient()
        {
            //Arrange
            string name = "Client Name";
            Client testInput = new Client(name, 1);
            testInput.Save();
            string newName = ("Name Client");

            //Act
            testInput.Update(newName);
            string result = testInput.GetName();

            //Assert
            Assert.Equal(result, newName);
        }

        [Fact]
        public void Test_Delete_DeleteSingleClient()
        {
            //Arrange
            Client testInput = new Client("Client Name 1", 1);
            testInput.Save();
            Client testInput2 = new Client ("Client Name 2", testInput.GetID());
            testInput2.Save();

            //Act
            testInput.Delete();
            List<Client> result = Client.GetAll();
            List<Client> resultList = new List<Client> {testInput2};

            Assert.Equal(result, resultList);
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }


    }
}
