using System;

namespace FoodDelivery.Domain.Restaurant
{
    public class Restaurant : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
