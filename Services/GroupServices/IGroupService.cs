using Alumni_Network_Portal_BE.Models.Domain;
using System.Text.RegularExpressions;
using Group = Alumni_Network_Portal_BE.Models.Domain.Group;

namespace Alumni_Network_Portal_BE.Services.GroupServices
{
    public interface IGroupService
    {
        public Task<IEnumerable<Group>> GetAllAsync(string keycloakId);
        public Task<Group> GetByIdAsync(int id, string keycloakId);
        public Task<Group> AddGroupAsync(Group group, string keycloakId);
        public bool Exists(int id);
        public Task UpdateGroupUserAsync(int groupId, List<int> users, string keycloakId);
        public Task LeaveGroupAsync(int groupId, string keycloakId);

    }
}
