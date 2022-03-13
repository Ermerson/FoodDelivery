
namespace FoodDelivery.Domain.Restaurant
{
    public interface IRestaurantFactory
    {
        Restaurant CreateRestaurantInstance(string name, string description);
    }
}
