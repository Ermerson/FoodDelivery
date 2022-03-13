using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.Domain.Restaurant.Events
{
    public class RestaurantEvent
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
    }
}
