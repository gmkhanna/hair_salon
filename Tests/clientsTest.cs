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
            //Arrange
            int noInput = clients.GetAll().count;

            //Act


            //Assert
            Assert.Equal(noInput, 0);
        }


        [Fact]
        public void Test_DBEmpty()
        {
            //Arrange
            int noInput = clients.GetAll().count;

            //Act


            //Assert
            Assert.Equal(noInput, 0);
        }

    }
}
