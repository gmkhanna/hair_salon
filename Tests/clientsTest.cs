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
        public void Test_SaveAssignstoID()
        {
            //Arrange
            Client userInput = new Client("Client Name", 1);
            userInput.Save()
            Client savedInput = Client.GetAll()[0];

            //Act
            testInput = userInput.GetID();
            result = savedInput.GetID();

            //Assert
            Assert.Equal(result, testInput);
        }

    }
}
