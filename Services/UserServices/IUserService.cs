using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.UserServices
{
    public interface IUserService
    {
        public Task UpdateAsync(User user);
        public Task PostAsync(User user);
        public bool Exists(int id);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);

    }
}
