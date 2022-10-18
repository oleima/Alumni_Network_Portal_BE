using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.TopicServices
{
    public interface ITopicService
    {
        public Task<Topic> AddTopic(Topic topic, string keycloakId);
        public Task<Topic> JoinTopic(int topicId, string keycloakId);
        public Task<IEnumerable<Topic>> GetTopics();
        public Task<Topic> GetTopicById(int id);
        public Task LeaveTopic(int topicId, string keycloakId);


        public bool Exists(int id);
        public User getUserFromKeyCloak(string keycloakId);

    }
}
