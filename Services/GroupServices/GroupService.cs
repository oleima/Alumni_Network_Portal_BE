using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alumni_Network_Portal_BE.Services.GroupServices
{
    public class GroupService : IGroupService
    {
        private readonly AlumniNetworkDbContext _context;

        public GroupService(AlumniNetworkDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Groups
                .Include(c => c.Users)
                .Where(c => c.IsPrivate == false || c.Users.Contains(user))
                .ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            Group group = await _context.Groups
                .Include(c => c.Users)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (!group.Users.Contains(user)&&group.IsPrivate)
            {
                return new Group { Id = 0 };
            }

            return group;
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}