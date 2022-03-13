using System;


namespace FoodDelivery.Infrastructure.Factories
{
    public class RestaurantFactory : Domain.Restaurant.Restaurant
    {
        public RestaurantFactory()
        {

        }

        public RestaurantFactory(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public RestaurantFactory(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
