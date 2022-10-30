using System.ComponentModel.DataAnnotations;

namespace RestPracticeTask.API.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }          

        public string ImgUrl { get; set; }

        public Guid CategoryId { get; set; }
    }
}
