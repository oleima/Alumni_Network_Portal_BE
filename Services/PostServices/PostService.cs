using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = Alumni_Network_Portal_BE.Models.Domain.Group;

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
        public async Task<IEnumerable<Post>> GetTopicPostsAsync(int topicId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Topic)
                .Where(c => c.TopicId == topicId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Post>> GetEventPostsAsync(int eventId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Event)
                .Where(c => c.EventId == eventId)
                .Where(c => c.Event.UsersResponded.Contains(user))
                .ToListAsync();
        }
        public async Task<Post> AddPostAsync(Post domainPost, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            if (domainPost.TopicId != null)
            {
                Topic audienceToPostTo = _context.Topics.First(t => t.Id == domainPost.TopicId);
                ICollection<Topic>? audienceRelation = user.Topics;
                if (!audienceRelation.Contains(audienceToPostTo))
                {
                    throw new Exception();
                }
            }
            else if (domainPost.GroupId != null)
            {
                Group audienceToPostTo = _context.Groups.First(g => g.Id == domainPost.GroupId);
                ICollection<Group>? audienceRelation = user.Groups;
                if (!audienceRelation.Contains(audienceToPostTo))
                {
                    throw new Exception();
                }
            }
            else if (domainPost.EventId != null)
            {
                Event audienceToPostTo = _context.Events.First(e => e.Id == domainPost.EventId);
                ICollection<Event>? audienceRelation = user.RespondedEvents;
                if (!audienceRelation.Contains(audienceToPostTo))
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }


            _context.Posts.Add(domainPost);
            await _context.SaveChangesAsync();
            return domainPost;


        }
        public async Task UpdateAsync(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
