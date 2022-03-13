using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.Domain.Restaurant.Commands
{
    public class DeleteRestaurantCommand : RestaurantCommand
    {
        public DeleteRestaurantCommand(Guid id)
        {
            Id = id;
        }
    }
}
