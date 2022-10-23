using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alumni_Network_Portal_BE.Services.TopicServices
{
    ///<inheritdoc[cref = "ITopicService"]/>
    public class TopicService : ITopicService
    {
        private readonly AlumniNetworkDbContext _context;

        public TopicService(AlumniNetworkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return await _context.Topics
                .Include(t => t.Posts)
                .Include(t => t.Events)
                .Include(t => t.Users)
                .ToListAsync();
        }
        public async Task<Topic> GetTopicById(int id)
        {
            return await _context.Topics
                .Include(t => t.Posts)
                .Include(t => t.Events)
                .Include(t => t.Users)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Topic> AddTopic(Topic topic, string keycloakId)
        {
            User user = getUserFromKeyCloak(keycloakId);
            var userList = new List<User> { user };
            topic.Users = userList;
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic> JoinTopic(int topicId, string keycloakId)
        {
            Topic topic = _context.Topics
                .Include(t => t.Users)
                .FirstOrDefaultAsync(t => t.Id == topicId).Result;

            User user = getUserFromKeyCloak(keycloakId);
            topic.Users.Add(user);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task LeaveTopic(int topicId, string keycloakId)
        {
            Topic topic = _context.Topics
                .Include(t => t.Users)
                .FirstOrDefaultAsync(t => t.Id == topicId).Result;

            User user = getUserFromKeyCloak(keycloakId);

            if (topic.Users.Contains(user))
            {
                topic.Users.Remove(user);
            }
            else
            {
                throw new Exception();

            }
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }

        public User getUserFromKeyCloak(string keycloakId)
        {
            User user = _context.Users.FirstOrDefaultAsync(u => u.KeycloakId == keycloakId).Result;
            return user;
        }

    }
}
