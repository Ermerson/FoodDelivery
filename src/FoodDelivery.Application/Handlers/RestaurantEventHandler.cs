using FoodDelivery.Domain.Restaurant.Events;
using System.Threading.Tasks;

namespace FoodDelivery.Application.Handlers
{
    public class RestaurantEventHandler
    {
        public async Task HandleRestaurantCreatedEvent(RestaurantCreatedEvent restaurantCreatedEvent)
        {
            // Posso fazer o que precisar com o evento disparado, talvez enviar para uma fila do rabbitMQ ou Kafka ou notificar para uma API
            // Dessa forma estarei construindo uma arquitetura orientada a eventos com DDD e microserviçoes
        }

        public async Task HandleRestaurantDeletedEvent(RestaurantDeletedEvent RestaurantDeletedEvent)
        {
            // Posso fazer o que precisar com o evento disparado, talvez enviar para uma fila do rabbitMQ ou Kafka ou notificar para uma API
            // Dessa forma estarei construindo uma arquitetura orientada a eventos com DDD e microserviçoes
        }
    }
}
