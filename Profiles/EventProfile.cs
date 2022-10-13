using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.EventDTO;
using AutoMapper;


namespace Alumni_Network_Portal_BE.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventReadDTO>();

            CreateMap<Event, EventGroupReadDTO>()
            .ForMember(cdto => cdto.UsersResponded, opt => opt
            .MapFrom(c => c.UsersResponded.Select(c => c.Id).ToArray()));

            CreateMap<Event, EventUserReadDTO>();

            CreateMap<EventCreateDTO, Event>();

            CreateMap<EventUpdateDTO, Event>();
        }
    }
}
