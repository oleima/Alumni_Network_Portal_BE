using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.TopicServices
{
    public interface ITopicService
    {
        /// <summary>
        /// Adds a new topic
        /// </summary>
        /// <param name="topic">The topic to be added</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Topic> AddTopic(Topic topic, string keycloakId);
        /// <summary>
        /// The active user joins the topic by keycloakID
        /// </summary>
        /// <param name="topicId">Topic ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Topic> JoinTopic(int topicId, string keycloakId);
        /// <summary>
        /// Gets all the topics
        /// </summary>
        public Task<IEnumerable<Topic>> GetTopics();
        /// <summary>
        /// Gets a topic by ID
        /// </summary>
        /// <param name="id">Topic ID</param>
        public Task<Topic> GetTopicById(int id);
        /// <summary>
        /// The active user leaves the topic by keycloakID
        /// </summary>
        /// <param name="topicId">Topic ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task LeaveTopic(int topicId, string keycloakId);
        /// <summary>
        /// Checks if the topic exists
        /// </summary>
        /// <param name="id">ID of the topic</param>
        public bool Exists(int id);
        /// <summary>
        /// Gets a user from a keycloakID
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <returns>An user</returns>
        public User getUserFromKeyCloak(string keycloakId);

    }
}
