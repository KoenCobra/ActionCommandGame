using System.ComponentModel.DataAnnotations;

namespace ActionCommandGame.Services.Model.Results
{
    public class ItemResult
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Fuel { get; set; }
        [Required]
        public int Attack { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int ActionCooldownSeconds { get; set; }
    }
}
