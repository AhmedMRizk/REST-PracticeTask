using System.ComponentModel.DataAnnotations;

namespace RestPracticeTask.API.Models
{
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out the name.")]
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters.")]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [MaxLength(1000, ErrorMessage = "The ImgUrl shouldn't have more than 100 characters.")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "CategoryId should be present.")]
        public Guid CategoryId { get; set; }
    }
}
