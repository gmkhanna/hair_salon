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

        // [Fact]
        // public void Test_ReturnTrueIfEqual()
        // {
        //     //Arrange, Act
        //     Stylist firstStylist = new Stylist("Stylist Name");
        //     Stylist secondStylist = new Stylist("Stylist Name");
        //
        //     //Assert
        //     Assert.Equal(firstStylist, secondStylist);
        //
        // }
        //
        // [Fact]
        // public void Test_Save_SavesStylist()
        // {
        //     // Arrange
        //     Stylist testStylist = new Stylist("Stylist Name");
        //
        //     // Act
        //     testStylist.Save();
        //     List<Stylist> result = Stylist.GetAll();
        //     List<Stylist> testList = new List<Stylist>{testStylist};
        //
        //     // Assert
        //     Assert.Equal(testList, result);
        // }
        //
        // [Fact]
        // public void Test_SaveAssignsIdToObject()
        // {
        //     // Arrange
        //     Stylist testStylist = new Stylist("Stylist Name");
        //     testStylist.Save();
        //
        //     // Act
        //     Stylist savedStylist = Stylist.GetAll()[0];
        //
        //     int result = savedStylist.GetStylistId();
        //     int testId = testStylist.GetStylistId();
        //
        //     // Assert
        //     Assert.Equal(testId, result);
        // }
        //
        // [Fact]
        // public void Test_FindStylistId()
        // {
        //     //Arrange
        //     Stylist testStylist = new Stylist("Stylist Name");
        //     testStylist.Save();
        //
        //     //Act
        //     Stylist foundStylistId = Stylist.Find(testStylist.GetStylistId());
        //
        //     //Assert
        //     Assert.Equal(testStylist, foundStylistId);
        // }
        //
        // [Fact]
        // public void Test_GetRestaurants_RetrievesAllRestaurantsWithStylist()
        // {
        //     Stylist testStylist = new Stylist("Stylist Name");
        //     testStylist.Save();
        //
        //     Restaurant firstRestaurant = new Restaurant("Stylist Name", testStylist.GetStylistId());
        //     firstRestaurant.Save();
        //     Restaurant secondRestaurant = new Restaurant("Taco Del Mar", testStylist.GetStylistId());
        //     secondRestaurant.Save();
        //
        //
        //     List<Restaurant> testRestaurantList = new List<Restaurant> {firstRestaurant, secondRestaurant};
        //     List<Restaurant> resultRestaurantList = testStylist.GetRestaurants();
        //
        //     Assert.Equal(testRestaurantList, resultRestaurantList);
        // }
        //
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
