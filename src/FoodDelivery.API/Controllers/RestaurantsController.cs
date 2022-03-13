using FoodDelivery.Application.Services;
using FoodDelivery.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace FoodDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _restaurantService.GetAll());
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _restaurantService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] RestaurantViewModel restaurantViewModel)
        {
            try
            {
                return Ok(await _restaurantService.Create(restaurantViewModel));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _restaurantService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
    }
}
