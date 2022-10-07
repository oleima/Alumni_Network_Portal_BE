using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alumni_Network_Portal_BE.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly AlumniNetworkDbContext _context;

        public PostService(AlumniNetworkDbContext context)
        {
            _context = context;
        }
        //Fixme: Reverse orer to chronologically reversed
        public async Task<IEnumerable<Post>> GetAllAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Group)
                .Include(c => c.Topic)
                .Where(c=>c.Group.Users.Contains(user)|| c.Topic.Users.Contains(user))
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMessagesAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Where(c => c.RecieverId==user.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMessagesFromAuthorAsync(int authorId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Where(c => c.RecieverId == user.Id && c.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetGroupPostsAsync(int groupId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Group)
                .Where(c => c.GroupId==groupId)
                .Where(c => c.Group.Users.Contains(user) || !c.Group.IsPrivate)
                .ToListAsync();
        }
    }
}
