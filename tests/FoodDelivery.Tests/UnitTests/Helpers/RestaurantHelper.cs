using FoodDelivery.Domain.Restaurant;
using System;
using System.Collections.Generic;

namespace FoodDelivery.Tests.UnitTests.Helpers
{
    public static class RestaurantHelper
    {
        public static Restaurant GetRestaurant()
        {
            return new Restaurant()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Description = "Description"
            };
        }

        public static IEnumerable<Restaurant> GetTasks()
        {
            return new List<Restaurant>()
            {
                GetRestaurant()
            };
        }

    }
}
