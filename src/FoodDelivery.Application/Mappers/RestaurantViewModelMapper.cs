using FoodDelivery.Application.ViewModels;
using FoodDelivery.Domain.Restaurant;
using FoodDelivery.Domain.Restaurant.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FoodDelivery.Application.Mappers
{
    public class RestaurantViewModelMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RestaurantViewModelMapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<RestaurantViewModel> ConstructFromListOfEntities(IEnumerable<Restaurant> restaurants)
        {
            var restaurantViewModel = restaurants.Select(i => new RestaurantViewModel
            {
                Id = i.Id.ToString(),
                Name = i.Name.ToString(),
                Description = i.Description.ToString()
            });

            return restaurantViewModel;
        }

        public RestaurantViewModel ConstructFromEntity(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                Id = restaurant.Id.ToString(),
                Name = restaurant.Name.ToString(),
                Description = restaurant.Description.ToString()
            };
        }

        public CreateNewRestaurantCommand ConvertToNewRestaurantCommand(RestaurantViewModel restaurantViewModel)
        {
            return new CreateNewRestaurantCommand(restaurantViewModel.Name, restaurantViewModel.Description);
        }

        public DeleteRestaurantCommand ConvertToDeleteRestaurantCommand(Guid id)
        {
            return new DeleteRestaurantCommand(id);
        }
    }
}
