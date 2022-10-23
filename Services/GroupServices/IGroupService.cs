using Alumni_Network_Portal_BE.Models.Domain;
using System.Text.RegularExpressions;
using Group = Alumni_Network_Portal_BE.Models.Domain.Group;

namespace Alumni_Network_Portal_BE.Services.GroupServices
{
    public interface IGroupService
    {
        /// <summary>
        /// Gets all the groups
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Group>> GetAllAsync(string keycloakId);
        /// <summary>
        /// Gets a group by ID
        /// </summary>
        /// <param name="id">The ID of the group</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Group> GetByIdAsync(int id, string keycloakId);
        /// <summary>
        /// Adds a new group
        /// </summary>
        /// <param name="group">The group to be added</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Group> AddGroupAsync(Group group, string keycloakId);
        /// <summary>
        /// Checks if the group exists or not
        /// </summary>
        /// <param name="id">ID of the group</param>
        public bool Exists(int id);
        /// <summary>
        /// Adds the user to group
        /// </summary>
        /// <param name="groupId">Group ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <returns></returns>
        public Task UpdateGroupUserAsync(int groupId, string keycloakId);
        /// <summary>
        /// Removes the user from the group
        /// </summary>
        /// <param name="groupId">The group ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task LeaveGroupAsync(int groupId, string keycloakId);

    }
}
