using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDelivery.Application.ViewModels
{
    public class RestaurantViewModel
    {
        public RestaurantViewModel() { }

        public RestaurantViewModel(Guid restaurantId, string name, string description)
        {
            Id = restaurantId.ToString();
            Name = name;
            Description = description;
        }

        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [MaxLength(1500)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }
}
