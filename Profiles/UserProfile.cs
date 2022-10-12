using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Mapping from user to the respective DTOs
            CreateMap<User, UserReadDTO>()
                .ForMember(cdto => cdto.Topics, opt => opt
                .MapFrom(u => u.Topics.Select(t => t.Title).ToArray()))
                .ForMember(cdto => cdto.Groups, opt => opt
                .MapFrom(u => u.Groups.Select(g => g.Title).ToArray()))
                .ForMember(cdto => cdto.AuthoredPosts, opt => opt
                .MapFrom(u => u.AuthoredPosts.Select(ap => ap.Title).ToArray()))
                .ForMember(cdto => cdto.RecievedPosts, opt => opt
                .MapFrom(u => u.RecievedPosts.Select(ap => ap.Title).ToArray()))
                .ForMember(cdto => cdto.AuthoredEvents, opt => opt
                .MapFrom(u => u.AuthoredEvents.Select(ap => ap.Name).ToArray()))
                .ForMember(cdto => cdto.RespondedEvents, opt => opt
                .MapFrom(u => u.RespondedEvents.Select(ap => ap.Name).ToArray()));

            CreateMap<User, UserPostReadDTO>();

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();
        }
    }
}

