using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.GroupServices
{
    public interface IGroupService
    {
        public Task<IEnumerable<Group>> GetAllAsync();
        public Task<Group> GetByIdAsync(int id);
        public Task UpdateAsync(Group group);
        public bool Exists(int id);
    }
}
