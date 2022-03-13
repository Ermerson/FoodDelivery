using FoodDelivery.Domain.Restaurant;

namespace FoodDelivery.Infrastructure.Factories
{
    public class EntityFactory : IRestaurantFactory
    {     
        public Restaurant CreateRestaurantInstance(string name, string description)
        {
            return new RestaurantFactory(name, description);
        }
    }
}
