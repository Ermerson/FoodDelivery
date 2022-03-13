using FoodDelivery.Application.ViewModels;
using System;

namespace FoodDelivery.Tests.UnitTests.Helpers
{
    public static class RestaurantViewModelHelper
    {
        public static RestaurantViewModel GetRestaurantViewModel()
        {
            return new RestaurantViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Shushi MyagDo",
                Description = "Strike First, Strike Hard, No Mercy"
            };
        }
    }
}
