namespace FoodDelivery.Domain.Restaurant.Commands
{
    public class CreateNewRestaurantCommand : RestaurantCommand
    {
        public CreateNewRestaurantCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
