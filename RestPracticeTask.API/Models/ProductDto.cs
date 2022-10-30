namespace RestPracticeTask.API.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
