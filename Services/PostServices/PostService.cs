using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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

        public  IEnumerable<Post> Paginate(IEnumerable<Post> posts, Pagination pagination)
        {
            return posts
                .Skip((pagination.Page - 1) * pagination.ItemsPerPage)
                .Take(pagination.ItemsPerPage)
                .ToList();
        }

        public async Task<IEnumerable<Post>> GetAllAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Group)
                .Include(c => c.Topic)
                .Include(c => c.Author)
                .Include(c => c.Replies)
                .Where(c => c.ParentId == null)
                .Where(c => c.Group.Users.Contains(user) || c.Topic.Users.Contains(user))
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMessagesAsync(string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Where(c => c.RecieverId==user.Id)
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMessagesFromAuthorAsync(int authorId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Where(c => c.RecieverId == user.Id && c.AuthorId == authorId)
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetGroupPostsAsync(int groupId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Group)
                .Where(c => c.GroupId==groupId)
                .Where(c => c.Group.Users.Contains(user) || !c.Group.IsPrivate)
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }
        public async Task<IEnumerable<Post>> GetTopicPostsAsync(int topicId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Topic)
                .Where(c => c.TopicId == topicId)
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }
        public async Task<IEnumerable<Post>> GetEventPostsAsync(int eventId, string keycloakId)
        {
            User user = _context.Users.First(u => u.KeycloakId == keycloakId);

            return await _context.Posts
                .Include(c => c.Event)
                .Where(c => c.EventId == eventId)
                .Where(c => c.Event.UsersResponded.Contains(user))
                .OrderByDescending(c => c.LastUpdated.Date)
                .ThenBy(c => c.LastUpdated.TimeOfDay)
                .ToListAsync();
        }
        public async Task<Post> AddPostAsync(Post domainPost, string keycloakId)
        {
            User user = _context.Users
                .Include(u => u.Groups)
                .Include(u => u.Topics)
                .Include(u => u.RespondedEvents)
                .First(u => u.KeycloakId == keycloakId);

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
            else if (domainPost.RecieverId != null)
            {
                if (domainPost.RecieverId == user.Id)
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }

            domainPost.AuthorId = user.Id;
            _context.Posts.Add(domainPost);
            await _context.SaveChangesAsync();
            return domainPost;


        }
        public async Task UpdateAsync(Post post)
        {
            post.LastUpdated = DateTime.Now;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
