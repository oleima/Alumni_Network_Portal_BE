using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.GroupServices
{
    public interface IGroupService
    {
        public Task<IEnumerable<Group>> GetAllAsync(string keycloakId);
        public Task<Group> GetByIdAsync(int id, string keycloakId);
        public Task UpdateAsync(Group group);
        public bool Exists(int id);
    }
}
