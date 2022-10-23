using Alumni_Network_Portal_BE.Models.Domain;

namespace Alumni_Network_Portal_BE.Services.EventServices
{
    public interface IEventService
    {
        /// <summary>
        /// Gets all the events
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<IEnumerable<Event>> GetEvents(string keycloakId);
        /// <summary>
        /// Gets the events by ID
        /// </summary>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <param name="eventId">Event ID</param>
        public Task<Event> GetEventById(string keycloakId, int eventId);
        /// <summary>
        /// Adds a new event
        /// </summary>
        /// <param name="ev">The event to add</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task<Event> AddEvent(Event ev, string keycloakId);
        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="ev">The event to update</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        /// <param name="id">The ID of the event</param>
        public Task UpdateEvent(Event ev, string keycloakId, int id);
        /// <summary>
        /// Creates a group event invitation
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="groupId">Group ID</param>
        public Task CreateGroupEventInvitation(int eventId, int groupId);
        /// <summary>
        /// Deletes the group event invitation
        /// </summary>
        /// <param name="eventId">The ID of the Event</param>
        /// <param name="groupId">The ID of the group</param>
        public Task DeleteGroupEventInvitation(int eventId, int groupId);
        /// <summary>
        /// Creates a topic event invitation
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="topicId">The ID of the topic</param>
        public Task CreateTopicEventInvitation(int eventId, int topicId);
        /// <summary>
        /// Deletes the topic event invitation
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="topicId">The ID of the topic</param>
        /// <returns></returns>
        public Task DeleteTopicEventInvitation(int eventId, int topicId);
        /// <summary>
        /// Creates a user invitation for an event
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="userId">The user ID</param>
        /// <returns></returns>
        public Task CreateUserEventInvitation(int eventId, int userId);
        /// <summary>
        /// Deletes a user invitation
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="userId">The user ID</param>
        public Task DeleteUserEventInvitation(int eventId, int userId);
        /// <summary>
        /// Creates an RSVP ("Joined event")
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <param name="keycloakId">The sub identifier in the token</param>
        public Task CreateEventRSVP(int eventId, string keycloakId);
        /// <summary>
        /// Checks of the event exists
        /// </summary>
        /// <param name="id">ID of the event</param>
        public bool Exists(int id);
    }
}
