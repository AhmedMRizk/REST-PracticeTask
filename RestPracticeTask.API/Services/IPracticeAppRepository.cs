using RestPracticeTask.API.Entities;

namespace RestPracticeTask.API.Services
{
    public interface IPracticeAppRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts(Guid categoryId);
        Product GetProduct(Guid productId);
        bool Save();

    }
}
