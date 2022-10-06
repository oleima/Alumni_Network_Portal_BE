using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alumni_Network_Portal_BE.Services.TopicServices
{
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
                .ToListAsync();
        }
        public async Task<Topic> GetTopicById(int id)
        {
            return await _context.Topics
                .Include(t => t.Posts)
                .Include(t => t.Events)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Topic> AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic> JoinTopic(int topicId, int userId)
        {
            //FIXME
            Topic topic = _context.Topics
                .Include(t => t.Users)
                .First();

            User user = _context.Users
                .Single(u => u.Id == userId);
            topic.Users.Add(user);
            await _context.SaveChangesAsync();
            return topic;
        }
        public bool Exists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }

    }
}
