using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository : IBasicOperationsRepository<Product>
    {
        public Task<IEnumerable<Product>> GetByNameAsync(string name);
        public Task<IEnumerable<Product>> GetByCategoryAsync(string category);

    }
}
