using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;


namespace Alumni_Network_Portal_BE.Services.UserServices
{
    public interface IUserService
    {
        public Task UpdateAsync(User patchUser, User userToPatch);
        public Task PostAsync(User user);
        public bool Exists(int id);
        public Task<User> GetAsync(string keycloakId);
        public Task<User> GetByIdAsync(int id);
        public User getUserFromKeyCloak(string keycloakId);

    }
}
