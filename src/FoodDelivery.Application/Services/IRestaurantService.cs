using FoodDelivery.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Application.Services
{
    public  interface IRestaurantService
    {
        Task<IEnumerable<RestaurantViewModel>> GetAll();
        Task<RestaurantViewModel> GetById(Guid id);
        Task<RestaurantViewModel> Create(RestaurantViewModel restaurantViewModel);
        Task<RestaurantViewModel> Update(RestaurantViewModel restaurantViewModel);
        Task Delete(Guid id);
    }
}
