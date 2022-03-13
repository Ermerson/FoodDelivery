using FluentMediator;
using FoodDelivery.Application.Mappers;
using FoodDelivery.Application.ViewModels;
using FoodDelivery.Domain.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMediator _mediator;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantFactory _restauranFactory;
        private readonly RestaurantViewModelMapper _restauranViewModelMapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, RestaurantViewModelMapper restaurantViewModelMapper, IRestaurantFactory restaurantFactory, IMediator mediator)
        {
            _restaurantRepository = restaurantRepository;
            _restauranViewModelMapper = restaurantViewModelMapper;
            _restauranFactory = restaurantFactory;
            _mediator = mediator;
        }

        public async Task<RestaurantViewModel> Create(RestaurantViewModel restaurantViewModel)
        {
            var command = _restauranViewModelMapper.ConvertToNewRestaurantCommand(restaurantViewModel);
            var result = await _mediator.SendAsync<Restaurant>(command);

            return _restauranViewModelMapper.ConstructFromEntity(result);
        }

        public async Task Delete(Guid id)
        {
            var deleteRestaurantCommand = _restauranViewModelMapper.ConvertToDeleteRestaurantCommand(id);
            await _mediator.PublishAsync(deleteRestaurantCommand);
        }

        public async Task<IEnumerable<RestaurantViewModel>> GetAll()
        {
            IEnumerable<Restaurant> restaurantsEntity = await _restaurantRepository.FindAll();
            return _restauranViewModelMapper.ConstructFromListOfEntities(restaurantsEntity);
        }

        public async Task<RestaurantViewModel> GetById(Guid id)
        {
            var restaurantEntity = await _restaurantRepository.FindById(id);
            return _restauranViewModelMapper.ConstructFromEntity(restaurantEntity);
        }

        public Task<RestaurantViewModel> Update(RestaurantViewModel restaurantViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
