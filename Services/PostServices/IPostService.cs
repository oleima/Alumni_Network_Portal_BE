using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.PostServices
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetAllAsync(string keycloakId);
        public Task<IEnumerable<Post>> GetMessagesAsync(string keycloakId);
        public Task<IEnumerable<Post>> GetMessagesFromAuthorAsync(int id, string keycloakId);
        public Task<IEnumerable<Post>> GetGroupPostsAsync(int groupId, string keycloakId);
        
    }
}
