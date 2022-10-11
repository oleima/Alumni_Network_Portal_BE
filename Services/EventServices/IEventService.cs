using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.EventServices
{
    public interface IEventService
    {
        public Task<IEnumerable<Event>> GetEvents(string keycloakId);
        public Task<Event> CreateEvent(Event ev);
        public Task UpdateEvent(Event ev);
        public Task CreateGroupEventInvitation(int eventId, int groupId);
        public Task DeleteGroupEventInvitation(int eventId, int groupId);
        public Task CreateTopicEventInvitation(int eventId, int topicId);
        public Task DeleteTopicEventInvitation(int eventId, int topicId);
        public Task CreateUserEventInvitation(int eventId, int userId);
        public Task DeleteUserEventInvitation(int eventId, int userId);
        public Task CreateEventRSVP(int eventId, string keycloakId);
        public bool Exists(int id);
    }
}
