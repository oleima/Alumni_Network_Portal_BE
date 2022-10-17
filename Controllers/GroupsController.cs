using Microsoft.AspNetCore.Mvc;
using Alumni_Network_Portal_BE.Models.Domain;
using AutoMapper;
using Alumni_Network_Portal_BE.Models.DTOs.GroupDTO;
using Alumni_Network_Portal_BE.Services.GroupServices;
using Alumni_Network_Portal_BE.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public GroupsController(IMapper mapper, IGroupService groupService)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        // GET: api/Groups
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupReadDTO>>> GetGroup()
        {
            var keycloakId = this.User.GetId();
            return _mapper.Map<List<GroupReadDTO>>(await _groupService.GetAllAsync(keycloakId));
        }

        // GET: api/Groups/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupReadDTO>> GetGroupById(int id)
        {
            var keycloakId = this.User.GetId();
            Group group = await _groupService.GetByIdAsync(id,keycloakId);

            if (group == null)
            {
                return NotFound();
            }

            if(group.Id == 0)
            {
                return Forbid();
            }

            return _mapper.Map<GroupReadDTO>(group);
        }

        // Put: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup(GroupCreateDTO groupDTO)
        {
            var keycloakId = this.User.GetId();
            Group domainGroup = _mapper.Map<Group>(groupDTO);

            domainGroup = await _groupService.AddGroupAsync(domainGroup, keycloakId);

            return CreatedAtAction("GetGroup",
                new { id = domainGroup.Id },
                _mapper.Map<GroupReadDTO>(domainGroup));
        }

        #region Updating linking table

        // Post users to a specific movie in linking table
        [Authorize]
        [HttpPut("{id}/Join")]
        public async Task<IActionResult> UpdateGroupUser(int id)
        {
            var keycloakId = this.User.GetId();
            if (!_groupService.Exists(id))
            {
                return NotFound();
            }

            try
            {
                await _groupService.UpdateGroupUserAsync(id, keycloakId);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid user.");
            }
            catch (Exception)
            {
                return Forbid();
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}/Leave")]
        public async Task<IActionResult> LeaveGroupUser(int id)
        {
            var keycloakId = this.User.GetId();
            if ( !_groupService.Exists(id))
            {
                return NotFound();
            }

            try
            {
                await _groupService.LeaveGroupAsync(id, keycloakId);
            } catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        #endregion

    }
}
