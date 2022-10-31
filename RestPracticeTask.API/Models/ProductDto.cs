using System.ComponentModel.DataAnnotations;

namespace RestPracticeTask.API.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [MaxLength(1000)]
        public string ImgUrl { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
