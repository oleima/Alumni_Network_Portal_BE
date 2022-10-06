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

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        public TopicsController(IMapper mapper, ITopicService topicService)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        //TODO Authorization and exception handling
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicReadDTO>>> GetTopics() //TODO Add search, limit and pagination
        {
            return _mapper.Map<List<TopicReadDTO>>(await _topicService.GetTopics());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicReadDTO>> GetTopic(int id)
        {
            return _mapper.Map<TopicReadDTO>(await _topicService.GetTopicById(id));
        }

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

    }
}
