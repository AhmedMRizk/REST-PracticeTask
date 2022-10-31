using RestPracticeTask.API.Entities;

namespace RestPracticeTask.API.Services
{
    public interface IPracticeAppRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts(Guid categoryId);
        Product GetProduct(Guid productId);
        bool Save();
        bool ProductExists(Guid productId);
        bool CategoryExists(Guid categoryId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
