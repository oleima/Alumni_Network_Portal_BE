using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
                .Include(t => t.Posts)
                .Include(t => t.Events)
                .Where(c => c.IsPrivate == false || c.Users.Contains(user))
                .ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            Group group = await _context.Groups
                .Include(t => t.Posts)
                .Include(t => t.Events)
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

            group.Users = new List <User>() {user} ;

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return group;
        }

        public async Task UpdateGroupUserAsync(int groupId, List<int> users, string keycloakId)
        {
            User userUpdating = _context.Users.First(u => u.KeycloakId == keycloakId);

            Group groupToUpdate = await _context.Groups
               .Include(c => c.Users)
               .Where(c => c.Id == groupId)
               .FirstAsync();

            if (!groupToUpdate.Users.Contains(userUpdating) 
                && groupToUpdate.IsPrivate 
                && groupToUpdate.Users.Count>0)
            {
                throw new Exception();
            }

            foreach (int userId in users)
            {
                User user = await _context.Users.FindAsync(userId);
                if (user == null)
                    throw new KeyNotFoundException();
                if (!groupToUpdate.Users.Contains(user))
                {
                    groupToUpdate.Users.Add(user);
                }
                
            }

            await _context.SaveChangesAsync();
        }

        public async Task LeaveGroupAsync(int groupId, string keycloakId)
        {
            User userUpdate = _context.Users.First(u => u.KeycloakId == keycloakId);

            Group groupToUpdate = await _context.Groups
               .Include(c => c.Users)
               .Where(c => c.Id == groupId)
               .FirstAsync();

            if (groupToUpdate.Users.Contains(userUpdate))
            {
                groupToUpdate.Users.Remove(userUpdate);
            }
            else
            {
                throw new Exception();

            }

            await _context.SaveChangesAsync();
        }
    }
}