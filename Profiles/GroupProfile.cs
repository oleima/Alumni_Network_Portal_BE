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
            CreateMap<Group, GroupReadDTO>();

            CreateMap<Group, GroupUserReadDTO>();

            CreateMap<GroupCreateDTO, Group>();

            CreateMap<GroupUpdateDTO, Group>();
        }
    }
}
