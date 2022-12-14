using Microsoft.AspNetCore.Mvc;
using Alumni_Network_Portal_BE.Models.Domain;
using AutoMapper;
using Alumni_Network_Portal_BE.Services.UserServices;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;
using Alumni_Network_Portal_BE.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using System.Net.Mime;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/Users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserReadDTO>> GetUser()
        {
            string keycloakId = this.User.GetId();

            if(_userService.getUserFromKeyCloak(keycloakId) == null)
            {
                return BadRequest();
            }

            return _mapper.Map<UserReadDTO>(await _userService.GetAsync(keycloakId));
        }

        // GET: api/Users/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            User user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReadDTO>(user);
        }

        // PATCH: api/Users/{id}
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchUser(int id, UserUpdateDTO userInput)
        {
            string keycloakId = this.User.GetId();
            User userToPatch = _userService.getUserFromKeyCloak(keycloakId);

            if (userToPatch.Id != id)
            {
                return BadRequest();
            }

            if (!_userService.Exists(id))
            {
                return NotFound();
            }
            User patchUser = _mapper.Map<User>(userInput);
            await _userService.UpdateAsync(patchUser,userToPatch);

            return NoContent();
        }

        // POST: api/Users/
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser()
        {
            var keycloakID = this.User.GetId();
            var username = this.User.GetUsername();
            if (keycloakID == null)
            {
                return NotFound();
            }

            if(_userService.getUserFromKeyCloak(keycloakID) != null)
            {
                return BadRequest();
            }

            User domainUser = await _userService.PostAsync(keycloakID, username);

            return CreatedAtAction("GetÙser",
                new { id = domainUser.Id },
                _mapper.Map<UserReadDTO>(domainUser));

        }
    }
}
