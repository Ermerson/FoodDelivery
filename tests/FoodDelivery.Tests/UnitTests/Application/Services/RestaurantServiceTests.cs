using FluentMediator;
using FoodDelivery.Application.Mappers;
using FoodDelivery.Application.Services;
using FoodDelivery.Domain.Restaurant;
using FoodDelivery.Domain.Restaurant.Commands;
using FoodDelivery.Tests.UnitTests.Helpers;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace FoodDelivery.Tests.UnitTests.Application.Services
{
    public class RestaurantServiceTests
    {
        private readonly Mock<IRestaurantRepository> _mockRestaurantRepository = new Mock<IRestaurantRepository>();
        private readonly Mock<IRestaurantFactory> _mockRestaurantFactory = new Mock<IRestaurantFactory>();
        private readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        private static readonly Mock<IHttpContextAccessor> _mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();

        private readonly RestaurantViewModelMapper _mockRestaurantViewModelMapper = new RestaurantViewModelMapper(_mockIHttpContextAccessor.Object);

        [Fact]
        public async System.Threading.Tasks.Task Create_Success()
        {
            //Arrange
            _mockIMediator.Setup(x => x.SendAsync<Restaurant>(It.IsAny<CreateNewRestaurantCommand>(), null))
                .Returns(System.Threading.Tasks.Task.FromResult(RestaurantHelper.GetRestaurant()));
            _mockIHttpContextAccessor.Setup(x => x.HttpContext).Returns(HttpContextHelper.GetHttpContext());

            //Act
            var restaurantService = new RestaurantService(_mockRestaurantRepository.Object, _mockRestaurantViewModelMapper, _mockRestaurantFactory.Object, _mockIMediator.Object);
            var result = await restaurantService.Create(RestaurantViewModelHelper.GetRestaurantViewModel());

            //Assert
            Assert.NotNull(result);

            Assert.Equal("Name", result.Name);
            Assert.Equal("Description", result.Description);

            Assert.NotNull(result.Id);
            Assert.NotNull(result.Description);

            _mockIMediator.Verify(x => x.SendAsync<Restaurant>(It.IsAny<CreateNewRestaurantCommand>(), null), Times.Once);
        }
    }
}
