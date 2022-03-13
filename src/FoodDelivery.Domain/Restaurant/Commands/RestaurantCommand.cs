using System;

namespace FoodDelivery.Domain.Restaurant.Commands
{
    public class RestaurantCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
