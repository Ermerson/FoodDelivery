using System;

namespace FoodDelivery.Domain.Restaurant.Events
{
    public class RestaurantDeletedEvent : RestaurantEvent
    {
        public RestaurantDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
