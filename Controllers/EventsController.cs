using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using Alumni_Network_Portal_BE.Services.EventServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Alumni_Network_Portal_BE.Helpers;
using System.Text.RegularExpressions;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using System.Net.Mime;

namespace Alumni_Network_Portal_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventsController(IMapper mapper, IEventService eventService)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        //FIXME Different DTOs? Return object on delete?

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventReadDTO>>> GetEvents()
        {
            string keycloakId = this.User.GetId();
            return _mapper.Map<List<EventReadDTO>>(await _eventService.GetEvents(keycloakId));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(EventCreateDTO ev)
        {
            string keycloakId = this.User.GetId();
            Event domainEvent = _mapper.Map<Event>(ev);

            domainEvent = await _eventService.AddEvent(domainEvent, keycloakId);
            return CreatedAtAction("GetEvents",
                new { Id = domainEvent.Id },
                _mapper.Map<EventUserReadDTO>(domainEvent));
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventUpdateDTO ev)
        {
            string keycloakId = this.User.GetId();

            if (id != ev.Id)
            {
                return BadRequest();
            }
            
            if (!_eventService.Exists(id))
            {
                return NotFound();
            }
            Event domainEvent = _mapper.Map<Event>(ev);
            await _eventService.UpdateEvent(domainEvent, keycloakId, id);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{eventId}/invite/group/{groupId}")]
        public async Task<IActionResult> CreateGroupEventInvitation(int eventId, int groupId)
        {
            if(!_eventService.Exists(eventId))
            {
                return NotFound();
            }

            try
            {
                await _eventService.CreateGroupEventInvitation(eventId, groupId);
            }
            catch (Exception)
            {

                // Error hanalding
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{eventId}/invite/group/{groupId}")]
        public async Task<IActionResult> DeleteGroupEventInvitation(int eventId, int groupId)
        {
            if(!_eventService.Exists(eventId))
            {
                return NotFound();
            }
            await _eventService.DeleteGroupEventInvitation(eventId, groupId);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{eventId}/invite/topic/{topicId}")]
        public async Task<IActionResult> CreateTopicEventInvitation(int eventId, int topicId)
        {
            if (!_eventService.Exists(eventId))
            {
                return NotFound();
            }

            try
            {
                await _eventService.CreateTopicEventInvitation(eventId, topicId);
            }
            catch (Exception)
            {

                // Error hanalding
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{eventId}/invite/topic/{topicId}")]
        public async Task<IActionResult> DeleteTopicEventInvitation(int eventId, int topicId)
        {
            if (!_eventService.Exists(eventId))
            {
                return NotFound();
            }
            await _eventService.DeleteTopicEventInvitation(eventId, topicId);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{eventId}/invite/user/{userId}")]
        public async Task<IActionResult> CreateUserEventInvitation(int eventId, int userId)
        {
            if (!_eventService.Exists(eventId))
            {
                return NotFound();
            }

            try
            {
                await _eventService.CreateUserEventInvitation(eventId, userId);
            }
            catch (Exception)
            {

                // Error hanalding
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{eventId}/invite/user/{userId}")]
        public async Task<IActionResult> DeleteUserEventInvitation(int eventId, int userId)
        {
            if (!_eventService.Exists(eventId))
            {
                return NotFound();
            }
            await _eventService.DeleteUserEventInvitation(eventId, userId);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{eventId}/rsvp")]
        public async Task<IActionResult> CreateEventRSVP(int eventId)
        {
            if (!_eventService.Exists(eventId))
            {
                return NotFound();
            }

            try
            {
                string keycloakId = this.User.GetId();
                await _eventService.CreateEventRSVP(eventId, keycloakId);
            }
            catch (Exception)
            {

                // Error hanalding
            }

            return NoContent();
        }
    }
}
