using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Network_Portal_BE.Services.PostServices
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetAllAsync(string keycloakId);
        public Task<IEnumerable<Post>> GetMessagesAsync(string keycloakId);
        public Task<IEnumerable<Post>> GetMessagesFromAuthorAsync(int id, string keycloakId);
        public Task<IEnumerable<Post>> GetGroupPostsAsync(int groupId, string keycloakId);
        public Task<IEnumerable<Post>> GetTopicPostsAsync(int topicId, string keycloakId);
        public Task<IEnumerable<Post>> GetEventPostsAsync(int eventId, string keycloakId);
        public Task<Post> AddPostAsync(Post domainPost, string keycloakId);
        public Task UpdateAsync(Post post);
        public bool Exists(int id);
        public IEnumerable<Post> Paginate(IEnumerable<Post> posts, Pagination pagination);


    }
}
