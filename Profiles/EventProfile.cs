using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using AutoMapper;


namespace Alumni_Network_Portal_BE.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventReadDTO>()
            .ForMember(cdto => cdto.UsersResponded, opt => opt
            .MapFrom(c => c.UsersResponded.Select(c => c.Username).ToArray()))
            .ForMember(cdto => cdto.Groups, opt => opt
            .MapFrom(c => c.Groups.Select(c => c.Title).ToArray()))
            .ForMember(cdto => cdto.Topics, opt => opt
            .MapFrom(c => c.Topics.Select(c => c.Name).ToArray()))
            .ForMember(cdto => cdto.Posts, opt => opt
            .MapFrom(c => c.Posts.Select(c => c.Title).ToArray()));

            CreateMap<EventCreateDTO, Event>();

            CreateMap<EventUpdateDTO, Event>();
        }
    }
}
