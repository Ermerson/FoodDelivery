using System;

namespace FoodDelivery.Domain.Restaurant.Events
{
    public class RestaurantCreatedEvent : RestaurantEvent
    {
        public RestaurantCreatedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
