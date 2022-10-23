using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Services.TopicServices;
using AutoMapper;
using Alumni_Network_Portal_BE.Models.DTOs.TopicDTO;
using Alumni_Network_Portal_BE.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        public TopicsController(IMapper mapper, ITopicService topicService)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        // GET: api/topics/
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicReadDTO>>> GetTopics()
        {
            return _mapper.Map<List<TopicReadDTO>>(await _topicService.GetTopics());
        }

        // GET: api/topics/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicReadDTO>> GetTopic(int id)
        {
            return _mapper.Map<TopicReadDTO>(await _topicService.GetTopicById(id));
        }

        // POST: api/topics/
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostTopic(TopicCreateDTO topicDTO)
        {
            Topic domainTopic = _mapper.Map<Topic>(topicDTO);
            string keycloakID = this.User.GetId();
            domainTopic = await _topicService.AddTopic(domainTopic, keycloakID);
            return CreatedAtAction("GetTopic",
              new { id = domainTopic.Id },
              _mapper.Map<TopicReadDTO>(domainTopic));

        }

        // POST: api/topics/{id}/join
        [Authorize]
        [HttpPost("{id}/join")]
        public async Task<ActionResult> JoinTopic(int id)
        {
            if(!_topicService.Exists(id))
            {
                return NotFound();
            }

            try
            {
                string keycloakID = this.User.GetId();
                await _topicService.JoinTopic(id, keycloakID);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Error");
            }

            return NoContent();


        }

        // DELETE: api/topics/{id}/leave
        [Authorize]
        [HttpDelete("{id}/Leave")]
        public async Task<ActionResult> LeaveTopic(int id)
        {
            if (!_topicService.Exists(id))
            {
                return NotFound();
            }

            try
            {
                string keycloakID = this.User.GetId();
                await _topicService.LeaveTopic(id, keycloakID);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

            return NoContent();


        }
    }
}
