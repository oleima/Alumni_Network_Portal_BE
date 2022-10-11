using Alumni_Network_Portal_BE.Models;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = Alumni_Network_Portal_BE.Models.Domain.Group;

namespace Alumni_Network_Portal_BE.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly AlumniNetworkDbContext _context;
        public EventService(AlumniNetworkDbContext context)
        {
            _context = context;
        }
        public User getUserFromKeyCloak(string keycloakId)
        {
            User user = _context.Users.FirstOrDefaultAsync(u => u.KeycloakId == keycloakId).Result;
            return user;
        }
        public async Task<IEnumerable<Event>> GetEvents(string keycloakId)
        {
            User user = getUserFromKeyCloak(keycloakId);

            return await _context.Events
                .Include(e => e.Groups)
                .Include(e => e.Topics)
                .Include(e => e.Posts)
                .Include(e => e.UsersResponded)
                .Where(e => e.Groups.Any(g => g.Users.Contains(user)))
                .Where(e => e.Topics.Any(t => t.Users.Contains(user)))
                .Distinct()
                .ToListAsync();
        }
        public async Task<Event> CreateEvent(Event ev)
        {
            ev.LastUpdated = DateTime.Now;
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return ev;
        }
        public async Task UpdateEvent(Event ev)
        {
            ev.LastUpdated = DateTime.Now;
            _context.Entry(ev).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task CreateGroupEventInvitation(int eventId, int groupId)
        {
            Event ev = _context.Events
                .Include(e => e.Groups)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;

            Group group = _context.Groups
                .Where(g => g.Id == groupId)
                .FirstOrDefaultAsync().Result;

            if (ev.Groups == null)
            {
                ev.Groups = new List<Group>();
            }

            ev.Groups.Add(group);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGroupEventInvitation(int eventId, int groupId)
        {
            Event ev = _context.Events
                .Include(e => e.Groups)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;

            Group group = _context.Groups
                .Where(g => g.Id == groupId)
                .FirstOrDefaultAsync().Result;

            ev.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
        public async Task CreateTopicEventInvitation(int eventId, int topicId)
        {
            Event ev = _context.Events
                .Include(e => e.Topics)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;
            Topic topic = _context.Topics
                .Where(t => t.Id == topicId)
                .FirstOrDefaultAsync().Result;

            ev.Topics.Add(topic);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTopicEventInvitation(int eventId, int topicId)
        {
            Event ev = _context.Events
                .Include(e => e.Topics)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;
            Topic topic = _context.Topics
                .Where(t => t.Id == topicId)
                .FirstOrDefaultAsync().Result;

            ev.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }
        public async Task CreateUserEventInvitation(int eventId, int userId)
        {
            Event ev = _context.Events
                .Include(e => e.UserInvited)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;
            
            User user = _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync().Result;


            if (ev.UserInvited == null)
            {
                ev.UserInvited = new List<User>();
            }

            ev.UserInvited.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserEventInvitation(int eventId, int userId)
        {
            Event ev = _context.Events
                .Include(e => e.UserInvited)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;

            User user = _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync().Result;


            ev.UserInvited.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task CreateEventRSVP(int eventId, string keycloakId)
        {
            Event ev = _context.Events
                .Include(e => e.UserInvited)
                .FirstOrDefaultAsync(e => e.Id == eventId).Result;

            User user = _context.Users
                .Where(u => u.KeycloakId == keycloakId)
                .FirstOrDefaultAsync().Result;

            if(ev.UsersResponded == null)
            {
                ev.UsersResponded = new List<User>();
            }

            ev.UsersResponded.Add(user);
            await _context.SaveChangesAsync();
        }
        public bool Exists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
