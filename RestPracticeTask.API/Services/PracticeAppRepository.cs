using RestPracticeTask.API.Entities;

namespace RestPracticeTask.API.Services
{
    public class PracticeAppRepository : IPracticeAppRepository
    {
        private readonly DbContexts.PracticeAppContext _context;

        public PracticeAppRepository(DbContexts.PracticeAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product GetProduct(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProducts(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return GetProducts();
            }

            return _context.Products.Where(a => a.CategoryId == categoryId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ProductExists(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products.Any(a => a.Id == productId);
        }

        public bool CategoryExists(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories.Any(a => a.Id == categoryId);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (product.CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(product.CategoryId));
            }


            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            
        }
    }
}