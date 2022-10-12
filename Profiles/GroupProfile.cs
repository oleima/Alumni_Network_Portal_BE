using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.GroupDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            //Mapping from group to the respective DTOs
            CreateMap<Group, GroupReadDTO>()
                .ForMember(cdto => cdto.Users, opt => opt
                .MapFrom(c => c.Users.Select(c => c.Id).ToArray()))
                .ForMember(cdto => cdto.Posts, opt => opt
                .MapFrom(c => c.Posts.Select(c => c.Id).ToArray()))
                .ForMember(cdto => cdto.Events, opt => opt
                .MapFrom(c => c.Events.Select(c => c.Id).ToArray()));

            CreateMap<GroupCreateDTO, Group>();

            CreateMap<GroupUpdateDTO, Group>();
        }
    }
}
