namespace Alumni_Network_Portal_BE.Services
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public bool Exists(int id);
    }
}
