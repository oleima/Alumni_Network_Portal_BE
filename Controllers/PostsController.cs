using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using Alumni_Network_Portal_BE.Services.PostServices;
using Alumni_Network_Portal_BE.Helpers;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Alumni_Network_Portal_BE.Models.DTOs.Pages;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
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
        // GET: api/posts/
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetPosts([FromQuery]Pagination ?pagination)
        {
            var keycloakId = this.User.GetId();
            if(pagination.Page > 0)
            {
                var posts = await _postService.GetAllAsync(keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts,pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }
                
            return _mapper.Map<List<PostReadDTO>>(await _postService.GetAllAsync(keycloakId));
        }

        // GET: api/posts/user
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetRecievedPosts([FromQuery] Pagination? pagination)
        {
            var keycloakId = this.User.GetId();

            if (pagination.Page > 0)
            {
                var posts = await _postService.GetMessagesAsync(keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts, pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetMessagesAsync(keycloakId));
        }

        // GET: api/posts/user/{id}
        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetRecievedFromAuthorPosts(int id, [FromQuery] Pagination? pagination)
        {
            var keycloakId = this.User.GetId();

            if (pagination.Page > 0)
            {
                var posts = await _postService.GetMessagesFromAuthorAsync(id,keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts, pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetMessagesFromAuthorAsync(id,keycloakId));
        }

        // GET: api/posts/group/{id}
        [Authorize]
        [HttpGet("group/{id}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetGroupPosts(int id, [FromQuery] Pagination? pagination)
        {
            var keycloakId = this.User.GetId();

            if (pagination.Page > 0)
            {
                var posts = await _postService.GetGroupPostsAsync(id, keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts, pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetGroupPostsAsync(id, keycloakId));
        }

        // GET: api/posts/topic/{id}
        [Authorize]
        [HttpGet("topic/{id}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetTopicPosts(int id, [FromQuery] Pagination? pagination)
        {
            var keycloakId = this.User.GetId();

            if (pagination.Page > 0)
            {
                var posts = await _postService.GetTopicPostsAsync(id, keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts, pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetTopicPostsAsync(id, keycloakId));
        }

        // GET: api/posts/event/{id}
        [Authorize]
        [HttpGet("event/{id}")]
        public async Task<ActionResult<IEnumerable<PostReadDTO>>> GetEventPosts(int id, [FromQuery] Pagination? pagination)
        {
            var keycloakId = this.User.GetId();

            if (pagination.Page > 0)
            {
                var posts = await _postService.GetEventPostsAsync(id, keycloakId);
                var paginationMetadata = new PaginationMetadata(posts.Count(), pagination.Page, pagination.ItemsPerPage);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
                posts = _postService.Paginate(posts, pagination);
                return _mapper.Map<List<PostReadDTO>>(posts);
            }

            return _mapper.Map<List<PostReadDTO>>(await _postService.GetEventPostsAsync(id, keycloakId));
        }

        // POST: api/posts/
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(PostCreateDTO dtoPost)
        {
            string keycloakId = this.User.GetId();

            Post domainPost = _mapper.Map<Post>(dtoPost);
            domainPost.LastUpdated = DateTime.Now;
            try
            {
                domainPost = await _postService.AddPostAsync(domainPost, keycloakId);
                return CreatedAtAction("GetPosts",
                    new { id = domainPost.Id },
                    _mapper.Map<PostReadDTO>(domainPost));
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid audience");
            }
            catch (Exception)
            {
                return Forbid();
            }

        }

        // PUT: api/posts/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostUpdateDTO dtoPost)
        {
            if (id != dtoPost.Id)
            {
                return BadRequest();
            }

            if (!_postService.Exists(id))
            {
                return NotFound();
            }
            Post domainPost = _mapper.Map<Post>(dtoPost);
            await _postService.UpdateAsync(domainPost);

            return NoContent();
        }


        #endregion
    }
}
