using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alumni_Network_Portal_BE.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AlumniNetworkDbContext _context;

        public UserService(AlumniNetworkDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User
            .Include(c => c.Groups)
            .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User
                .Include(c => c.Groups)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
