using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.UserServices
{
    public interface IUserService : IRepository<User>
    {
        public Task UpdateAsync(User user);
    }
}
