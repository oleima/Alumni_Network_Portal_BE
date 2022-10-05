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
            return _context.Group.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            List<Group> myList = await _context.Group.ToListAsync();
            foreach(var group in myList)
            {
                if (group.IsPrivate)
                {
                    myList.Remove(group);
                }
            }
            return myList;
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Group
                .Include(c => c.Users)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}