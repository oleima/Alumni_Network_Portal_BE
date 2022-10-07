using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Services.PostServices;
using Alumni_Network_Portal_BE.Helpers;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostsController(IMapper mapper, IPostService postService)
        {
            _postService = postService;
            _mapper = mapper;
        }

        #region Generic CRUD with DTOs

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetPosts()
        {
            var keycloakId = this.User.GetId();

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetAllAsync(keycloakId));
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetRecievedPosts()
        {
            var keycloakId = this.User.GetId();

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetMessagesAsync(keycloakId));
        }

        [HttpGet("user/{{id}}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetRecievedFromAuthorPosts(int id)
        {
            var keycloakId = this.User.GetId();

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetMessagesFromAuthorAsync(id,keycloakId));
        }

        [HttpGet("group/{{id}}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetGroupPosts(int id)
        {
            var keycloakId = this.User.GetId();

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetGroupPostsAsync(id, keycloakId));
        }



        #endregion
    }
}
