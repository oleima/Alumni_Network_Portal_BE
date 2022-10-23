using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;


namespace Alumni_Network_Portal_BE.Services.UserServices
{
    public interface IUserService
    {
        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="patchUser">The changes in the user</param>
        /// <param name="userToPatch">The actual user</param>
        public Task UpdateAsync(User patchUser, User userToPatch);
        /// <summary>
        /// Creates an empty new user based on token
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <param name="username">Username of the user</param>
        public Task<User> PostAsync(string keycloakId, string username);
        /// <summary>
        /// Checks if user exists
        /// </summary>
        /// <param name="id">ID of the user</param>
        public bool Exists(int id);
        /// <summary>
        /// Gets the user based on keycloakID
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<User> GetAsync(string keycloakId);
        /// <summary>
        /// ets the user based on ID
        /// </summary>
        /// <param name="id">ID of the user</param>
        public Task<User> GetByIdAsync(int id);
        /// <summary>
        /// Gets a user from a keycloakID
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <returns>An user</returns>
        public User getUserFromKeyCloak(string keycloakId);

    }
}
