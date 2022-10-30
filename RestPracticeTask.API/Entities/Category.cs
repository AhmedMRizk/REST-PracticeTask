using System.ComponentModel.DataAnnotations;

namespace RestPracticeTask.API.Entities
{
    public class Category
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
