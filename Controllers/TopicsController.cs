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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicReadDTO>>> GetTopics()
        {
            return _mapper.Map<List<TopicReadDTO>>(await _topicService.GetTopics());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TopicReadDTO>>> GetTopic()
        {
            return _mapper.Map<List<TopicReadDTO>>(await _topicService.GetTopics());
        }

        [HttpPost]
        public async Task<ActionResult> PostTopic([FromBody] string json)
        {

            return _mapper.Map<List<TopicReadDTO>>(await _topicService.GetTopics());
        }

        [HttpPost("{id}/join")]
        public async Task<ActionResult> JoinTopic(int id)
        {
            if(!_topicService.Exists(id))
            {
                return NotFound();
            }

             
        }

    }
}
