namespace Alumni_Network_Portal_BE.Services
{
    public interface IRepositoryService<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> AddAsync(T type);
        public Task UpdateAsync(T type);
        public Task DeleteAsync(int id);
        public bool Exists(int id);
    }
}
