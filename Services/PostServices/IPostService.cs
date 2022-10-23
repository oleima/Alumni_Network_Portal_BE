using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.Pages;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Network_Portal_BE.Services.PostServices
{
    public interface IPostService
    {
        /// <summary>
        /// Gets all the posts based on keycloakID
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetAllAsync(string keycloakId);
        /// <summary>
        /// Gets all the messages (DMs)
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetMessagesAsync(string keycloakId);
        /// <summary>
        /// Gets all the messages from specific person
        /// </summary>
        /// <param name="authorId">The ID of the author</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetMessagesFromAuthorAsync(int authorId, string keycloakId);
        /// <summary>
        /// Gets group posts
        /// </summary>
        /// <param name="groupId">ID of the group</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetGroupPostsAsync(int groupId, string keycloakId);
        /// <summary>
        /// Gets topic posts
        /// </summary>
        /// <param name="topicId">Topic ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetTopicPostsAsync(int topicId, string keycloakId);
        /// <summary>
        /// Gets events posts
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Post>> GetEventPostsAsync(int eventId, string keycloakId);
        /// <summary>
        /// Adds a post
        /// </summary>
        /// <param name="domainPost">The post to be added</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Post> AddPostAsync(Post domainPost, string keycloakId);
        /// <summary>
        /// Updates a post
        /// </summary>
        /// <param name="post">The updated post</param>
        public Task UpdateAsync(Post post);
        /// <summary>
        /// Checks if the post exists
        /// </summary>
        /// <param name="id">ID of the post</param>
        public bool Exists(int id);
        /// <summary>
        /// Paginates a list of posts
        /// </summary>
        /// <param name="posts">The posts</param>
        /// <param name="pagination">The type of pagination</param>
        /// <returns>a list of posts</returns>
        public IEnumerable<Post> Paginate(IEnumerable<Post> posts, Pagination pagination);


    }
}
