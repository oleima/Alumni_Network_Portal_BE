using Alumni_Network_Portal_BE.Helpers;
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
            return _context.Users.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
            .Include(c => c.Groups)
            .Include(c => c.Topics)
            .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(c => c.Groups)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task PostAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
