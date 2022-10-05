using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.TopicServices
{
    public interface ITopicService
    {
        public Task<Topic> AddTopic(Topic topic);
        public Task<Topic> JoinTopic(int topicId, int userId);
        public Task<IEnumerable<Topic>> GetTopics();
        public Task<Topic> GetTopicById(int id);

        public bool Exists(int id);
    }
}
