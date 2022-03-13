using FluentMediator;
using FoodDelivery.Domain.Restaurant;
using FoodDelivery.Domain.Restaurant.Commands;
using FoodDelivery.Domain.Restaurant.Events;
using System.Threading.Tasks;

namespace FoodDelivery.Application.Handlers
{
    public class RestaurantCommandHandler
    {
        private readonly IRestaurantFactory _restaurantFactory;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMediator _mediator;

        public RestaurantCommandHandler(IRestaurantRepository restaurantRepository, IRestaurantFactory restaurantFactory, IMediator mediator)
        {
            _restaurantRepository = restaurantRepository;
            _restaurantFactory = restaurantFactory;
            _mediator = mediator;
        }

        public async Task<Restaurant> HandleNewRestaurant(CreateNewRestaurantCommand createNewRestaurantCommand)
        {
            var restaurant = _restaurantFactory.CreateRestaurantInstance(
                name: createNewRestaurantCommand.Name,
                description: createNewRestaurantCommand.Description
            );

            var restaurantCreated = await _restaurantRepository.Add(restaurant);

            // Caso desejar propagar eventos para outros microserviços
            await _mediator.PublishAsync(new RestaurantCreatedEvent(restaurantCreated.Id,
                restaurantCreated.Description, restaurantCreated.Name));

            return restaurantCreated;
        }

        public async Task HandleDeleteRestaurant(DeleteRestaurantCommand deleteRestaurantCommand)
        {
            await _restaurantRepository.Remove(deleteRestaurantCommand.Id);

            // Caso desejar propagar eventos para outros microserviços
            await _mediator.PublishAsync(new RestaurantDeletedEvent(deleteRestaurantCommand.Id));
        }
    }
}
