using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClientTest : IDisposable
    {
        public HairSalonAppTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_DBEmpty()
        {
            //Arrange, //Act
            int noInput = clients.GetAll().count;

            //Assert
            Assert.Equal(noInput, 0);
        }

        [Fact]
        public void Test_OverrideTrueIfSameName_True()
        {
            //Arrange
            Client userInput1 = new Client("Client Name", 1);
            Client userInput2 = new Client("Client Name", 1);

            //Act
            testInput = userInput1.Save();
            result = userInput2.Save();

            //Assert
            Assert.Equal(result, testInput);
        }

        // [Fact]
        // public void Test_OverrideTrueIfSameName()
        // {
        //     //Arrange
        //     Client userInput1 = new Client("Client Name", 1);
        //     Client userInput2 = new Client("Client Name", 1);
        //
        //     //Act
        //     userInput1.Save();
        //     userInput2.Save();
        //
        //     //Assert
        //     Assert.Equal(userInput2, userInput1);
        // }

        [Fact]
        public void Test_Save_SaveObjectToDB()
        {
            //Arrange
            Client userInput = new Client("Client Name", 1);
            userInput.Save();

            //Act
            List<Client> testInput = new List<Client>{userinput};
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
            testInput = userInput.GetID();
            result = savedInput.GetID();

            //Assert
            Assert.Equal(result, testInput);
        }

        [Fact]
        public void Test_Find_FindsSpecId()
        {
            //Arrange
            string name = "Client Name";
            Client testInput = new Client(name);
            testInput.Save();
            string nameUpdate = "Name Client";

            //Act
            testInput.Client(nameUpdate);

            string result = testInput.GetName();

            //Assert
            Assert.Equal(nameUpdate, result);
        }

        [Fact]
        public void Test_Update_UpdateClient()
        {
            //Arrange
            Client testInput = new Client("Client Name", 1);
            testInput.Save();
            Client testInput2 = new Client("Name Client", 1);

            //Act
            CLient updatedClient = testInput2.Update();
            Client result = Client.Find(testInput.GetId());

            //Assert
            Assert.Equal(result, testInput);
        }

        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }


    }
}
