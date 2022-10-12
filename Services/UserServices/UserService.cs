using Alumni_Network_Portal_BE.Helpers;
using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

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

        public async Task<User> GetAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Users
            .Include(c => c.Groups)
            .Include(c => c.Topics)
            .Include(c => c.AuthoredPosts)
            .Include(c => c.RecievedPosts)
            .Include(c => c.InvitedEvents)
            .Include(c => c.AuthoredEvents)
            .Where(c => c.Id == user.Id)
            .FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
            .Include(c => c.Groups)
            .Include(c => c.Topics)
            .Include(c => c.AuthoredEvents)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User patchUser, User userToPatch)
        {
            if (patchUser.Username != null)
            {
                userToPatch.Username = patchUser.Username;
            }
            if (patchUser.Status != null)
            {
                userToPatch.Status = patchUser.Status;
            }
            if (patchUser.Bio != null)
            {
                userToPatch.Bio = patchUser.Bio;
            }
            if (patchUser.FunFact != null)
            {
                userToPatch.FunFact = patchUser.FunFact;
            }
            if (patchUser.Picture != null)
            {
                userToPatch.Picture = patchUser.Picture;
            }
            _context.Entry(userToPatch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<User> PostAsync(string keycloakId, string username)
        {
            User user = new User { KeycloakId = keycloakId, Username = username, Status = "" };

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
            
        }

        public User getUserFromKeyCloak(string keycloakId)
        {
            User user = _context.Users.FirstOrDefaultAsync(u => u.KeycloakId == keycloakId).Result;
            return user;
        }
    }
}
