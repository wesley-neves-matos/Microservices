namespace Catalog.API.Repositories
{
    public interface IBasicOperationsRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(string id);
        public Task CreateAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(string id);
    }
}
