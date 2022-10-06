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

        public async Task<Group> AddGroupAsync(Group group, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            List<int> list = new List<int>();
            list.Add(user.Id);

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            UpdateGroupUserAsync(group.Id, list);

            return group;
        }

        public async Task UpdateGroupUserAsync(int groupId, List<int> users)
        {
            Group groupToUpdate = await _context.Groups
               .Include(c => c.Users)
               .Where(c => c.Id == groupId)
               .FirstAsync();


            List<User> usersList = new();

            foreach(int userId in users)
            {
                User user = await _context.Users.FindAsync(userId);
                if (user == null)
                    throw new KeyNotFoundException();
                usersList.Add(user);
            }

            groupToUpdate.Users = usersList;
            await _context.SaveChangesAsync();
        }

    }
}